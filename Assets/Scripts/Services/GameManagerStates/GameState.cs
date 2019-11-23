
using UnityEngine;



public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    internal class GameState : IState
    {
        private GameState() { }
        public static GameState I { get; } = new GameState();

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
