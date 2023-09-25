namespace Notifications.Models
{
    public class Mediator : IMediator
    {
        // Declarar la variable para almacenar las
        // instancias de los manejadores de notificaciones.
        readonly IEnumerable<INotificationHandler> Handlers;

        // Obtener las instancias de los manejadores a través del constructor
        public Mediator(IEnumerable<INotificationHandler> handlers) =>
        Handlers = handlers;

        // Publicar la notificación
        public void Publish(string message) =>
        Handlers.ToList().ForEach(h => h.Handle(message));
    }
}