using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomHell : MonoBehaviour
{
    float playerMaxHeight;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 camPosition = Camera.main.transform.position;
        this.transform.localScale = new Vector3(Utils.GetCameraWidthPixels(), Utils.GetCameraHeightPixels());
        GameObject.Find("Player").GetComponent<PlayerEvents>().ReachedNewHeightEvent += PlayerReachedNewHeight;
    }

    private void PlayerReachedNewHeight(float height)
    {
        playerMaxHeight = height;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 camPosition = Camera.main.transform.position;
        this.transform.position = new Vector3(camPosition.x, playerMaxHeight - Utils.GetCameraHeight(), -1);
    }
}
