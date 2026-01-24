using HomeworkTMSWeb.Models;
using HomeworkTMSWeb.Enums;
using HomeworkTMSWeb.Interfaces;

namespace HomeworkTMSWeb.Services
{
    //Singleton имитация базы данных
    public sealed class ProductDatabaseService : IProductDatabaseService
    {
        private static readonly List<Product> _products = new List<Product>();

        public ProductDatabaseService()
        {
            AddMockProducts();
        }

        public List<Product> GetProducts() => _products;

        public Product AddProduct(Product product)
        {
            _products.Add(product);
            return product;
        }

        public Product? FindProductById(Guid id)
        {
            return _products.FirstOrDefault(x => id == x.Id);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var existing = FindProductById(updatedProduct.Id) ?? throw new ArgumentNullException("Продукт не найден");

            existing.Name = updatedProduct.Name;
            existing.Quantity = updatedProduct.Quantity;
            existing.Price = updatedProduct.Price;
        }

        public decimal CalculateTotalValue()
        {
            var result = 0m;

            foreach (var product in _products)
            {
                result += product.Quantity * product.Price;
            }

            return result;
        }

        public decimal CalculateSumInCategory(ProductCategory category)
        {
            var productsWithCategory = _products.Where(x => x.Category == category);
            var result = 0m;

            foreach (var product in productsWithCategory)
            {
                result += product.Price * product.Quantity;
            }

            return result;
        }

        private void AddMockProducts()
        {
            var products = new List<Product>
            {
                new Product("Apple IPhone 15", ProductCategory.Electronics, 800, 10),
                new Product("Oversize Cotton Hoodie", ProductCategory.Apparel, 60, 50),
                new Product("IKEA Lamp", ProductCategory.HomeGood, 45, 25),
                new Product("\"Clean Code\"", ProductCategory.Other, 35, 15)
            };

            foreach (var product in products)
            {
                product.Id = Guid.NewGuid();
                AddProduct(product);
            }
        }
    }
}
