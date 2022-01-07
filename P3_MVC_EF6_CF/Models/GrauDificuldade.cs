using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace P3_MVC_EF6_CF.Models
{
    public class GrauDificuldade
    {
        public int GrauDificuldadeID { get; set; }  // Primary Key
        [Required]
        [MaxLength(20)]
        public string GrauDificuldadeNome { get; set; }

        //public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Receita> Receitas { get; set; }
    }
}