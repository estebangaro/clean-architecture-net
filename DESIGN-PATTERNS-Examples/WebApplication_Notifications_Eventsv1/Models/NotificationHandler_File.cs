namespace WebApplication_Notifications_Events.Models
{
    public class NotificationHandler_File
    {
        const string fileName = "logs.txt";
        public void Handle(string message) => File.AppendAllLines(Path.Combine(AppContext.BaseDirectory, fileName), [$"Mensaje desde {this.GetType()} - {message}"]);
    }
}
