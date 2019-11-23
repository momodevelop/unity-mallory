using UnityEngine;

public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    interface IState
    {
        void Enter(GameManager gm);
        void Run(GameManager gm);
        void Exit(GameManager gm);
    }
}
