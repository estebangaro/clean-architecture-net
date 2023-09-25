using Notifications.Models.EFCore;

namespace Notifications.Models.Services
{
    public class PersistenceService
    {
        // Declarar la variable para almacenar la instancia de Mediator
        readonly IMediator Mediator;
        // Obtener la instancia de Mediator
        public PersistenceService(IMediator mediator) =>
        Mediator = mediator;
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
            Mediator.Publish("SaveChanges");
        }
    }
}