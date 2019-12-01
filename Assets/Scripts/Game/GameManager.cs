using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Momo;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.I.Events.TriggerEvent("pause", null);
        EventManager.I.Events.StartListening("game_restart", RestartGame);
        EventManager.I.Events.StartListening("game_quit", QuitGame);

    }

    private void QuitGame(object obj)
    {
        Application.Quit();
    }

    private void RestartGame(object obj)
    {
        SceneManager.LoadScene("JumpMan");
    }

    float timer = 0.0f;
    
    private void Update()
    {
        //timer += Time.deltaTime;
        //SimpleBlit blitScript = Camera.main.GetComponent<SimpleBlit>();
        //blitScript.TransitionMaterial.SetFloat("_Cutoff", timer);
    }
}


