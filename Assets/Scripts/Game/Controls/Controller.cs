public class Controller : Momo.PersistantMonoBehaviourSingleton<Controller>
{
    private Controls controls;

    private void Awake()
    {
        base.Awake();
        controls = new Controls();
        controls.Enable();
    }

    public Controls GetControls()
    {
        return controls;
    }
}
