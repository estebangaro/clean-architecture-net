namespace Mediator
{
    public interface IMediator
    {
        // Enviar una petición que no espera resultado.
        Task Send(IRequest request, CancellationToken cancellationToken = default);
        // Enviar una petición que espera resultado.
        Task<ResponseType> Send<ResponseType>(IRequest<ResponseType> request,
            CancellationToken cancellationToken = default);
    }
}