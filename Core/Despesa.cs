using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Despesa
    {
        [Display(Name = "Condominio")]
        public int UnidadeId { get; set; }
        public  int DespesasId { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }
        [Display(Name = "Tipo de despesa")]
        public string TipoDespesas { get; set; }
        public decimal Valor { get; set; }
        [Display(Name = "Vencimento da fatura")]
        public DateTime VencimentoFatura { get; set; }
        [Display(Name = "Status do pagamento")]
        public StatusDoPagamento StatusPagamento { get; set; }

        public enum StatusDoPagamento
        {
            Pago,
            Aberto
        }
    }
}
