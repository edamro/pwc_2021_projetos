    using System;
using System.Collections.Generic;
using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using P3_MVC_EF6_CF.DAL;
    using P3_MVC_EF6_CF.Models;

namespace P3_MVC_EF6_CF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<P3_MVC_EF6_CF.DAL.ReceitaContext>
    {
        public Configuration() 
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(P3_MVC_EF6_CF.DAL.ReceitaContext context)
        {
            var categorias = new List<Categoria>
            {
            new Categoria{CategoriaID=1,CategoriaNome="aperitivo",},
            new Categoria{CategoriaID=2,CategoriaNome="entrada",},
            new Categoria{CategoriaID=3,CategoriaNome="principal",},
            new Categoria{CategoriaID=4,CategoriaNome="acompanhamento",},
            new Categoria{CategoriaID=5,CategoriaNome="sobremesa",}
            };

            categorias.ForEach(s => context.Categorias.Add(s));
            context.SaveChanges();

            var graudificuldades = new List<GrauDificuldade>
            {
            new GrauDificuldade{GrauDificuldadeID=1,GrauDificuldadeNome="muito fácil",},
            new GrauDificuldade{GrauDificuldadeID=2,GrauDificuldadeNome="fácil",},
            new GrauDificuldade{GrauDificuldadeID=3,GrauDificuldadeNome="médio",},
            new GrauDificuldade{GrauDificuldadeID=4,GrauDificuldadeNome="difícil",},
            new GrauDificuldade{GrauDificuldadeID=5,GrauDificuldadeNome="chef",}
            };

            graudificuldades.ForEach(s => context.GrauDificuldades.Add(s));
            context.SaveChanges();

            var receitas = new List<Receita>
            {
            new Receita{CategoriaID=2,GrauDificuldadeID=2,ReceitaNome="salada de tomate",ReceitaDuracao= 20,ReceitaDescricao="preparo salada"},
            new Receita{CategoriaID=4,GrauDificuldadeID=2,ReceitaNome="arroz",ReceitaDuracao= 30,ReceitaDescricao="preparo arroz"},
            new Receita{CategoriaID=3,GrauDificuldadeID=4,ReceitaNome="frango assado",ReceitaDuracao= 60,ReceitaDescricao="preparo frango"},
            new Receita{CategoriaID=5,GrauDificuldadeID=3,ReceitaNome="brigadeiro",ReceitaDuracao= 40,ReceitaDescricao="preparo brigadeiro"},
            new Receita{CategoriaID=2,GrauDificuldadeID=3,ReceitaNome="sopa de batata",ReceitaDuracao= 40,ReceitaDescricao="preparo sopa"},
            };
            receitas.ForEach(s => context.Receitas.Add(s));
            context.SaveChanges();
        }
    }
}
