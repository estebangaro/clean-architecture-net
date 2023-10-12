using Mediator;
using System.Diagnostics;

namespace CommandsAndHandlers
{
    public class DeleteProductHandler :
        IRequestHandler<DeleteProduct>
    {
        public Task Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            // Lógica para eliminar el producto...
            Debug.WriteLine($"Eliminar el producto {request.Id}");
            return Task.CompletedTask;
        }
    }
}