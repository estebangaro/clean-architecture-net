using SOLID.ValueObject;

namespace SOLID.Open_Closed_Principle
{
    //Clase que proporciona los detalles de implementación respecto a la escritura de información de log hacía la consola...
    public class LoggerConsole : ILogger
    {
        public void Write(Activity activity)
        {
            Console.WriteLine($"Actividad: {activity.ActivityName}, " +
                $"Fecha: {activity.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")}, Método: {activity.Method}, " +
                $"Mensaje: {activity.Message}");
        }
    }
}