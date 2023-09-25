using EdiRequests;
using Mediator;
using Microsoft.Data.SqlClient;

namespace EF_SQLSERVER_EDI_COMMANDS.Handlers
{
    public class EdiTransactionDeleteHandler : IRequestHandler<DeleteEdiTransaction>
    {
        public Task Handle(DeleteEdiTransaction request, CancellationToken cancellationToken)
        {
            using (SqlConnection sqlConnection = new SqlConnection("Server=.;Database=Pruebas;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand =
                    new SqlCommand("DELETE EdiTransactionsCatalog WHERE Id = @Id", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", request.Id);

                    sqlCommand.ExecuteNonQuery();

                    return Task.CompletedTask;
                }
            }
        }
    }
}