namespace NorthWind.Sales.BusinessObjects.Interfaces.Presenters
{
    public interface ICreateOrderPresenter : ICreateOrderOutputPort
    {
        int OrderId { get; }
    }
}