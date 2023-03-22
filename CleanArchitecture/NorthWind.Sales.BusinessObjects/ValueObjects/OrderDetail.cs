namespace NorthWind.Sales.BusinessObjects.ValueObjects
{
    public readonly record struct OrderDetail(int ProductId, decimal UnitPrice, short Quantity);
}