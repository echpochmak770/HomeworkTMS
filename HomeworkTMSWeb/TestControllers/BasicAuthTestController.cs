using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace HomeworkTMSWeb.TestControllers
{

    [ApiController]
    [Authorize]
    [Route("/[controller]")]
    public class BasicAuthTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult TestAuthentication()
        {
            return Ok(new { msg = $"Доступ для {User.Identity.Name} разрешен" });
        }
    }
}
