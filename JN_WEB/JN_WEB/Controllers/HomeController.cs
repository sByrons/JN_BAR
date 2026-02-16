using System.Diagnostics;
using JN_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace JN_WEB.Controllers
{
    public class HomeController : Controller
    {
		//Pantalla de inicio
		public IActionResult Index()
        {
            return View();
        }
		//Pantalla de login
		[HttpGet]
		public IActionResult Login()
        {
            return View();
		}
		//Procesar el login
		[HttpPost]
		public IActionResult Login(Usuario model)
		{
			return View();
		}
	}
}
