using Mediator;

namespace EdiRequests
{
    public class CreateEdiTransaction : IRequest<int>
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}