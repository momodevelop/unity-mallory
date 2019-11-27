using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
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

        foreach (CanvasRenderer cr in canvasRenderers)
            cr.SetAlpha(Mathf.Lerp(0.0f, 1.0f, timer / duration));



    }

    public void ShowMenu()
    {
        increment = -increment;
        score.text = String.Format("{0}", GameManager.I.GetScore());
        selector.enabled = true;

        Controller.Instance.GetControls().Player.Up.performed += OnUp;
        Controller.Instance.GetControls().Player.Down.performed += OnDown;

    }

    public void HideMenu()
    {
        Controller.Instance.GetControls().Player.Up.performed -= OnUp;
        Controller.Instance.GetControls().Player.Down.performed -= OnDown;

        increment = -increment;
        selector.enabled = false;
    }

    public void OnUp(InputAction.CallbackContext obj)
    {
        selector.SelectionUp();
    }

    public void OnDown(InputAction.CallbackContext obj)
    {
        selector.SelectionDown();
    }

    public Selector.Options GetSelectedIndex()
    {
        return selector.GetSelectedIndex();
    }
}
