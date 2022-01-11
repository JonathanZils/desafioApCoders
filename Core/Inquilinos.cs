using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Inquilinos
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public int Telefone { get; set; }

        public EmailAddressAttribute Email { get; set; }

        public SexoDoInquilino Sexo { get; set; }

        public enum SexoDoInquilino
        {
            Masculino,
            Feminino
        }

    }
}
