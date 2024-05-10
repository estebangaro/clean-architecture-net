namespace SOLID.Liskov_Substitution_Principle
{
    internal class Product : ICreatetable, IUpdatetable, IDeletetable
    {
        public void Create()
        {
            Console.WriteLine("Create de product...");
        }

        public void Update()
        {
            Console.WriteLine("Update de product...");
        }

        public void Delete()
        {
            Console.WriteLine("Delete de product...");
        }
    }
}
