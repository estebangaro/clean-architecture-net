namespace Mediator
{
    // Representa una petición que no devuelve resultado.
    public interface IRequest { }
    // Representa una petición que devuelve un resultado de tipo ResponseType
    public interface IRequest<ResponseType> { }
}
