using System;
using Npgsql;
using Dapper;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Inquilinos
    {
           
        public string Nome { get; set; }
      
        public int Idade { get; set; }
       
        public int Telefone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        public SexoDoInquilino Sexo { get; set; }

        public enum SexoDoInquilino
        {
            Masculino,
            Feminino
        }

    }
}
