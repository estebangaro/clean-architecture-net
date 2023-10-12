using EdiRequests;
using EF_SQLSERVER_EDI_COMMANDS.Context;
using System.Diagnostics;

namespace EF_SQLSERVER_EDI_COMMANDS.Handlers
{
    public class EdiTransactionCreateHandler : Mediator.IRequestHandler<CreateEdiTransaction, int>
    {
        //private readonly EdiContext context;

        //public EdiTransactionCreateHandler(EdiContext ediContext)
        //{
        //    context = ediContext;
        //}

        public async Task<int> Handle(CreateEdiTransaction request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            using (var context = new EdiContext())
            {
                Debug.WriteLine($"Crear el producto {request.Name}");
                var ediTransaction = new Models.EdiTransactionsCatalog
                {
                    Type = request.Type,
                    Name = request.Name,
                    Description = request.Description
                };
                context.EdiTransactionsCatalogs.Add(ediTransaction);
                _ = await context.SaveChangesAsync();

                return ediTransaction.Id;
            }
        }
    }
}