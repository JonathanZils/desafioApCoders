using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Despesa;

namespace Core
{
    public class AdicionarDespesa
    {
        [Display(Name = "Condominio")]
        public int UnidadeId { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }
        [Display(Name = "Tipo de despesa")]
        [Required(ErrorMessage = "O tipo de despesa é obrigatório")]
        public string TipoDespesas { get; set; }
        public decimal Valor { get; set; }
        [Display(Name = "Vencimento da fatura")]
        public DateTime VencimentoFatura { get; set; }
        [Display(Name = "Status do pagamento")]
        public StatusDoPagamento StatusPagamento { get; set; }
    }
}
