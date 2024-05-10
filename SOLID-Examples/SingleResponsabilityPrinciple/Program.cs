using SOLID.Dependency_Inversion_Substitution_Principle;
using SOLID.Liskov_Substitution_Principle;

namespace SOLID
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SRP();
            //OCP();
            //LSP();
            //DIP();
        }

        static void SRP()
        {
            Single_Responsability_Principle.ProductService productService =
                new Single_Responsability_Principle.ProductService(new Single_Responsability_Principle.LogService());

            productService.Create(new Entities.Product
            {
                Id = 2509
            });
        }

        static void OCP()
        {
            Open_Closed_Principle.LogService logService =
                new Open_Closed_Principle.LogService(new Open_Closed_Principle.LoggerDebugConsole());

            logService.Log(new ValueObject.Activity
            {
                ActivityName = "PRUEBA",
                CreateDate = DateTime.Now,
                Message = $"Escribiendo LOG hacia consola de depuración.",
                Method = nameof(OCP)
            });
        }

        static void LSP()
        {
            ICreatetable createtable = new Product();
            createtable.Create();

            createtable = new Category();
            createtable.Create();

            IUpdatetable updatetable = new Product();
            updatetable.Update();

            updatetable = new Category();
            updatetable.Update();

            IDeletetable deletetable = new Product();
            deletetable.Delete();
        }

        static void DIP_error()
        {
            ProductService_error productService_Error = new ProductService_error(new ConsoleLogService());
            productService_Error.Create(new Entities.Product
            {
                Id = 2509
            });
        }

        static void DIP()
        {
            ILogger logger = new ConsoleLogService();
            ProductService productService = new ProductService(logger);
            productService.Create(new Entities.Product
            {
                Id = 2509
            });

            logger = new FileLogService("tests.log");
            productService = new ProductService(logger);
            productService.Create(new Entities.Product
            {
                Id = 2412
            });
        }

        static void ExecuteEntity(Entity_error entity_Error)
        {
            entity_Error.Create();
            entity_Error.Update();
            entity_Error.Delete();
        }
    }
}
