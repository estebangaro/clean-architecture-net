namespace EdiRequests
{
    public class DeleteEdiTransaction : MediatR.IRequest
    {
        public int Id { get; set; }
    }
}