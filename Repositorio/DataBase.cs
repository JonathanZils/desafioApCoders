using System.Collections.Generic;
using Dapper;
using Core;
using System.Linq;
using System.Data;

namespace Repositorio
{
    public class Database : IDataBase
    {
        private readonly IDbConnection connection;

        public Database(IDbConnection connection)
        {
            this.connection = connection;
        }

        public List<Inquilino> GetInquilinos()
        {
            return connection.Query<Inquilino>("SELECT * FROM inquilinos").ToList();
        }

        public void InsertInquilino(Inquilino inquilino)
        {
            var insert = @"INSERT INTO inquilinos(Nome, Idade, Telefone, Email, Sexo) 
                       VALUES (@Nome, @Idade, @Telefone, @Email, @Sexo)";
            
            connection.Execute(insert, inquilino);
        }

        public List<Unidade> GetUnidades()
        {
            return connection.Query<Unidade>("SELECT * FROM Unidades").ToList();
        }

        public void InsertUnidades(Unidade unidades)
        {
            var insert = @"INSERT INTO Unidades(Identificacao, Proprietario, Condominio, Endereco) VALUES (@Identificacao, @Proprietario, @Condominio, @Endereco)";
            
            connection.Execute(insert, unidades);
        }

        public List<Despesa> GetDespesas()
        {
            return connection.Query<Despesa>("SELECT * FROM Despesas").ToList();
        }

        public void InsertDespesa(AdicionarDespesa despesas)
        {
            var insert = @"INSERT INTO despesas(descricao, tipodespesas, valor, vencimentofatura, " +
                "statuspagamento, unidadeid)" +
                " VALUES (@Descricao, @Tipodespesas, @Valor, @VencimentoFatura, @StatusPagamento, @UnidadeId)";
            
            connection.Execute(insert, despesas);
        }

        public Despesa FindDespesa(int despesasId)
        {
            var query = @"SELECT * FROM despesas WHERE despesasid =" + despesasId;
            
            return connection.Query<Despesa>(query).FirstOrDefault();
        }

        public int Update(EditarDespesa despesas, int despesaId)
        {
            var query = @"
UPDATE despesas 
    SET descricao = @descricao,
    tipodespesas = @tipodespesas,
    valor = @valor, 
    vencimentofatura = @vencimentofatura, 
    statuspagamento = @statuspagamento 
WHERE despesasid =" + despesaId;

            return connection.Execute(query, despesas);
        }

        public List<Despesa> GetFaturaVencida()
        {
            var query = @"SELECT * FROM despesas WHERE current_date > vencimentofatura AND statuspagamento = '1'";
           
            return connection.Query<Despesa>(query).ToList();
        }

        public List<Despesa> GetDespesasPorUnidade(int unidadeId)
        {
            var query = @"
SELECT *
FROM despesas
WHERE unidadeid = @UnidadeId;";

            return connection.Query<Despesa>(query, new
            {
                UnidadeId = unidadeId
            }).ToList();
        }
    }
}