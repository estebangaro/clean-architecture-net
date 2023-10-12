using MediatR;

namespace EDI_REQUESTS
{
    public struct CreateEdiTransactionLog : INotification
    {
        public string Message { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"INFO - {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}: Mensaje: {Message}, Tipo: {Type}.";
        }
    }
}