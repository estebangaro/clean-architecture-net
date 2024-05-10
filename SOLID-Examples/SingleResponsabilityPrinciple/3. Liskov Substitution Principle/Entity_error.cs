namespace SOLID.Liskov_Substitution_Principle
{
    internal class Entity_error
    {
        public virtual void Create()
        {
            //Lógica de creación...
            Console.WriteLine("Create de entity...");
        }

        public virtual void Update()
        {
            //Lógica de actualización...
            Console.WriteLine("Update de entity...");
        }

        public virtual void Delete()
        {
            //Lógica de eliminación...
            Console.WriteLine("Delete de entity...");
        }
    }
}