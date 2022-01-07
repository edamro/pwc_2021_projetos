using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P3_MVC_EF6_CF.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace P3_MVC_EF6_CF.DAL
{
    public class ReceitaContext : DbContext
    {
        public ReceitaContext() : base("ReceitaContext")
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<GrauDificuldade> GrauDificuldades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}