using System.Diagnostics;

namespace Notifications.Models
{
    public abstract class NotificationHandlerBase : INotificationHandler
    {
        public virtual void Handle(string message)
        {
            Debug.WriteLine($"{this.GetType()} => {message}");
        }
    }
}