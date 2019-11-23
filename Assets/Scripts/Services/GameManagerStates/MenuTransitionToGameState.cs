using System;
using UnityEngine;


public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    internal class MenuTransitionToGameState : IState
    {
        private Vector3 start;
        private Vector3 target;
        private float timer = 0.0f;
        private readonly float duration = 0.5f;

        private MenuTransitionToGameState() { }
        public static MenuTransitionToGameState I { get; } = new MenuTransitionToGameState();
        public void Enter(GameManager gm)
        {
            start = Camera.main.transform.position;
            target = new Vector3(start.x, gm.playerMaxHeight, start.z);
            timer = 0.0f;           
        }

        public void Exit(GameManager gm)
        {
            gm.UnpauseGameEvent?.Invoke();
        }

        public void Run(GameManager gm)
        {
            timer += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(start, target, timer / duration);
            if (timer >= duration)
            {
                // there is no menu state
                gm.ChangeState(GameState.I);
            }
        }
    }
}
