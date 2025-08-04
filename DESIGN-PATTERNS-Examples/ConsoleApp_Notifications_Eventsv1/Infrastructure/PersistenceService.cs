using ConsoleApp_Notifications_Eventsv1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Notifications_Eventsv1.Infrastructure
{
    internal class PersistenceService
    {
        IMediator mediator;

        public PersistenceService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Save()
        {
            Thread.Sleep(1500); //simulamos una operación de escritura...

            mediator.Publish($"Se ha registrado exitosamente la información. Estatus: OK. Fecha Registro: {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}");
        }
    }
}
