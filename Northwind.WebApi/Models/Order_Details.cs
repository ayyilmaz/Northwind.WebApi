using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;


namespace Northwind.WebApi.Models
{
    [Table(Name="Order_Details")]
    public class OrderDetail
    {
        [Key]
        public int OrderID { get; set; }
        [Key]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public float Discount { get; set; }
//        public Order Order { get; set; }
    }
}