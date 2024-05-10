namespace WebApplication_Notifications_Events.Models
{
    public class NotificationHandler_Debug
    {
        public void Handle(string message)
        {
            System.Diagnostics.Debug.WriteLine($"Mensaje desde {this.GetType()} - {message}");
        }
    }
}
