using Domain.Orders;
using System;
using System.Collections.Generic;

namespace Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quatity { get; set; }

        public Category Category { get; set; }

        public List<LineItem> LineItems { get; set; }
    }

    public enum Category
    {
        Electronics = 1,
        Fashion = 2,
        Furniture = 3,
        Essentials = 4,
        Groceries = 5
    }
}
