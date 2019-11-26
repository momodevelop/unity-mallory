using System;
using UnityEngine;


public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    internal class MenuTransitionToGameState : IState
    {

        private Vector3 start;
        private Vector3 target;
        private float timer = 0.0f;
        private readonly float duration = 0.25f;

        GameManager gm;
        public MenuTransitionToGameState(GameManager gm)
        {
            this.gm = gm;
        }

        public void Enter()
        {
            start = Camera.main.transform.position;
            target = new Vector3(start.x, gm.playerMaxHeight, start.z);
            timer = 0.0f;           
        }

        public void Exit()
        {
            gm.UnpauseGameEvent?.Invoke();
        }

        public void Run()
        {
            timer += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(start, target, timer / duration);
            if (timer >= duration)
            {
                gm.ChangeState(StatesEnum.GAME);
            }
        }
    }
}
