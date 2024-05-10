namespace SOLID.Liskov_Substitution_Principle
{
    internal class Category : ICreatetable, IUpdatetable
    {
        public void Create()
        {
            Console.WriteLine("Create de category...");
        }

        public void Update()
        {
            Console.WriteLine("Update de category...");
        }
    }
}