using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    public PlayerEvents playerEvents;
    public RectTransform menuTransform;
    public GameState gameState;
    
    private bool isPaused = false;
    void Start()
    {
        Controller.Instance.GetControls().Player.Pause.performed += OnPause;
        playerEvents.eventPlayerDead += OnPlayerDeath;
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        if (!isPaused)
            gameState.Pause();
        else
            gameState.Unpause();

        isPaused = !isPaused;
    }

    void OnPlayerDeath()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        //menuTransform.position += new Vector3(0, 1);
    }
}
