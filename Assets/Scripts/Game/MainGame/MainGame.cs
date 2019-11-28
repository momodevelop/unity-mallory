using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainGame : MonoBehaviour
{
    Transform player;
    int score = 0;

    void Awake()
    {
        player = this.transform.Find("Player");

        

        EventManager.I.Events.StartListening("pause", Pause);
        EventManager.I.Events.StartListening("unpause", Unpause);
    }

    private void Unpause(object obj)
    {
        Controller.I.GetControls().Player.Pause.performed += PauseGame;
    }

    private void Pause(object obj)
    {
        Controller.I.GetControls().Player.Pause.performed -= PauseGame;
    }

    private void PauseGame(InputAction.CallbackContext obj)
    {
        EventManager.I.Events.TriggerEvent("pause", null);
    }

    public void UpdateScore()
    {
        // score keeping
        if (player.position.y > Camera.main.transform.position.y)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, player.position.y, Camera.main.transform.position.z);
            ++score;
        }
    }



}
