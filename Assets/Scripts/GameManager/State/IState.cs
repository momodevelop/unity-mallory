using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class GameManager : Momo.PersistantMonoBehaviourSingleton<GameManager>
{
    interface IState
    {
        void Enter(GameManager gm);
        void Run(GameManager gm);
        void Exit(GameManager gm);
    }
}
