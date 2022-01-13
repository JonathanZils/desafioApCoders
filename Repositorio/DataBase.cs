using System;
using System.Collections.Generic;
using Dapper;
using Core;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace Repositorio
{
   public class Database : IDataBase
    {
        private IConfiguration _configuracoes;

        public Database(IConfiguration config)
        {
            _configuracoes = config;
        }
        public List<Inquilinos> GetInquilino()
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("ConnectionString")))
            {
                return (List<Inquilinos>)conn.Query<Inquilinos>("SELECT * FROM Inquilinos");
            }
        }
        public void InsertInquilino(Inquilinos inquilino)
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("connectionString")))
            {
                conn.Open();

                var insert = @"INSERT INTO Inquilinos(Nome, Idade, Telefone, Email, Sexo) VALUES (@Nome, @Idade, @Telefone, @Email, @Sexo)";
                conn.Execute(insert);
            }
        }
        public List<Unidades> GetUnidades()
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("ConnectionString")))
            {
                return (List<Unidades>)conn.Query<Unidades>("SELECT * FROM Unidades");
            }
        }
        public void InsertUnidades(Unidades unidades)
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("connectionString")))
            {
                conn.Open();

                var insert = @"INSERT INTO Unidades(Identificacao, Proprietario, Condominio, Endereco) VALUES (@Idenificacao, @Proprietrio, @Condominio, @Endereco)";
                conn.Execute(insert);
            }
        }
    }
}
