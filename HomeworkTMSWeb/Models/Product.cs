using HomeworkTMSWeb.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeworkTMSWeb.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "У продукта должно быть название")]
        public string Name { get; set; }

        [Required]
        public ProductCategory Category { get; set; }

        [Required]
        [Range(0.01, 1_000_000, ErrorMessage = "Цена продукта должна быть от 0.1 до 1 000 000")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Продуктов может хранится от 0 до 1000")]
        public int Quantity { get; set; }

        public Product(string name, ProductCategory category, decimal price, int quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        public Product() { }
    }
}
