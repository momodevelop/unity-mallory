using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour{

    public event Action onTriggerEnterEvent;

    // Start is called before the first frame update
    void Awake()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHeight = Camera.main.orthographicSize * 2;
        float camWidth = screenAspect * camHeight;

        this.transform.position = new Vector3(Camera.main.transform.position.x, 0.0f);
        this.transform.localScale = new Vector3(camWidth * 100, 96);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
//        onTriggerEnterEvent();
    }

    public void SetY(float y)
    {
        transform.position = new Vector2(transform.position.x, y);
    }


   
}
