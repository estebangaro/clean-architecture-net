using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Notifications_Eventsv1.Models.NotificationHandlers
{
    internal class NotificationHandler3: NotificationHandlerBase
    {
        public override void ReceiveMessage(string message)
        {
            base.ReceiveMessage(message);
            Console.WriteLine(GetGreeting(message));
        }
    }
}
