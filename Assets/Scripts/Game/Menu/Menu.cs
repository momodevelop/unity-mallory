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

    Selector selector;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        canvasRenderers = GetComponentsInChildren<CanvasRenderer>();
        selector = GameObject.Find("Selector").GetComponent<Selector>();
        score = GameObject.Find("Score").GetComponent<Text>();
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
        score.text = String.Format("{0}", GameManager.I.GetScore());
    }

    public void HideMenu()
    {
        increment = -increment;
    }
    
    public void OnUp()
    {
        selector.SelectionUp();
    }

    public void OnDown()
    {
        selector.SelectionDown();
    }

    public Selector.Options GetSelectedIndex()
    {
        return selector.GetSelectedIndex();
    }
}
