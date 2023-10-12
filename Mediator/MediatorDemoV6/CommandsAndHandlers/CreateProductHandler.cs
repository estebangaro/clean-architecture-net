using Mediator;
using System.Diagnostics;

namespace CommandsAndHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, int>
    {
        public Task<int> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            // Lógica para crear un nuevo producto...
            Debug.WriteLine($"Crear el producto: {request.Name}");
            // Lógica para devolver el Id...
            return Task.FromResult(new Random().Next(1, 1000));
        }
    }
}