using System;
using Npgsql;
using Dapper;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Unidades
    {
        
        public string Identificacao { get; set; }

        public string Proprietario { get; set; }

        public string Condominio { get; set; }

        public string Endereco { get; set; }
    }
}
