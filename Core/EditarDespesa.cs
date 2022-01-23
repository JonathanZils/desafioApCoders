using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Despesa;

namespace Core
{
    public class EditarDespesa
    {
        public int DespesasId { get; set; }
        public string Descricao { get; set; }
        public string TipoDespesas { get; set; }
        public decimal Valor { get; set; }
        public DateTime VencimentoFatura { get; set; }
        public StatusDoPagamento StatusPagamento { get; set; }
    }
}
