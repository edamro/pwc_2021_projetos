using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P3_MVC_EF6_CF.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }    // Primary Key
        [Required]
        [MaxLength(20)]
        public string CategoriaNome { get; set; }

        public virtual ICollection<Receita> Receitas { get; set; }

    }
}