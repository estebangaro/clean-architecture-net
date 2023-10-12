using EDI_REQUESTS;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ADONET_SQLSERVER_EDI_COMMANDS.Handlers
{
    public class EdiTransactionLogHandler_DB : MediatR.INotificationHandler<CreateEdiTransactionLog>
    {
        public async Task Handle(CreateEdiTransactionLog notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Ejecutando \"EdiTransactionLogHandler_DB\"");
            using (SqlConnection sqlConnection = new SqlConnection("Server=.;Database=Pruebas;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand =
                    new SqlCommand("INSERT INTO EdiTransactionsLogs (Message, Type, CreateDate) VALUES (@Message, @Type, @CreateDate)", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Message", notification.Message);
                    sqlCommand.Parameters.AddWithValue("@Type", notification.Type);
                    sqlCommand.Parameters.AddWithValue("@CreateDate", DateTime.Now);

                    _ = await sqlCommand.ExecuteNonQueryAsync();


                }
            }
        }
    }
}
