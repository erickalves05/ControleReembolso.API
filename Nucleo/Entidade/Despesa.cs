using System;

namespace ControleReembolso.API.Nucleo.Entidade
{
    public class Despesa
    {
        public int DespesaId { get; set; }
        public Entidade.Cliente Cliente { get; set; }
        public Enums.TipoDespesa TipoDespesa { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCricao { get; set; }
    }
}