namespace NorthWind.Sales.BusinessObjects.DTOs.CreateOrder
{
    public struct CreateOrder
    {
        public string CustomerId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public List<CreateOrderDetail> OrderDetails { get; set; }
    }
}