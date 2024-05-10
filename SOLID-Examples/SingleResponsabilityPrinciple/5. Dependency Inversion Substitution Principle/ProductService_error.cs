using SOLID.Entities;

namespace SOLID.Dependency_Inversion_Substitution_Principle
{
    public class ProductService_error
    {
        private ConsoleLogService logService;

        public ProductService_error(ConsoleLogService logService)
        {
            this.logService = logService;
        }

        public void Create(Product product)
        {
            //Lógica para creación del producto...
            Console.WriteLine($"Creando producto con ID {product.Id}...");

            //Lógica para registro de actividad en LOG...
            logService.WriteLog(new ValueObject.Activity
            {
                ActivityName = "CREATE",
                CreateDate = DateTime.Now,
                Message = $"Creación de producto con ID {product.Id}",
                Method = nameof(ProductService_error.Create)
            });
        }
    }
}