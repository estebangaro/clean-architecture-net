namespace SOLID.Interface_Segregation_Principle
{
    //Únicamente proporcionamos detalles de implementación, asociados a nuestra única responsabilidad.
    internal class ProductRepository : IWritable<Product>, IReadable<Product>
    {
        public void Create(Product entity)
        {
            Console.WriteLine($"Creando producto...");
        }

        public IEnumerable<Product> GetAll()
        {
            Console.WriteLine("Obteniendo todos los productos...");
            return Enumerable.Empty<Product>();
        }

        public Product GetById(int id)
        {
            Console.WriteLine("Obteniendo producto por ID...");
            return default;
        }

        public void Update(Product entity)
        {
            Console.WriteLine($"Actualizando producto...");
        }
    }
}
