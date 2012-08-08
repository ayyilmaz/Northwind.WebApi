using System;


namespace Northwind.WebApi.Models
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public float Discount { get; set; }
//        public Order Order { get; set; }
    }
}