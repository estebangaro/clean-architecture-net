using SOLID.ValueObject;

namespace SOLID.Open_Closed_Principle
{
    //Clase encargada de solicitar la escritura de información de log mediante el control de la abstracción ILogger.
    public class LogService
    {
        readonly ILogger _logger;

        public LogService(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(Activity activity)
        {
            _logger.Write(activity);
        }
    }
}