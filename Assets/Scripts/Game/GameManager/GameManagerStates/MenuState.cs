
using UnityEngine;



public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    internal class MenuState : IState
    {
        private MenuState() { }
        public static MenuState I { get; } = new MenuState();
        public void Enter(GameManager gm)
        {
            gm?.ShowMenuEvent.Invoke();

        }

        public void Exit(GameManager gm)
        {
        }

        public void Run(GameManager gm)
        {
        }
    }
}
