using SOLID.Entities;

namespace SOLID.Dependency_Inversion_Substitution_Principle
{
    public class ProductService
    {
        //Hacemos referencia a una abstracción ILogger, que describe los comportamientos
        //que un servicio de logging deberá implementar para el registro de información
        //de actividad en un LOG.
        ILogger logger;

        public ProductService(ILogger logger)
        {
            this.logger = logger;
        }

        public void Create(Product product)
        {
            //Lógica para creación del producto...
            Console.WriteLine($"Creando producto con ID {product.Id}...");

            //Lógica para registro de actividad en LOG...
            logger.WriteLog(new ValueObject.Activity
            {
                ActivityName = "CREATE",
                CreateDate = DateTime.Now,
                Message = $"Creación de producto con ID {product.Id}",
                Method = nameof(ProductService_error.Create)
            });
        }
    }
}
