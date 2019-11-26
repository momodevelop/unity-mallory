
using UnityEngine;



public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    internal class GameTransitionToMenuState : IState
    {
        GameManager gm;
        public GameTransitionToMenuState(GameManager gm)
        {
            this.gm = gm;
        }

        private Vector3 start;
        private Vector3 target;
        private float timer = 0.0f;
        private readonly float duration = 0.25f;

        public void Enter()
        {
            float camHeight = Camera.main.orthographicSize * 2;
            start = Camera.main.transform.position;
            target = Camera.main.transform.position - new Vector3(0, camHeight, 0);
            timer = 0.0f;
            gm.PauseGameEvent?.Invoke();
        }

        public void Exit()
        {
            
        }

        public void Run()
        {
            timer += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(start, target, timer / duration);
            if ( timer >= duration)
            {
                gm.ChangeState(StatesEnum.MENU);
            }
        }
    }
}
