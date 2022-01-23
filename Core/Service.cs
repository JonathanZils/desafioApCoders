using System.Collections.Generic;

namespace Core
{
    public interface IService
    {
        List<Unidade> GetUnidades();
        void InsertUnidade(Unidade unidades);
        List<Despesa> GetDespesas();
        void InsertDespesa(AdicionarDespesa despesas);
        Despesa FindData(int despesaId);
        int Update(EditarDespesa despesas, int despesaId);
        List<Inquilino> GetInquilinos();
        void InsertInquilino(Inquilino inquilinos);
        List<Despesa> GetFaturaVencida();
        List<Despesa> GetDespesasPorUnidade(int unidadeId);
    }

    public class Service : IService
    {
        readonly IDataBase database;

        public Service(IDataBase database)
        {
            this.database = database;
        }

        public List<Unidade> GetUnidades()
        {
            return database.GetUnidades();
        }

        public void InsertUnidade(Unidade unidades)
        {
            database.InsertUnidades(unidades);
        }
                
        public List<Despesa> GetDespesas()
        {
            return database.GetDespesas();
        }

        public void InsertDespesa(AdicionarDespesa despesas)
        {
            database.InsertDespesa(despesas);
        }

        public Despesa FindData(int despesaId)
        {
            return database.FindDespesa(despesaId);
        }

        public int Update(EditarDespesa despesa, int despesaId)
        {
            return database.Update(despesa, despesaId);
        }

        public List<Inquilino> GetInquilinos()
        {
            return database.GetInquilinos();
        }

        public void InsertInquilino(Inquilino inquilinos)
        {
            database.InsertInquilino(inquilinos);
        }

        public List<Despesa> GetFaturaVencida()
        {
            return database.GetFaturaVencida();
        }

        public List<Despesa> GetDespesasPorUnidade(int unidadeId)
        {
            return database.GetDespesasPorUnidade(unidadeId);
        }
    }
}
        