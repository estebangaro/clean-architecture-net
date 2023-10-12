using EDI_REQUESTS;
using EF_SQLSERVER_EDI_COMMANDS.Context;

namespace EF_SQLSERVER_EDI_COMMANDS.Handlers
{
    public class EdiTransactionLogHandler_DB : MediatR.INotificationHandler<CreateEdiTransactionLog>
    {
        private readonly EdiContext context;

        public EdiTransactionLogHandler_DB(EdiContext context)
        {
            this.context = context;
        }

        public async Task Handle(CreateEdiTransactionLog notification, CancellationToken cancellationToken)
        {
            this.context.EdiTransactionsLogs.Add(new Models.EdiTransactionsLog
            {
                CreateDate = DateTime.Now,
                Message = notification.Message,
                Type = notification.Type,
            });
            await this.context.SaveChangesAsync();
        }
    }
}
