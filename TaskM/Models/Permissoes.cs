using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskM.Models
{
    public class Permissoes
    {
        [Key]
        public string IdPermissao { get; set; }


        public int UserId { get; set; }


        [Display(Name = "Permissão de Acesso ")]
        public string Name { get; set; }

        public virtual ICollection<Permissoes> RoleId { get; set; }

    }
}