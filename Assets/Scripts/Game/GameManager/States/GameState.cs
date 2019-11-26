
using UnityEngine;
using UnityEngine.InputSystem;

public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    internal class GameState : IState
    {
        GameManager gm;
        public GameState(GameManager gm)
        {
            this.gm = gm;
        }

        public void Enter()
        {
           
            Controller.Instance.GetControls().Player.Pause.performed += OnPause;
            gm.game.Unpause();
        }

        public void Exit()
        {
            Controller.Instance.GetControls().Player.Pause.performed -= OnPause;
        }

        public void Run()
        {
        }

        private void OnPause(InputAction.CallbackContext obj)
        {
            gm.menu.ShowMenu();
            gm.ChangeState(StatesEnum.MENU);
        }


    }
}
