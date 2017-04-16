using System;
using Npgsql;

namespace ControleReembolso.API.Nucleo.Dominio
{
    public class ManterDespesa : DominioBase
    {
        public int Salvar(Entidade.Despesa despesa)
        {
            int _linhasAfetadas = 0;

            try
            {
                using (var conn = new NpgsqlConnection(this.ConnString))
                {
                    conn.Open();
                    
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;

                        // Insert some data
                        cmd.CommandText = "INSERT INTO despesas (cliente_id, tipo, valor, data_criacao) VALUES (@ClienteId, @Tipo, @Valor, @DataCriacao)";
                        
                        cmd.Parameters.AddWithValue("@ClienteId", despesa.Cliente.ClienteId);
                        cmd.Parameters.AddWithValue("@Tipo", Convert.ToInt16(despesa.TipoDespesa));
                        cmd.Parameters.AddWithValue("@Valor", despesa.Valor);
                        cmd.Parameters.AddWithValue("@DataCriacao", despesa.DataCriacao);
                        
                        _linhasAfetadas = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return _linhasAfetadas;
        }
    }
}