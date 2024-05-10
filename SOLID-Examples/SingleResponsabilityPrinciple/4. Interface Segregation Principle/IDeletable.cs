namespace SOLID.Interface_Segregation_Principle
{
    internal interface IDeletable
    {
        //Comportamiento para depuración de entidades.
        void Delete(int idEntity);
    }
}
