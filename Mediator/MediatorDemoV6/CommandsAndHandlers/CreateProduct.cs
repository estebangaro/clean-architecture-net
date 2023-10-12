using Mediator;

namespace CommandsAndHandlers
{
    public class CreateProduct : IRequest<int>
    {
        public string Name { get; set; }
    }
}
