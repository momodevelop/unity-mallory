using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenu : MonoBehaviour
{

    float timer = 0.1f;
    float duration = 0.1f;
    float increment = 1.0f;

    CanvasGroup canvasGroup;
    Selector selector;
    Text scoreText;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        selector = this.transform.Find("Selector").GetComponent<Selector>();
        scoreText = this.transform.Find("Score").GetComponent<Text>();

        EventManager.I.Events.StartListening("pause", ShowMenu);
        EventManager.I.Events.StartListening("unpause", HideMenu);
    }

    private void ExitPauseMenu(InputAction.CallbackContext obj)
    {
        EventManager.I.Events.TriggerEvent("unpause", null);
    }

    private void Update()
    {
        timer += increment * Time.deltaTime;
        if (timer >= duration)
            timer = duration;
        if (timer <= 0.0f)
            timer = 0.0f;

        canvasGroup.alpha = Mathf.Lerp(0.0f, 1.0f, timer / duration);

    }

    public void ShowMenu(object o)
    {
        increment = 1;
        Controller.I.GetControls().Player.Pause.performed += ExitPauseMenu;
    }

    public void HideMenu(object o)
    {
        increment = -1;
        Controller.I.GetControls().Player.Pause.performed -= ExitPauseMenu;
    }
}
