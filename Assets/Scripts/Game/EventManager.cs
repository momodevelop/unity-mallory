
public class EventManager : Momo.PersistantMonoBehaviourSingleton<EventManager>
{
    public Momo.EventManager<string, object> Events { get; } = new Momo.EventManager<string, object>();
}
