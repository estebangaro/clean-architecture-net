using EDI_REQUESTS;
using System.Diagnostics;

namespace ADONET_SQLSERVER_EDI_COMMANDS.Handlers
{
    public class EdiTransactionsLogHandler_TXT : MediatR.INotificationHandler<EDI_REQUESTS.CreateEdiTransactionLog>
    {
        public string? BaseDirectory => Environment.GetEnvironmentVariable("LogHandlerBaseDirectory");

        public Task Handle(CreateEdiTransactionLog notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Ejecutando \"EdiTransactionsLogHandler_TXT\"");
            if (string.IsNullOrEmpty(BaseDirectory))
            {
                throw new NotSupportedException();
            }

            using (var fs = File.OpenWrite(Path.Combine(BaseDirectory, $"editransactionslog_{DateTime.Today.ToString("yyyy-MM-dd")}.txt")))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(notification);
                }
            }

            return Task.CompletedTask;
        }
    }
}