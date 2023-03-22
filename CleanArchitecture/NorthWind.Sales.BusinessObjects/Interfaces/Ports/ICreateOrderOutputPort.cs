namespace NorthWind.Sales.BusinessObjects.Interfaces.Ports
{
    public interface ICreateOrderOutputPort
    {
        ValueTask Handle(int orderId);
    }
}