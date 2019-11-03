using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class LevelManager : Momo.PersistantMonoBehaviourSingleton<LevelManager>
{

    #region Drag and Drop
    public Sprite obstacleSprite;
    [SerializeField]
    public LevelEndTrigger levelEndTrigger;

    [SerializeField]
    Camera camera;
    #endregion

    #region Internal classes
    
    private struct LevelData
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int SectionHeight { get; set; }
        public int MinBlockWidth { get; set; }
        public int MinBlockHeight { get; set; }
        public int MaxBlockWidth { get; set; }
        public int MaxBlockHeight { get; set; }
        public int ChanceToPlaceBlock { get; set; }
    };
    private class Tile : TileBase
    {
        public Sprite sprite;

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {

            base.GetTileData(position, tilemap, ref tileData);
            if (sprite != null)
            {
                tileData.sprite = sprite;
                tileData.colliderType = UnityEngine.Tilemaps.Tile.ColliderType.Sprite;
            }
        }

        public override void RefreshTile(Vector3Int position, ITilemap tilemap)
        {
            base.RefreshTile(position, tilemap);
        }
    }


    // In charge of all modifications to tilemap
    private class TilemapHelper
    {
        
        internal static IEnumerator GenerateLevel(Tilemap tilemap, LevelData data, List<Sprite> spriteList)
        {
            int[,] map = LevelGenerator.GenerateLevel(
                data.Width,
                data.Height,
                data.MinBlockWidth,
                data.MaxBlockWidth,
                data.MinBlockHeight,
                data.MaxBlockHeight,
                data.SectionHeight,
                data.ChanceToPlaceBlock
            );

            // Set the tiles
            yield return SyncLevelValueToTilemap(tilemap, map, spriteList);

        }

        private static IEnumerator SyncLevelValueToTilemap(Tilemap tilemap, int[,] level, List<Sprite> spriteList)
        {
            for (int row = 0; row < level.GetLength(0); ++row)
            {
                for (int col = 0; col < level.GetLength(1); ++col)
                {
                    int id = level[row, col];
                    if (id < spriteList.Count)
                        SetTilemapTile(tilemap, new Vector3Int(col, row, 0), spriteList[id]);
                }
                yield return null;
            }
        }

        private static void SetTilemapTile(Tilemap tilemap, Vector3Int position, Sprite sprite)
        {
            var tile = ScriptableObject.CreateInstance<Tile>();
            tile.sprite = sprite;
            tilemap.SetTile(position, tile);
        }

    }
    #endregion

    #region Constants
    const float kTileSize = 96;
    const float kPixelPerUnit = 100.0f;
    const float kActualTileSize = kTileSize / kPixelPerUnit;
    #endregion

    LevelData levelData;
    Tilemap tilemap;
    List<Sprite> spriteList;


    // Start is called before the first frame update
    void Start()
    {
        DestroyIfNull(obstacleSprite);
        DestroyIfNull(levelEndTrigger);
        DestroyIfNull(camera);

        // Initialize tilemap manager
        tilemap = GetComponent<Tilemap>();
        DestroyIfNull(tilemap);

        // Observe level end trigger box event
        levelEndTrigger.onTriggerEnterEvent += OnReachedEndpoint;

        // Initialize sprite list
        spriteList = new List<Sprite>(new[]{null, obstacleSprite});
        
        // Initialize level data
        levelData.Width = 20;
        levelData.Height = 20;
        levelData.SectionHeight = 4;
        levelData.MinBlockWidth = 2;
        levelData.MinBlockHeight = 1;
        levelData.MaxBlockWidth = 4;
        levelData.MaxBlockHeight = 4;
        levelData.ChanceToPlaceBlock = 50;

        // Generate the first level
        GenerateLevel();
    }

    private void OnReachedEndpoint()
    {
        // move the tilemap up
        float tilemapEndpoint = tilemap.transform.position.y + levelData.Height * kActualTileSize;
        tilemap.transform.position = new Vector2(tilemap.transform.position.x, tilemapEndpoint);
        GenerateLevel();


    }

    private void GenerateLevel()
    {
        StartCoroutine(TilemapHelper.GenerateLevel(tilemap, levelData, spriteList));


        // set the end level box
        float levelEndTriggerPosY = tilemap.transform.position.y + (levelData.Height + 2) * kActualTileSize;
        levelEndTrigger.transform.position = new Vector2(levelEndTrigger.transform.position.x, levelEndTriggerPosY);
    }


    private void DestroyIfNull<T>(T obj)
    {
        if (obj == null)
            Destroy(this);
    }


}

