
using UnityEngine;
using UnityEngine.InputSystem;

public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    internal class MenuState : IState
    {
        GameManager gm;
        public MenuState(GameManager gm)
        {
            this.gm = gm;
        }

        public void Enter()
        {
            Controller.Instance.GetControls().Player.Pause.performed += OnPause;
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
            gm.ChangeState(StatesEnum.MENU_TRANSITION_TO_GAME);
        }
    }
}
