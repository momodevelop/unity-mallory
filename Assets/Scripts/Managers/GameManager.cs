using System;
using UnityEngine.InputSystem;

public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{


    IState nextState = null;
    IState currentState = null;


    // Start is called before the first frame update
    void Start()
    {
       
    }



    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
            currentState.Run(this);

        if(nextState != currentState)
        {
            currentState.Exit(this);
            nextState.Enter(this);
            currentState = nextState;
        }

    }

    void ChangeState(IState state)
    {
        nextState = state;
    }
       


}
