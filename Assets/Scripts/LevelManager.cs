using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class LevelManager : Momo.PersistantMonoBehaviourSingleton<LevelManager>
{

    #region Drag and Drop
    public GameObject obstaclePrefab;
    [SerializeField]
    public LevelEndTrigger levelEndTrigger;

    [SerializeField]
    Camera camera = null;
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


   
    #endregion

    #region Constants
    const float kTileSize = 96;
    const float kPixelPerUnit = 100.0f;
    const float kActualTileSize = kTileSize / kPixelPerUnit;
    #endregion

    LevelData levelData;
    float currentY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        DestroyIfNull(obstaclePrefab);
        DestroyIfNull(levelEndTrigger);
        DestroyIfNull(camera);


        // Observe level end trigger box event
        levelEndTrigger.onTriggerEnterEvent += OnReachedEndpoint;
        
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
        JumpCurrentY();
        SyncEndpoint();
    }

    private void JumpCurrentY()
    {
        currentY += levelData.Height * kActualTileSize;
    }
    private void OnReachedEndpoint()
    {
        GenerateLevel(false);
        JumpCurrentY();
        SyncEndpoint();
    }

    private void SyncEndpoint()
    {
        levelEndTrigger.transform.position = new Vector2(levelEndTrigger.transform.position.x, currentY + kActualTileSize * 2);
    }

    private void GenerateLevel(bool floor = true)
    {
        int[,] map = LevelGenerator.GenerateLevel(
            levelData.Width,
            levelData.Height,
            levelData.MinBlockWidth,
            levelData.MaxBlockWidth,
            levelData.MinBlockHeight,
            levelData.MaxBlockHeight,
            levelData.SectionHeight,
            levelData.ChanceToPlaceBlock,
            floor
        );

        // populate the map with platforms
       
        float startY = currentY + kActualTileSize / 2;
        for (int i = 0; i < map.GetLength(1); ++i)
        {
            float startX = kActualTileSize / 2;
            for (int j = 0; j < map.GetLength(0); ++j)
            {
                if (map[i, j] == 1)
                {
                    GameObject obj = Instantiate(obstaclePrefab, new Vector2(startX, startY), Quaternion.identity);
                    SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
                    obj.transform.localScale = new Vector2(kActualTileSize, kActualTileSize);
                }
                startX += kActualTileSize;
            }
            startY += kActualTileSize;
        }

        // set the end level box
        
    }


    private void DestroyIfNull<T>(T obj)
    {
        if (obj == null)
            Destroy(this);
    }


}

