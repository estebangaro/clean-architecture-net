using Mediator.Requests;

namespace Mediator.RequestHandlers
{
    public interface IRequestHandler<RequestType, ResponseType>
        where RequestType : IRequest<ResponseType>
    {
        Task<ResponseType> Handle(RequestType requestType, CancellationToken cancellationToken);
    }
}
