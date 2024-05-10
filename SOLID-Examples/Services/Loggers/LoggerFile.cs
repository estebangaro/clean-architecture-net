
namespace Services.Loggers
{
    public class LoggerFile : Interfaces.ILogger
    {
        public void Log_Activity(Interfaces.DTO.Activity activity)
        {
            File.AppendAllText("log.txt", $"{activity.ToString()}{Environment.NewLine}");
        }
    }
}