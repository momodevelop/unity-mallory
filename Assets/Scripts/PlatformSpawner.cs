using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]

public class PlatformSpawner : Momo.PersistantMonoBehaviourSingleton<PlatformSpawner>
{
    public Sprite obstacleSprite;
    

    const float kTileSize = 96;
    const float kPixelPerUnit = 100.0f;

    Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        if (obstacleSprite == null)
            Destroy(this);
        tilemap = GetComponent<Tilemap>();
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateLevel()
    {
        int WIDTH = 20;
        int HEIGHT = 20;
        int SECTION_HEIGHT = 4;
        int MIN_BLOCK_WIDTH = 2;
        int MIN_BLOCK_HEIGHT = 1;
        int MAX_BLOCK_WIDTH = 4;
        int MAX_BLOCK_HEIGHT = SECTION_HEIGHT;
        int CHANCE_TO_PLACE_BLOCK = 50;

        int[,] map = LevelGenerator.GenerateLevel(
            WIDTH, 
            HEIGHT, 
            MIN_BLOCK_WIDTH, 
            MAX_BLOCK_WIDTH, 
            MIN_BLOCK_HEIGHT, 
            MAX_BLOCK_HEIGHT, 
            SECTION_HEIGHT, 
            CHANCE_TO_PLACE_BLOCK
        );

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = (worldScreenHeight / Screen.height) * Screen.width;


        
        float startY = kTileSize / 2;

        for (int row = 0; row < map.GetLength(0); ++row)
        {
            float startX = kTileSize / 2;
            for (int col = 0; col < map.GetLength(1); ++col)
            {
                if (map[row, col] == 1)
                {
                    SpawnPlatform(new Vector3Int(col, row, 0));
                }
                startX += kTileSize;
            }
            startY += kTileSize;
        }


    }

    void SpawnPlatform(Vector3Int position)
    {
        //GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);
        //platform.transform.localScale = scale;
        var tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = obstacleSprite;

        tilemap.SetTile(position, tile);
    }
}

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
