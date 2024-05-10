namespace SOLID.Interface_Segregation_Principle
{
    internal interface IRepository_error<T>
    {
        //Comportamientos para actualización de entidades.
        void Create(T entity);
        void Update(T entity);
        //Comportamiento para depuración de entidades.
        void Delete(int idEntity);
        //Comportamiento para consulta de entidades.
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}