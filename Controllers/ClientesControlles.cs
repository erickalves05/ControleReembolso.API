using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ControleReembolso.API.Controllers
{
    [Route("api/[controller]")]
    public class Clientes : Controller
    {
        // [HttpGet("api/clientes")]
        [HttpGet]
        [Authorize]
        public ActionResult Todos()
        {
            var _clientes = new Nucleo.Dominio.ManterCliente().ObterClientes();

            if (_clientes != null && _clientes.Count > 0)
            {
                return Json(_clientes);
            }

            return Json("teste");
        }
        
        // [HttpGet("api/clientes/{id}")]
        [HttpGet("{id}")]
        public ActionResult Id(int id)
        {
            var _cliente = new Nucleo.Dominio.ManterCliente().ObterClientePorId(id);

            if (_cliente != null)
            {
                return Json(_cliente);
            }

            return Json(null);
        }
    }
}