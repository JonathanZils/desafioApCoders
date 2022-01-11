using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    class DespesasDasUnidades
    {
        [BsonId]
        public ObjectId Id { get; set; }

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
