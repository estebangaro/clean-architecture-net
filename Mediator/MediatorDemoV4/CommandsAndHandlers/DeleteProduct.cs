using Mediator;

namespace CommandsAndHandlers
{
    public class DeleteProduct : IRequest
    {
        public int Id { get; set; }
    }
}
