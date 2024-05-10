using SOLID.ValueObject;

namespace SOLID.Dependency_Inversion_Substitution_Principle
{
    public class FileLogService : ILogger
    {
        private string _fileName;
        public FileLogService(string fileName)
        {
            _fileName = fileName;
        }

        public void WriteLog(Activity activity)
        {
            File.AppendAllText(_fileName, $"{DateTime.Now} - {activity.ActivityName} - {activity.Message}.");
        }
    }
}