namespace SOLID.Interface_Segregation_Principle
{
    internal interface IReadable<T>
    {
        //Comportamiento para consulta de entidades.
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
