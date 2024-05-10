namespace WebApplication_Notifications_Events.Models
{
    public interface INotificationHandler
    {
        void Handle(string message);
    }
}
