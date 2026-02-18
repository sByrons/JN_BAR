using System.Diagnostics;
using JN_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace JN_WEB.Controllers
{
    public class HomeController : Controller
    {
		//Pantalla de iniciO
		[HttpGet]
		public IActionResult Index()
        {
            return View();
        }

		#region Inicio de sesion
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
		#endregion

		#region Crear cuenta	
		[HttpGet]
		public IActionResult Registro()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Registro(Usuario model)
		{
			return View();
		}
		#endregion

		#region Recuperar acceso
		[HttpGet]
		public IActionResult RecuperarAcceso()
		{
			return View();
		}
		[HttpPost]
		public IActionResult RecuperarAcceso(Usuario model)
		{
			return View();
		}
		#endregion
	}
}
