using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Telefone
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(10)]
        public string Contato { get; set; }
        
        public Guid PessoaId { get; set; }

        [ForeignKey("PessoaId")]
        public virtual Pessoa PessoaObject { get; set; }
    }
}