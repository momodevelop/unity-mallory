using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager
{
    public event Action PauseEvent;
    public event Action UnpauseEvent;

    bool pause = false;

    public static PauseManager I { get; } = new PauseManager();

    private PauseManager() {
        Controller.Instance.GetControls().Player.Pause.performed += OnPause;
    }

    private void OnPause(InputAction.CallbackContext obj)
    {
        if (!pause)
            PauseGame();
        else
            UnpauseGame();
        pause = !pause;
    }


    void PauseGame()
    {
        if (PauseEvent != null)
            PauseEvent();
    }

    void UnpauseGame()
    {
        if (UnpauseEvent != null)
            UnpauseEvent();
    }

}
