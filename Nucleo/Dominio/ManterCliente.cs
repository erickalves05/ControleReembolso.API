using System;
using System.Collections.Generic;
using Npgsql;

namespace ControleReembolso.API.Nucleo.Dominio
{
    public class ManterCliente : DominioBase
    {
        public List<Entidade.Cliente> ObterClientes()
        {
            List<Entidade.Cliente> _retorno = new List<Entidade.Cliente>();
            Entidade.Cliente _cliente = null;

            try
            {
                using (var conn = new NpgsqlConnection(this.ConnString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "SELECT cliente_id, nome, ativo FROM clientes";

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _cliente = new Entidade.Cliente();

                                if (reader["cliente_id"] != null)
                                    _cliente.ClienteId = Convert.ToInt32(reader["cliente_id"]);

                                if (reader["nome"] != null)
                                    _cliente.Nome = reader["nome"].ToString();

                                if (reader["ativo"] != null)
                                    _cliente.Ativo = Convert.ToBoolean(reader["ativo"]);

                                _retorno.Add(_cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return _retorno;
        }
        public Entidade.Cliente ObterClientePorId(int clienteId)
        {
            Entidade.Cliente _cliente = null;

            try
            {
                using (var conn = new NpgsqlConnection(this.ConnString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn; ;

                        cmd.CommandText = "SELECT cliente_id, nome, ativo FROM clientes WHERE cliente_id = @ClienteId";

                        cmd.Parameters.AddWithValue("@ClienteId", clienteId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _cliente = new Entidade.Cliente();

                                if (reader["cliente_id"] != null)
                                    _cliente.ClienteId = Convert.ToInt32(reader["cliente_id"]);

                                if (reader["nome"] != null)
                                    _cliente.Nome = reader["nome"].ToString();

                                if (reader["ativo"] != null)
                                    _cliente.Ativo = Convert.ToBoolean(reader["ativo"]);

                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return _cliente;
        }
    }
}