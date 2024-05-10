using SOLID.ValueObject;

namespace SOLID.Open_Closed_Principle
{
    //Clase encargada de registrar información de log en diferentes medios de almacenamiento...
    public class LogService_Error
    {
        public void Write(Activity activity, string target)
        {
            switch (target)
            {
                case "console":
                    WriteToConsole(activity);
                    break;
                case "debugconsole":
                    WriteToDebugConsole(activity);
                    break;
                    //Próximas implementaciones...
            }
        }

        private void WriteToConsole(Activity activity)
        {
            Console.WriteLine($"Actividad: {activity.ActivityName}, " +
                $"Fecha: {activity.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")}, Método: {activity.Method}, " +
                $"Mensaje: {activity.Message}");
        }

        private void WriteToDebugConsole(Activity activity)
        {
            System.Diagnostics.Debug.WriteLine($"Actividad: {activity.ActivityName}, " +
                $"Fecha: {activity.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")}, Método: {activity.Method}, " +
                $"Mensaje: {activity.Message}");
        }
    }
}