namespace Mediator
{
    // Atiende una petición que no espera resultado
    public interface IRequestHandler<RequestType>
        where RequestType : IRequest
    {
        Task Handle(RequestType request,
            CancellationToken cancellationToken);
    }

    // Atiende una petición que espera un resultado.
    public interface IRequestHandler<RequestType, ResponseType>
        where RequestType : IRequest<ResponseType>
    {
        Task<ResponseType> Handle(RequestType request,
            CancellationToken cancellationToken);
    }
}
