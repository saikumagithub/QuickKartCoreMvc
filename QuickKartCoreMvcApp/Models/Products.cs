﻿namespace QuickKartCoreMvcApp.Models
{
    public class Products
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public byte? CategoryId { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
