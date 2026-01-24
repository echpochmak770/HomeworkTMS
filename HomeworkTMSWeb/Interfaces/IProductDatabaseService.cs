using HomeworkTMSWeb.Enums;
using HomeworkTMSWeb.Models;

namespace HomeworkTMSWeb.Interfaces
{
    public interface IProductDatabaseService
    {
        List<Product> GetProducts();
        Product AddProduct(Product product);
        Product? FindProductById(Guid id);
        void UpdateProduct(Product product);
        decimal CalculateTotalValue();
        decimal CalculateSumInCategory(ProductCategory category);
    }
}
