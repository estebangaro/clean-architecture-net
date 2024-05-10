namespace SOLID.Liskov_Substitution_Principle
{
    //Declaración e implementación de clase derivada realizada de forma incorrecta,
    //pues no hace un uso correcto de la herencia para sobreescribir la implementación
    //de la clase base del método Update(), además que el método Delete() no es requerido
    //por la clase Category_error, motivo por el cual lanza una excepción de no implementación.
    internal class Category_error : Entity_error
    {
        public override void Create()
        {
            Console.WriteLine("Create de category...");
        }

        public new void Update()
        {
            Console.WriteLine("Update de category...");
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }
    }
}