using System;
using UnityEngine;


public partial class GameManager : MonoBehaviour
{
    internal class MenuTransitionToGameState : IState
    {
        private MenuTransitionToGameState() { }
        public static MenuTransitionToGameState I { get; } = new MenuTransitionToGameState();
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
