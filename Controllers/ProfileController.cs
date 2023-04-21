using Microsoft.AspNetCore.Mvc;

namespace what_u_gonna_eat.Controllers
{
	public class Profile : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
