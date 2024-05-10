using SOLID.ValueObject;

namespace SOLID.Dependency_Inversion_Substitution_Principle
{
    public class ConsoleLogService : ILogger
    {
        public void WriteLog(Activity activity)
        {
            Console.WriteLine($"{DateTime.Now} - {activity.ActivityName} - {activity.Message}.");
        }
    }
}