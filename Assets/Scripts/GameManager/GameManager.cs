using System;
using UnityEngine.InputSystem;

public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    public event Action PauseEvent;
    public event Action UnpauseEvent;

    bool pause = false;

    IState nextState = null;
    IState currentState = null;


    // Start is called before the first frame update
    void Start()
    {
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
       


    void PauseGame()
    {
        if(PauseEvent != null)
            PauseEvent();
    }

    void UnpauseGame()
    {
        if (UnpauseEvent != null)
            UnpauseEvent();
    }
}
