

namespace Services.LoggerServices
{
    public class MultipleLoggerService : Interfaces.ILoggerService
    {
        private readonly IEnumerable<Interfaces.ILogger> _loggers;

        public MultipleLoggerService(IEnumerable<Interfaces.ILogger> loggers)
        {
            _loggers = loggers;
        }

        public void Log(Interfaces.DTO.Activity activity)
        {
            foreach (var logger in _loggers)
            {
                logger.Log_Activity(activity);
            }
        }
    }
}
