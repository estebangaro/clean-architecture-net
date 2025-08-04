using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Notifications_Eventsv1.Models
{
    internal class MessageHubMediator : Entities.IMediator
    {
        IEnumerable<Entities.INotificacionHandler> handlers;

        public MessageHubMediator(IEnumerable<Entities.INotificacionHandler> handlers)
        {
            this.handlers = handlers;
        }

        public void Publish(string message)
        {
            foreach (var item in handlers)
            {
                try
                {
                    item.ReceiveMessage(message);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ha ocurrido una excepción al enviar el mensaje al manejador \"{item.GetType()}\". Error: {ex.Message}.");
                }
            }
        }
    }
}
