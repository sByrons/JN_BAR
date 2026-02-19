using System.Diagnostics;
using System.Net;
using JN_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace JN_WEB.Controllers
{
    public class HomeController : Controller
    {
		private readonly IHttpClientFactory _http;
		private readonly IConfiguration _config;
		public HomeController(IHttpClientFactory http, IConfiguration config)
		{
			_http = http;
			_config = config;
		}

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
			using var client = _http.CreateClient();
			var url = _config.GetValue<string>("Valores:UrlAPI") + "Home/IniciarSesion";
			var result = client.PostAsJsonAsync(url, model).Result;
			if (result.StatusCode == HttpStatusCode.OK)
			{
				return RedirectToAction("Index", "Home");
			}
			ViewBag.Mensaje = result.Content.ReadAsStringAsync().Result;
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
			using var client = _http.CreateClient();
				var url = _config.GetValue<string>("Valores:UrlAPI") + "Home/RegistroUsuario";
				var result = client.PostAsJsonAsync(url, model).Result;
				if (result.StatusCode == HttpStatusCode.OK)
				{
					return RedirectToAction("Login", "Home");
				}
				ViewBag.Mensaje = result.Content.ReadAsStringAsync().Result;
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
