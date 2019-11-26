using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    float timer = 0.1f;
    float duration = 0.1f;
    float increment = 1.0f;

    CanvasRenderer[] canvasRenderers;

    // Start is called before the first frame update
    void Start()
    {
        canvasRenderers = GetComponentsInChildren<CanvasRenderer>();

    }


    private void Update()
    {
        timer += increment * Time.deltaTime;
        if (timer >= duration)
            timer = duration;
        if (timer <= 0.0f)
            timer = 0.0f;

        foreach(CanvasRenderer cr in canvasRenderers) 
            cr.SetAlpha(Mathf.Lerp(0.0f, 1.0f, timer / duration));

    }

    public void ShowMenu()
    {
        increment = -increment;
    }

    

    public void HideMenu()
    {
        increment = -increment;
    }

    



}
