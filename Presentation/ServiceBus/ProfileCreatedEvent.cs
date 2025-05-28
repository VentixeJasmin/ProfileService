namespace Presentation.ServiceBus;

public class ProfileCreatedEvent
{
    public string UserName { get; set; } = null!;
    public string EventType { get; set; } = "ProfileCreated";
}
