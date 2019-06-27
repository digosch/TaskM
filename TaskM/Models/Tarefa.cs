using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskM.Models
{
    public class Tarefa
    {
        [Key]
        public int IdTarefa { get; set; }

        [Display(Name ="Digite o Nome da Tarefa : ")]
        [Required(ErrorMessage = "O Nome da Tarefa é Obrigatório")]
        [RegularExpression(@"^[a-zA-Z'-'\s]{1,40}$" , ErrorMessage = "Números e Caracteres especiais não são permitidos no Nome da Tarefa"  )]
        public string NomeTarefa { get; set; }

        [Display(Name = "Tarefa Concluída : ")]
        public bool TaskConcluida { get; set; }

    }
}