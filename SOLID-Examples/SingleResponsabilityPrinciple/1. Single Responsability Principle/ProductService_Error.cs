using SOLID.Entities;
using SOLID.ValueObject;

namespace SOLID.Single_Responsability_Principle
{
    //Clase encargada de registrar un producto y registrar la información de log.
    public class ProductService_Error
    {
        public void Create(Product product)
        {
            Console.WriteLine($"Creando el producto...");

            //Registrando actividad...
            WriteLog(new Activity
            {
                ActivityName = "CREATE",
                CreateDate = DateTime.Now,
                Message = $"Creación de producto {product.Id}",
                Method = nameof(ProductService.Create),
            });
        }

        public void WriteLog(Activity activity)
        {
            Console.WriteLine($"Actividad: {activity.ActivityName}, " +
                $"Fecha: {activity.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")}, Método: {activity.Method}, " +
                $"Mensaje: {activity.Message}");
        }
    }
}