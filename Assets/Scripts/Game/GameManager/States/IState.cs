using UnityEngine;

public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    interface IState
    {
        void Enter();
        void Run();
        void Exit();
    }
}
