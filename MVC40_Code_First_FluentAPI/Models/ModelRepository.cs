using System.Collections.Generic;

namespace MVC40_Code_First_FluentAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string OrderedItem { get; set; }
        public int OrderedQuantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}