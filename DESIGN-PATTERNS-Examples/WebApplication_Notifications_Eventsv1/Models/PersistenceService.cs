namespace WebApplication_Notifications_Events.Models
{
    public delegate void NotifyOnSave(string message);

    public class PersistenceService
    {
        public event NotifyOnSave OnSave;

        public void Save()
        {
            System.Diagnostics.Debug.WriteLine("Ejecutando operación de guardado!");
            Thread.Sleep(1500);
            OnSave?.Invoke("Ejecución de guardado exitosa!");
        }
    }
}
