using System;

namespace ControleReembolso.API.Nucleo.Dominio
{
    public class DominioBase
    {
        public string ConnString { get; set; }

        public DominioBase()
        {
            this.ConnString = "User ID=postgres;Password=html5rocks;Host=45.79.109.175;Port=5432;Database=controle_reembolso;";
        }
    }
}