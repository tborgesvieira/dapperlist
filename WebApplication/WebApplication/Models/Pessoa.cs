using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Pessoa
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}