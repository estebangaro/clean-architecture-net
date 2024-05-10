using Mediator.Requests;

namespace Mediator.Interfaces
{
    public interface IMediator
    {
        Task Send(IRequest request, CancellationToken cancellationToken = default);

        Task<ResponseType> Send<ResponseType>(IRequest<ResponseType> request, CancellationToken cancellationToken = default);
    }
}
