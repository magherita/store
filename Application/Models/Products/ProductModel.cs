﻿using Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Products
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quatity { get; set; }
        public Category Category { get; set; }
    }
}
