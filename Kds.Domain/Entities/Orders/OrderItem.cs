﻿namespace Kds.Domain.Entities.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public int OrderId { get; set; } 
    }
}