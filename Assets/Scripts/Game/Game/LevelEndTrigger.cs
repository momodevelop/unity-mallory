using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour, IPauseable
{

    public event Action onTriggerEnterEvent;

    // Start is called before the first frame update
    void Awake()
    {
        this.transform.position = new Vector3(Camera.main.transform.position.x, 0.0f);
        this.transform.localScale = new Vector3(Utils.GetCameraWidthPixels(), Utils.GetPixelPerUnit());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnterEvent();
    }

    public void SetY(float y)
    {
        transform.position = new Vector2(transform.position.x, y);
    }

    public void Pause()
    {
        this.gameObject.SetActive(false);
    }

    public void Unpause()
    {
        this.gameObject.SetActive(true);
    }
}
