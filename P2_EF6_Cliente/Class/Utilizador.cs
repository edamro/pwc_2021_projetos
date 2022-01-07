using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_EF6_DAL;


namespace P2_EF6_Cliente
{
    class Utilizador
    {

        #region Methods
        public static void Create()
        {

            using (var db = new P2_ReceitasEntities())
            {

                P2_EF6_DAL.Utilizador user = new P2_EF6_DAL.Utilizador();

                user.Username = "Lucas";
                user.Password = "456";
                user.Pin = 4567;
                db.Utilizador.Add(user);
                db.SaveChanges();

            }

        }

        public static void Read()
        {

            using (var db = new P2_ReceitasEntities())
            {

                var query = db.Utilizador.Select(c => c).OrderBy(c => c.Username);

                Console.WriteLine("\n\n-----------------------\nUtilizadores\n-----------------------");

                foreach (var item in query)
                {
                    Console.WriteLine(item.Username);
                }

            }

        }
        #endregion
    }
}
