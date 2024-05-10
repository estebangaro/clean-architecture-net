namespace WebApplication_Notifications_Events.Models
{
    public interface IMediator
    {
        void Publish(string message);
    }
}
