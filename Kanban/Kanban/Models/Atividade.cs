using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kanban.Models
{
    [Table("Atividades")]
    public class Atividade
    {
        [Key]
        public int IDAtividade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Título da atividade")]
        public String TituloAtividade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Descrição da atividade")]
        public String DescricaoAtividade { get; set; }

        [Display(Name = "Requisito da atividade")]
        public int RequisitoAtividade { get; set; }

        [Display(Name = "Status da atividade")]
        public Status Status { get; set; }
    }
}