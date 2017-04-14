using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleReembolso.API.Controllers
{
    [Route("api/[controller]")]
    public class Clientes : Controller
    {
        [HttpGet]
        public ActionResult Todos()
        {
            var _clientes = new Nucleo.Dominio.ManterCliente().ObterClientes();

            if (_clientes != null && _clientes.Count > 0)
            {
                return Json(_clientes);
            }

            return Json(null);
        }
        
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