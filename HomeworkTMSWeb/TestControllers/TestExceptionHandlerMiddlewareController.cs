using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkTMSWeb.TestControllers
{
    public class TestExceptionHandlerMiddlewareController : Controller
    {
        [HttpGet("/throw")]
        public IActionResult Throw()
        {
            throw new Exception("Тест");
        }
    }
}
