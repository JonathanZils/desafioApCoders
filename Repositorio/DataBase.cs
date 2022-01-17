using System;
using System.Collections.Generic;
using Dapper;
using Core;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Linq;

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
                _configuracoes.GetConnectionString("DefaultConnection")))
            {
                return (List<Inquilinos>)conn.Query<Inquilinos>("SELECT * FROM inquilinos");
            }
        }
        public void InsertInquilino(Inquilinos inquilino)
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("DefaultConnection")))
            {
                conn.Open();

                var insert = @"INSERT INTO inquilinos(Nome, Idade, Telefone, Email, Sexo) 
                       VALUES (@Nome, @Idade, @Telefone, @Email, @Sexo)";
                conn.Execute(insert, inquilino);
            }
        }
        public List<Unidades> GetUnidades()
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("DefaultConnection")))
            {
                return (List<Unidades>)conn.Query<Unidades>("SELECT * FROM Unidades");
            }
        }
        public void InsertUnidades(Unidades unidades)
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("DefaultConnection")))
            {
                conn.Open();

                var insert = @"INSERT INTO Unidades(Identificacao, Proprietario, Condominio, Endereco) VALUES (@Identificacao, @Proprietario, @Condominio, @Endereco)";
                conn.Execute(insert, unidades);
            }
        }
        public List<Despesas> GetDespesas()
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("DefaultConnection")))
            {
                return (List<Despesas>)conn.Query<Despesas>("SELECT * FROM Despesas");
            }
        }
        public void InsertDespesas(Despesas despesas)
        {
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("DefaultConnection")))
            {
                conn.Open();

                var insert = @"INSERT INTO Despesas(descricao, tipodespesas, valor, vencimentofatura, statuspagamento) VALUES (@Descricao, @Tipodespesas, @Valor, @VencimentoFatura, @StatusPagamento)";
                conn.Execute(insert, despesas);
            }
        }
        public Despesas FindDespesas(int despesas_id)
        {
            Despesas despesas = new Despesas();
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
                _configuracoes.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    conn.Open();
                    var query = @"SELECT * FROM despesas WHERE despesas_id =" + despesas_id;
                    despesas = conn.Query<Despesas>(query).FirstOrDefault();
                        
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return despesas;
            }           
        }
        public int Update(Despesas despesas,int despesas_id)
        {
            var resultado = 0;
            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(
               _configuracoes.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    conn.Open();
                    var query = @"UPDATE despesas SET descricao = @descricao, tipodespesas = @tipodespesas," +
                              "valor = @valor, vencimentofatura = @vencimentofatura, statuspagamento = @statuspagamento WHERE despesas_id =" + despesas_id;
                    resultado = conn.Execute(query, despesas);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return resultado;
            }
        }
        
    }
}
