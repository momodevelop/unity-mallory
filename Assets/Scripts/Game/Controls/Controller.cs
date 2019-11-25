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
