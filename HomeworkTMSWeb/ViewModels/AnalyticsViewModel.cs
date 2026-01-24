using HomeworkTMSWeb.Enums;

namespace HomeworkTMSWeb.ViewModels
{
    public class AnalyticsViewModel
    {
        public decimal TotalSum { get; set; }
        public string? SelectedCategoryName { get; set; }
        public decimal? SelectedCategorySum { get; set; }
    }
}
