using System;
using System.Collections.Generic;
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

    enum StatesEnum {
        GAME,
        GAME_TRANSITION_TO_MENU,
        MENU,
        MENU_TRANSITION_TO_GAME,
        MAX_STATES
    }

    private Dictionary<StatesEnum, IState> stateTable = new Dictionary<StatesEnum, IState>();

    #endregion

    float playerMaxHeight = 0.0f;

    private void Start()
    {
        // Init dictionary
        stateTable.Add(StatesEnum.GAME, new GameState(this));
        stateTable.Add(StatesEnum.GAME_TRANSITION_TO_MENU, new GameTransitionToMenuState(this));
        stateTable.Add(StatesEnum.MENU, new MenuState(this));
        stateTable.Add(StatesEnum.MENU_TRANSITION_TO_GAME, new MenuTransitionToGameState(this));

        GameObject.Find("Player").GetComponent<PlayerEvents>().ReachedNewHeightEvent += PlayerReachedNewHeight;
        ChangeState(StatesEnum.GAME);
    }

    private void PlayerReachedNewHeight(float height)
    {
        playerMaxHeight = height;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
            currentState.Run();

        if(nextState != currentState)
        {
            if (currentState != null)
                currentState.Exit();

            if (nextState != null)
                nextState.Enter();
            currentState = nextState;
        }

    }

    void ChangeState(StatesEnum state)
    {
        nextState = stateTable[state];
    }
       

}
