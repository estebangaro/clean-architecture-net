namespace Notifications
{
    public interface INotificationHandler
    {
        void Handle(string message);
    }
}
