using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Momo.Singleton<Controller>
{
    private Controls controls;
    
    private Controller()
    {
        controls = new Controls();
        controls.Enable();
    }

    public Controls GetControls()
    {
        return controls;
    }
}
