using EdiRequests;
using MediatR;
using System.Text;

namespace EF_SQLSERVER_EDI_COMMANDS.Behaviors
{
    public class EdiTransactionCreateValidationBehavior :
        IPipelineBehavior<CreateEdiTransaction, int>
    {
        public Task<int> Handle(CreateEdiTransaction request,
            RequestHandlerDelegate<int> next,
            CancellationToken cancellationToken)
        {
            if (request != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (string.IsNullOrEmpty(request.Description))
                {
                    stringBuilder.AppendLine($"La descripción de la transacción EDI es obligatoria.");
                }
                if (string.IsNullOrEmpty(request.Name))
                {
                    stringBuilder.AppendLine($"El nombre de la transacción EDI es obligatoria.");
                }
                if (string.IsNullOrEmpty(request.Type))
                {
                    stringBuilder.AppendLine($"El tipo de la transacción EDI es obligatoria.");
                }

                if (stringBuilder.Length > 0)
                {
                    throw new ArgumentException(stringBuilder.ToString());
                }
            }
            else
            {
                throw new ArgumentException("Se debe proporcionar la información de transacción EDI a registrar.");
            }

            return next();
        }
    }
}