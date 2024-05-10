namespace SOLID.Interface_Segregation_Principle
{
    internal interface IWritable<T>
    {
        //Comportamientos para actualización de entidades.
        void Create(T entity);
        void Update(T entity);
    }
}
