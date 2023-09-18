using Notifications.Models.EFCore;
using Notifications.Models.NotificationHandlers;

namespace Notifications.Models.Services
{
    public class PersistenceService
    {
        // Declarar las variables para almacenar las
        // instancias de los manejadores de notificaciones.
        readonly NotificationHandler1 Handler1;
        readonly NotificationHandler2 Handler2;
        readonly NotificationHandler3 Handler3;
        // Obtener las instancias de los manejadores a través del constructor
        public PersistenceService(NotificationHandler1 handler1,
        NotificationHandler2 handler2, NotificationHandler3 handler3) =>
        (Handler1, Handler2, Handler3) = (handler1, handler2, handler3);

        // Método para guardar los cambios del usuario.
        public void SaveChanges(Emisor emisor)
        {
            // Lógica para guardar cambios
            using (EjemploContext dbContext = new EjemploContext())
            {
                dbContext.Emisors.Add(emisor);
                dbContext.SaveChanges();
            }
            // Notificar a los manejadores
            var notificationMessage = $"Emisor #{emisor.Id} registrado exitosamente!";
            Handler1.Handle(notificationMessage);
            Handler2.Handle(notificationMessage);
            Handler3.Handle(notificationMessage);
        }
    }
}