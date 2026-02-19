using Dapper;
using JN_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace JN_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
		}

		[HttpPost("Registro Usuario")]
        public IActionResult RegistroUsuario(Usuario model)
        {
			using var context = new SqlConnection(_config.GetValue<string>("ConnectionStrings:DefaultConnection"));
			var parametros = new DynamicParameters();
			parametros.Add("@Indentificacion", model.Indentificacion);
			parametros.Add("@Nombre", model.Nombre);
			parametros.Add("@CorreoElectronico", model.CorreoElectronico);
			parametros.Add("@Contrasenna", model.Contrasenna);

			var result = context.Execute("sp_RegistrarCuenta", parametros);

			if (result <= 0)
				return BadRequest(new { message = "No se registró su información" });

			return Ok(new { message = "Su información se registró correctamente" });
		}

        [HttpPost("IniciarSesion")]

        public IActionResult IniciarSesion(Usuario model)
        {
			using var context = new SqlConnection(_config.GetValue<string>("ConnectionStrings:DefaultConnection"));
			var parametros = new DynamicParameters();
			parametros.Add("@CorreoElectronico", model.CorreoElectronico);
			parametros.Add("@Contrasenna", model.Contrasenna);

			var result = context.QueryFirstOrDefault<Usuario>("sp_IniciarSesion", parametros);

			if (result == null)
				return NotFound("Su información no se autentico correctamente");

			return Ok("Su información se autentico correctamente");

			
        }

	}
}
