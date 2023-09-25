using Notifications.Models.NotificationHandlers;

namespace Notifications.Models
{
    public class Mediator
    {
        // Declarar las variables para almacenar las
        // instancias de los manejadores de notificaciones.
        readonly NotificationHandler1 Handler1;
        readonly NotificationHandler2 Handler2;
        readonly NotificationHandler3 Handler3;
        // Obtener las instancias de los manejadores a través del constructor
        public Mediator(NotificationHandler1 handler1,
        NotificationHandler2 handler2, NotificationHandler3 handler3) =>
        (Handler1, Handler2, Handler3) = (handler1, handler2, handler3);
        // Publicar la notificación
        public void Publish(string message)
        {
            Handler1.Handle(message);
            Handler2.Handle(message);
            Handler3.Handle(message);
        }
    }
}
