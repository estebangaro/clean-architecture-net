using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Notifications_Eventsv1.Entities
{
    internal interface IMediator
    {
        public void Publish(string message);
    }
}
