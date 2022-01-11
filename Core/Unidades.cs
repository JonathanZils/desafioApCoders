using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    class Unidades
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Identificacao { get; set; }

        public string Proprietario { get; set; }

        public string Condominio { get; set; }

        public string Endereco { get; set; }
    }
}
