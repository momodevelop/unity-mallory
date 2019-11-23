using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    interface IState
    {
        void Enter(GameManager gm);
        void Run(GameManager gm);
        void Exit(GameManager gm);
    }
}
