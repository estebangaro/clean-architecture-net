using Mediator.Requests;

namespace Mediator.RequestHandlers
{
    public interface IRequestHandler<RequestType>
        where RequestType : IRequest
    {
        Task Handle(RequestType request, CancellationToken cancellationToken);
    }
}
