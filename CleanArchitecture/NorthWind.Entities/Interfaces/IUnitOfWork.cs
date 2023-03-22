namespace NorthWind.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        ValueTask SaveChanges();
    }
}