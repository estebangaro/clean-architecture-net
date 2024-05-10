

namespace Services.Loggers
{
    public class LoggerConsole : Interfaces.ILogger
    {
        public void Log_Activity(Interfaces.DTO.Activity activity)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} - {activity}");
        }
    }
}
