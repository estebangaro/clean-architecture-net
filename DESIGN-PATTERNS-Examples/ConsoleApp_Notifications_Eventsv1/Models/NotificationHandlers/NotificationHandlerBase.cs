using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Notifications_Eventsv1.Models.NotificationHandlers
{
    internal abstract class NotificationHandlerBase : Entities.INotificacionHandler
    {
        protected string GetGreeting(string message) => $"Manejando mensaje desde \"{this.GetType()}\": {message}";

        public virtual void ReceiveMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine(GetGreeting(message));
        }
    }
}
