using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{

    Game game;
    Menu menu;

    #region State Management
    IState nextState = null;
    IState currentState = null;

    enum StatesEnum {
        GAME,
        MENU,
        MAX_STATES
    }

    private Dictionary<StatesEnum, IState> stateTable = new Dictionary<StatesEnum, IState>();

    #endregion

    private void Start()
    {
        // Init dictionary
        stateTable.Add(StatesEnum.GAME, new GameState(this));
        stateTable.Add(StatesEnum.MENU, new MenuState(this));

        game = GameObject.Find("Game").GetComponent<Game>();
        menu = GameObject.Find("PauseMenu").GetComponent<Menu>();

        ChangeState(StatesEnum.MENU);
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
