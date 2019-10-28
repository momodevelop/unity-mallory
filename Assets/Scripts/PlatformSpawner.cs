using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo;

public class PlatformSpawner : Momo.PersistantMonoBehaviourSingleton<PlatformSpawner>
{
    public GameObject platformPrefab;

    private float height = 0.0f;

    const float kTileSize = 48.0f;
    const float kGlobalPixelPerUnit = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateLevel()
    {
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = (worldScreenHeight / Screen.height) * Screen.width;

        // Spawn the floor
        SpawnPlatform(new Vector2(0.0f, height), new Vector2(worldScreenWidth * kGlobalPixelPerUnit, kTileSize));

    }

    void SpawnPlatform(Vector2 position, Vector2 scale)
    {
        GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);
        platform.transform.localScale = scale;
    }
}
