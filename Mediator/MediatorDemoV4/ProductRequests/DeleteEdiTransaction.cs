using Mediator;

namespace EdiRequests
{
    public class DeleteEdiTransaction : IRequest
    {
        public int Id { get; set; }
    }
}
