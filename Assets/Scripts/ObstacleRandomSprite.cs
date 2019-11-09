using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObstacleRandomSprite : MonoBehaviour
{
    [SerializeField]
    List<Sprite> sprites = new List<Sprite>();

    // Start is called before the first frame update
    void Awake()
    {
        int rand = Random.Range(0, 15);
        GetComponent<SpriteRenderer>().sprite = sprites[rand];
    }

}
