public class Controller : Momo.PersistantMonoBehaviourSingleton<Controller>
{
    private Controls controls;

    public override void Awake()
    {
        base.Awake();
        controls = new Controls();
        controls.Enable();
        
    }

    public Controls GetControls()
    {
        return controls;
    }

    private void OnDestroy()
    {
        controls.Dispose();
    }


}
