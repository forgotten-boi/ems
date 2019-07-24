
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Website.Controllers
{
	// [Authorize(Roles="Admin")]
	[Authorize(Policy = "RequireAdminRole")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}