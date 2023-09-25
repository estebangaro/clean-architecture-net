using EdiRequests;
using EF_SQLSERVER_EDI_COMMANDS.Context;
using Mediator;
using System.Diagnostics;

namespace EF_SQLSERVER_EDI_COMMANDS.Handlers
{
    public class EdiTransactionDeleteHandler : IRequestHandler<DeleteEdiTransaction>
    {
        //private readonly EdiContext context;

        //public EdiTransactionDeleteHandler(EdiContext ediContext)
        //{
        //    context = ediContext;
        //}

        public Task Handle(DeleteEdiTransaction request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            using (var context = new EdiContext())
            {
                var ediTran2Del = context.EdiTransactionsCatalogs.FirstOrDefault(ediTran => ediTran.Id == request.Id);
                if (ediTran2Del != null)
                {
                    Debug.WriteLine($"Eliminar el producto {ediTran2Del.Id}");
                    context.EdiTransactionsCatalogs.Remove(ediTran2Del);
                    context.SaveChanges();
                }
                else
                {
                    Debug.WriteLine($"No hay producto {ediTran2Del.Id}");
                }
            }

            return Task.CompletedTask;
        }
    }
}