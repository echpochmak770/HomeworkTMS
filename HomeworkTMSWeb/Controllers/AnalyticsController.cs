using HomeworkTMSWeb.Enums;
using HomeworkTMSWeb.Interfaces;
using HomeworkTMSWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeworkTMSWeb.Filters;

namespace HomeworkTMSWeb.Controllers
{
    public class AnalyticsController : Controller
    {
        private readonly IProductDatabaseService _db;

        public AnalyticsController(IProductDatabaseService db)
        {
            _db = db; 
        }

        [TimeLoggingFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var vm = new AnalyticsViewModel
            {
                TotalSum = GetTotalValue()
            };

            return View(vm);
        }

        [TimeLoggingFilter]
        [HttpGet]
        public IActionResult ShowAnalytics(ProductCategory category)
        {
            var vm = new AnalyticsViewModel
            {
                TotalSum = _db.CalculateTotalValue(),
                SelectedCategoryName = category.ToString(),
                SelectedCategorySum = _db.CalculateSumInCategory(category)
            };

            return View("Index", vm);
        }

        private decimal GetTotalValue()
        {
            return _db.CalculateTotalValue();
        }
    }
}
