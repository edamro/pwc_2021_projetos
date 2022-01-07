using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace P3_MVC_EF6_CF.Models
{
    public class Receita
    {
        public int ReceitaID { get; set; }  // Primary Key
        public int CategoriaID { get; set; }    // Foreign Key
        public int GrauDificuldadeID { get; set; }  // Foreign Key
        [Required]
        [MaxLength(30)]
        public string ReceitaNome { get; set; }
        [Required]
        [MaxLength(200)]
        public string ReceitaDescricao { get; set; }
        public int ReceitaDuracao { get; set; }


        public virtual Categoria Categoria { get; set; }
        public virtual GrauDificuldade GrauDificuldade { get; set; }
    }
}