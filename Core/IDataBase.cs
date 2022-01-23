using System;
using System.Collections.Generic;

namespace Core
{
    public interface IDataBase
    {
        List<Inquilino> GetInquilinos();
        void InsertInquilino(Inquilino inquilinos);
        List<Unidade> GetUnidades();
        void InsertUnidades(Unidade unidades);
        List<Despesa> GetDespesas();
        void InsertDespesa(AdicionarDespesa despesas);
        Despesa FindDespesa(int despesaId);
        int Update(EditarDespesa despesa, int despesaId);
        List<Despesa> GetFaturaVencida();
        List<Despesa> GetDespesasPorUnidade(int unidadeId);
    }
}
