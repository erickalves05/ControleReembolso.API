using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleReembolso.API.Controllers
{
    [Route("api/[controller]")]
    public class Despesas : Controller
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var _clientes = new Nucleo.Dominio.ManterCliente().ObterClientes();

            if (_clientes != null && _clientes.Count > 0)
            {
                return Json(_clientes);
            }

            return Json("Teste");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Adicionar([FromBody]Nucleo.Entidade.Despesa despesa)
        {
            try
            {
                if (despesa == null)
                {
                    return BadRequest();
                }

                new Nucleo.Dominio.ManterDespesa().Salvar(despesa);

                return Created("", despesa);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}