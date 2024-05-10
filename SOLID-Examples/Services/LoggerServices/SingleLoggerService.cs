namespace Services.LoggerServices
{
    public class SingleLoggerService : Interfaces.ILoggerService
    {
        private readonly Interfaces.ILogger _logger;

        public SingleLoggerService(Interfaces.ILogger logger)
        {
            _logger = logger;
        }

        public void Log(Interfaces.DTO.Activity activity)
        {
            _logger.Log_Activity(activity);
        }
    }
}