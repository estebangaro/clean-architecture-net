namespace SOLID.Interface_Segregation_Principle
{
    internal class ProductRepository_error : IRepository_error<Product>
    {
        public void Create(Product entity)
        {
            Console.WriteLine($"Creando producto...");
        }

        public void Delete(int idEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            Console.WriteLine("Obteniendo todos los productos...");
            return Enumerable.Empty<Product>();
        }

        public Product GetById(int id)
        {
            Console.WriteLine("Obteniendo producto por ID...");
            return new Product { Id = id };
        }

        public void Update(Product entity)
        {
            Console.WriteLine($"Actualizando producto...");
        }
    }
}