
using UnityEngine;



public partial class GameManager : MonoBehaviour
{
    internal class GameTransitionToMenuState : IState
    {
        private GameTransitionToMenuState() { }
        public static GameTransitionToMenuState I { get; } = new GameTransitionToMenuState();

        private Vector3 start = new Vector3();
        private Vector3 target = new Vector3();
        private float timer = 0.0f;
        private float duration = 1.0f;

        public void Enter(GameManager gm)
        {
            float screenAspect = (float)Screen.width / (float)Screen.height;
            float camHeight = Camera.main.orthographicSize * 2;
            start = Services.cam.transform.position;
            target = Services.cam.transform.position - new Vector3(0, camHeight, 0);
        }

        public void Exit(GameManager gm)
        {
            
        }

        public void Run(GameManager gm)
        {
            timer += Time.deltaTime;
            Services.cam.transform.position = Vector3.Lerp(start, target, timer / duration);
            if ( timer >= duration)
            {
                // there is no menu state
                gm.ChangeState(null);
            }
        }
    }
}
