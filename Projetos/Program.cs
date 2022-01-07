using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_LivroReceitas
{ 
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Utilizador user = new Utilizador("Eduardo", "123", 9876);
                Receita receita = new Receita("sopa", "entrada", "batatas", "facil", 30, "nao");

                #region User Area
                user.TestLogin();   //menu inicial e escolha de login

                user.RealizeAutentication();    // testar código de acesso
                #endregion

                bool running = true;    // run the area to insert recipes
                while (running) // loop until the user put 0 on the number of recipes to insert
                {
                    #region Recipe Area
                    receita.TasksMenu();    // //menu de tarefas e teste de validação

                    receita.RealizeAutentication();    // testar código de acesso
                    #endregion
                    Console.Clear();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n\nOcorreu um erro.");
            }

            Console.ReadKey();
        }

    }
}
