
using UnityEngine;



public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    internal class GameTransitionToMenuState : IState
    {
        private GameTransitionToMenuState() { }
        public static GameTransitionToMenuState I { get; } = new GameTransitionToMenuState();

        private Vector3 start;
        private Vector3 target;
        private float timer = 0.0f;
        private readonly float duration = 0.5f;

        public void Enter(GameManager gm)
        {
            float screenAspect = (float)Screen.width / (float)Screen.height;
            float camHeight = Camera.main.orthographicSize * 2;
            start = Camera.main.transform.position;
            target = Camera.main.transform.position - new Vector3(0, camHeight, 0);
            timer = 0.0f;
            gm.PauseGameEvent?.Invoke();
        }

        public void Exit(GameManager gm)
        {
            gm.ChangeState(MenuState.I);
        }

        public void Run(GameManager gm)
        {
            timer += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(start, target, timer / duration);
            if ( timer >= duration)
            {
                // there is no menu state
                gm.ChangeState(MenuState.I);
            }
        }
    }
}
