using System;
using UnityEngine.InputSystem;


public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    class GameTransitionToMenuState : IState
    {
        private GameTransitionToMenuState() { }
        public static GameTransitionToMenuState I { get; } = new GameTransitionToMenuState();

        public void Enter(GameManager gm)
        {
        }

        public void Exit(GameManager gm)
        {
        }

        public void Run(GameManager gm)
        {
            
        }
    }
}
