namespace NorthWind.Sales.BusinessObjects.DTOs.CreateOrder
{
    public struct CreateOrderDetail
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}