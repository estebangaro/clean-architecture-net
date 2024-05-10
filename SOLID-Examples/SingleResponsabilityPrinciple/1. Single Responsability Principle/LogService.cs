using SOLID.ValueObject;

namespace SOLID.Single_Responsability_Principle
{
    //Clase encargada del registro de información (incluyendo el formato de información)
    //de LOG en medio de almacenamiento.
    public class LogService
    {
        public void Write(Activity activity)
        {
            Console.WriteLine($"Actividad: {activity.ActivityName}, " +
                $"Fecha: {activity.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")}, Método: {activity.Method}, " +
                $"Mensaje: {activity.Message}");
        }
    }
}