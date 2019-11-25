using System;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    #region Events
    public event Action PauseGameEvent;
    public event Action UnpauseGameEvent;
    public event Action ShowMenuEvent;
    public event Action HideMenuEvent;
    #endregion

    #region State Management
    IState nextState = null;
    IState currentState = null;
    #endregion

    float playerMaxHeight = 0.0f;

    private void Start()
    {
        Controller.Instance.GetControls().Player.Pause.performed += OnPause;
        GameObject.Find("Player").GetComponent<PlayerEvents>().ReachedNewHeightEvent += PlayerReachedNewHeight;
        ChangeState(GameState.I);
    }

    private void OnPause(InputAction.CallbackContext obj)
    {
        if (currentState == GameState.I)
            ChangeState(GameTransitionToMenuState.I);
        else if (currentState == MenuState.I)
            ChangeState(MenuTransitionToGameState.I);
    }

    private void PlayerReachedNewHeight(float height)
    {
        playerMaxHeight = height;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
            currentState.Run(this);

        if(nextState != currentState)
        {
            if (currentState != null)
                currentState.Exit(this);

            if (nextState != null)
                nextState.Enter(this);
            currentState = nextState;
        }

    }

    void ChangeState(IState state)
    {
        nextState = state;
    }
       

}
