using SOLID.Entities;
using SOLID.ValueObject;

namespace SOLID.Single_Responsability_Principle
{
    //Clase encargada de la creación de productos y solicitud de registro de información de LOG en medio de almacenamiento.
    public class ProductService
    {
        private readonly LogService logService;

        public ProductService(LogService logService)
        {
            this.logService = logService;
        }

        public void Create(Product product)
        {
            Console.WriteLine($"Creando producto...");

            logService.Write(new Activity
            {
                ActivityName = "CREATE",
                CreateDate = DateTime.Now,
                Message = $"Creación de producto {product.Id}",
                Method = nameof(ProductService.Create),
            });
        }
    }
}