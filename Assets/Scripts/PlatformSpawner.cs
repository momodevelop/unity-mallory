using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class PlatformSpawner : Momo.PersistantMonoBehaviourSingleton<PlatformSpawner>
{
    public class Tile : TileBase
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

    public Sprite obstacleSprite;   

    const float kTileSize = 96;
    const float kPixelPerUnit = 100.0f;
    const float kActualTileSize = kTileSize / kPixelPerUnit;

    Tilemap tilemap;

    [SerializeField]
    LevelEndTrigger levelEndTrigger;

    // Start is called before the first frame update
    void Start()
    {
        if (obstacleSprite == null)
            Destroy(this);
        if (levelEndTrigger == null)
            Destroy(this);

        tilemap = GetComponent<Tilemap>();
        levelEndTrigger.onTriggerEnterEvent += OnReachedEndpoint;



        OnReachedEndpoint();
    }

    private void OnReachedEndpoint()
    {
        int WIDTH = 20;
        int HEIGHT = 20;
        int SECTION_HEIGHT = 4;
        int MIN_BLOCK_WIDTH = 2;
        int MIN_BLOCK_HEIGHT = 1;
        int MAX_BLOCK_WIDTH = 4;
        int MAX_BLOCK_HEIGHT = SECTION_HEIGHT;
        int CHANCE_TO_PLACE_BLOCK = 50;

        GenerateLevel(tilemap, obstacleSprite,
             WIDTH, HEIGHT, SECTION_HEIGHT, MIN_BLOCK_WIDTH, MAX_BLOCK_WIDTH, MIN_BLOCK_HEIGHT, MAX_BLOCK_HEIGHT, CHANCE_TO_PLACE_BLOCK);
        SetLevelEndTrigger();
    }

    private void SetLevelEndTrigger()
    {
        float levelEndTriggerPosY = GetTilemapEndY(tilemap) + kActualTileSize;

        // set the end level box
        levelEndTrigger.transform.position = new Vector2(levelEndTrigger.transform.position.x, levelEndTriggerPosY);
    }



    #region Static Functions
    public static void GenerateLevel(
       Tilemap tilemap,
       Sprite sprite,
       int width, int height,
       int sectionHeight,
       int minBlockWidth, int maxBlockWidth,
       int minBlockHeight, int maxBlockHeight,
       int chanceToPlaceBlock)
    {

        int[,] map = LevelGenerator.GenerateLevel(
            width,
            height,
            minBlockWidth,
            maxBlockWidth,
            minBlockHeight,
            maxBlockHeight,
            sectionHeight,
            chanceToPlaceBlock
        );

        // Set the tiles
        SyncLevelValueToTilemap(tilemap, map, sprite, 1);
    }

    private static void SyncLevelValueToTilemap(Tilemap tilemap, int[,] level, Sprite sprite, int value)
    {
        for (int row = 0; row < level.GetLength(0); ++row)
        {
            for (int col = 0; col < level.GetLength(1); ++col)
            {
                if (level[row, col] == value)
                {
                    SetTilemapTile(tilemap, new Vector3Int(col, row, 0), sprite);
                }
            }
        }
    }

    private static void SetTilemapTile(Tilemap tilemap, Vector3Int position, Sprite sprite)
    {
        var tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = sprite;
        tilemap.SetTile(position, tile);
    }


    private static float GetTilemapEndY(Tilemap tilemap)
    {
        return tilemap.transform.position.y + tilemap.size.y * tilemap.cellSize.y;
    }
    #endregion
}

