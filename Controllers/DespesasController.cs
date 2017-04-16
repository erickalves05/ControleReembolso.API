using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleReembolso.API.Controllers
{
    [Route("api/[controller]")]
    public class Despesas : Controller
    {
        // POST api/values
        [HttpPost]
        [Authorize]
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