using System;
using Npgsql;
using Dapper;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    class DespesasDasUnidades
    {
        public string Descricao { get; set; }

        public string TipoDespesas { get; set; }

        public decimal Valor { get; set; }

        public DateTime VencimentoFatura { get; set; }

        public StatusDoPagamento StatusPagamento { get; set; }

        public enum StatusDoPagamento
        {
            Pago,
            Aberto
        }
    }
}
