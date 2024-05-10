namespace WebApplication_Notifications_Events.Models
{

    public class PersistenceService
    {
        IMediator _mediator;

        public PersistenceService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Save()
        {
            System.Diagnostics.Debug.WriteLine("Ejecutando operación de guardado!");
            Thread.Sleep(1500);
            _mediator.Publish("Ejecución de guardado exitosa!");
        }
    }
}
