using EdiRequests;
using Microsoft.Data.SqlClient;

namespace EF_SQLSERVER_EDI_COMMANDS.Handlers
{
    public class EdiTransactionCreateHandler : Mediator.IRequestHandler<CreateEdiTransaction, int>
    {
        public async Task<int> Handle(CreateEdiTransaction request, CancellationToken cancellationToken)
        {
            using (SqlConnection sqlConnection = new SqlConnection("Server=.;Database=Pruebas;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand =
                    new SqlCommand("INSERT INTO EdiTransactionsCatalog (Type, Name, Description) VALUES (@Type, @Name, @Description)", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Type", request.Type);
                    sqlCommand.Parameters.AddWithValue("@Name", request.Name);
                    sqlCommand.Parameters.AddWithValue("@Description", request.Description);

                    _ = await sqlCommand.ExecuteNonQueryAsync();

                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = "Select @@IDENTITY as ID;";

                    var reader = sqlCommand.ExecuteReader();
                    int identity = 0;
                    while (reader.Read())
                    {
                        identity = Convert.ToInt32(reader["ID"]);
                    }

                    return identity;
                }
            }
        }
    }
}