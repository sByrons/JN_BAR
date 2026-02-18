using Dapper;
using JN_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JN_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost(Name = "Registro Usuario")]
        public IActionResult RegistroUsuario(Usuario model)
        {
            using (var context = new SqlConnection("BYRON;Database=JN_DB;Integrated Security=True;"))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Indentificacion", model.Indentificacion);
                parametros.Add("@Nombre", model.Nombre);    
                parametros.Add("@CorreoElectronico", model.CorreoElectronico);
                parametros.Add("@Contrasenna", model.Contrasenna);

				context.Execute("sp_RegistrarCuenta", parametros);
            }
            return Ok();
     
        }

	}
}
