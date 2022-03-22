using ORM.Domain.Enums;
using System;

namespace ORM.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
