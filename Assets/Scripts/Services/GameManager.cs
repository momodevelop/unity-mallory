using System;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    IState nextState = null;
    IState currentState = null;

    float playerMaxHeight = 0.0f;

    private void Start()
    {
        Services.pauseManager.PauseEvent += Pause;
        Services.player.GetComponent<PlayerEvents>().ReachedNewHeightEvent += PlayerReachedNewHeight;
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
       
    void Pause()
    {
        ChangeState(GameTransitionToMenuState.I);
    }


}
