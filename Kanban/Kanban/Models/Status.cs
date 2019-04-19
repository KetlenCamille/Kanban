using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kanban.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int IDStatus { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Descrição da categoria")]
        public String DescricaoStatus { get; set; }
    }
}