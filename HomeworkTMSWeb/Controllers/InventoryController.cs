using HomeworkTMSWeb.Enums;
using HomeworkTMSWeb.Interfaces;
using HomeworkTMSWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkTMSWeb.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IProductDatabaseService _db;

        public InventoryController(IProductDatabaseService db)
        {
            _db = db;
        }

        [HttpGet("AllProducts")]
        public IActionResult Index()
        {
            var products = _db.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateProduct(Guid id)
        {
            var product = _db.FindProductById(id);
            return product == null ? NotFound("Товар не найден") : View(product);
        }

        [HttpPost]
        public IActionResult SubmitAddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();
                _db.AddProduct(product);
                return RedirectToAction("Index");
            }

            return BadRequest("Данные о товаре для добавления не валидны");
        }

        [HttpPost]
        public IActionResult SubmitUpdateProduct(Product updatedProduct)
        {
            if (updatedProduct == null)
            {
                return BadRequest("Товар пуст");
            }

            if (_db.FindProductById(updatedProduct.Id) == null)
            {
                return NotFound("Товар с заданным id не найден");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.UpdateProduct(updatedProduct);
            return RedirectToAction("Index");
        }
    }
}
