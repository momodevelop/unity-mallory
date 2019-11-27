using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
            Controller.Instance.GetControls().Player.Up.performed += OnUp;
            Controller.Instance.GetControls().Player.Down.performed += OnDown;
            Controller.Instance.GetControls().Player.Jump.performed += OnConfirm;
            gm.game.Pause();
        }

        private void OnDown(InputAction.CallbackContext obj)
        {
            gm.menu.OnDown();
        }

        private void OnUp(InputAction.CallbackContext obj)
        {
            gm.menu.OnUp();
        }

        public void Exit()
        {
           
            Controller.Instance.GetControls().Player.Pause.performed -= OnPause;
            Controller.Instance.GetControls().Player.Up.performed -= OnUp;
            Controller.Instance.GetControls().Player.Down.performed -= OnDown;
            Controller.Instance.GetControls().Player.Jump.performed -= OnConfirm;
        }

        private void OnConfirm(InputAction.CallbackContext obj)
        {
            switch(gm.menu.GetSelectedIndex())
            {
                case Selector.Options.GO_TO_GAME: //
                    gm.menu.HideMenu();
                    gm.ChangeState(StatesEnum.GAME);
                    break;
                case Selector.Options.RESTART: //
                    Exit();
                    SceneManager.LoadScene("Splash");
                    break;
                case Selector.Options.QUIT: //
#if UNITY_EDITOR
                    // Application.Quit() does not work in the editor so
                    // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                    UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
                    break;
            }
        }

        public void Run()
        {
        }

        private void OnPause(InputAction.CallbackContext obj)
        {
            gm.menu.HideMenu();
            gm.ChangeState(StatesEnum.GAME);
        }

       
    }
}
