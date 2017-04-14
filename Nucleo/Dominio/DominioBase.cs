using System;

namespace ControleReembolso.API.Nucleo.Dominio
{
    public class DominioBase
    {
        public string ConnString { get; set; }

        public DominioBase()
        {
            this.ConnString = "";
        }
    }
}