using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_EF6_DAL;

namespace P2_EF6_Cliente
{
    class Categoria
    {

        #region Methods
        public static void Create()
        {

            using (var db = new P2_ReceitasEntities())
            {

                P2_EF6_DAL.Categoria category = new P2_EF6_DAL.Categoria();

                category.Categoria1 = "entrada";
                
                db.Categoria.Add(category);
                db.SaveChanges();

            }

        }

        public static void Read()
        {

            using (var db = new P2_ReceitasEntities())
            {

                var query = db.Categoria.Select(c => c).OrderBy(c => c.Categoria1);

                Console.WriteLine("\n\n-----------------------\nCategorias\n-----------------------");

                foreach (var item in query)
                {
                    Console.WriteLine(item.Categoria1);
                }

            }

        }
        #endregion
    }
}
