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

    #region Constants
    const float kTileSize = 100.0f;
    const float kPixelPerUnit = 100.0f;
    const float kActualTileSize = kTileSize / kPixelPerUnit;
    #endregion

    float currentY = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        DestroyIfNull(obstaclePrefab);
        DestroyIfNull(levelEndTrigger);
        DestroyIfNull(camera);


        // Observe level end trigger box event
        levelEndTrigger.onTriggerEnterEvent += OnLevelEndTrigger;

        // Generate the first level
        GenerateLevel(20, 20, 2, 4, 1, 4, 4, 50, true);
    }

    private void OnLevelEndTrigger()
    {
        GenerateLevel(20, 12, 2, 4, 1, 4, 4, 50, false);
    }


    private void GenerateLevel(int width, int height, int 
        minBlockWidth, int maxBlockWidth, 
        int minBlockHeight, int maxBlockHeight, 
        int sectionHeight, int chanceToPlaceBlock, 
        bool floor)
    {
        int[,] map = LevelGenerator.GenerateLevel(
           width,
           height,
           minBlockWidth,
           maxBlockWidth,
           minBlockHeight,
           maxBlockHeight,
           sectionHeight,
           chanceToPlaceBlock,
           floor
        );

        // populate the map with platforms
       
        float startY = currentY;
        for (int i = 0; i < map.GetLength(1); ++i)
        {
            float startX = 0.5f;
            for (int j = 0; j < map.GetLength(0); ++j)
            {
                if (map[i, j] == 1)
                {
                    GameObject obj = Instantiate(obstaclePrefab, new Vector2(startX, startY), Quaternion.identity);
                    SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
                    obj.transform.localScale = new Vector2(1, 1);
                }
                startX += 1.0f;
            }
            startY += 1.0f;
        }


        float newLevelEndY = currentY + (height / 2);
        currentY += height;
       
        // set the end level box
        levelEndTrigger.transform.position = new Vector2(levelEndTrigger.transform.position.x, newLevelEndY);
    }


    private void DestroyIfNull<T>(T obj)
    {
        if (obj == null)
            Destroy(this);
    }


}

