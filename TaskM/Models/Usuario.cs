using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskM.Models
{
    public class Usuario
    {
        [Key]
        public string UserId { get; set; }

        [Display(Name = "Nome do Usuário : ")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int IdPermissao { get; set; }

        public List<Permissoes> Permissoes { get; set; }

        public Permissoes Permissao { get; set; }
    }
}