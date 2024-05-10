namespace WebApplication_Notifications_Events.Models
{
    public delegate void NotifyOnSave(string message);

    public class Mediator : IMediator
    {
        event NotifyOnSave OnPublish;

        public Mediator(IEnumerable<INotificationHandler> notificationHandlers)
        {
            if (notificationHandlers != null && notificationHandlers.Any())
            {
                foreach (var handler in notificationHandlers)
                {
                    OnPublish += handler.Handle;
                }
            }
        }

        public void Publish(string message)
        {
            OnPublish?.Invoke(message);
        }
    }
}
