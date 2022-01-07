using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_EF6_Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilizador.Create();
            Utilizador.Read();

            Console.WriteLine("\n\nDigite uma tecla para continuar");
            Console.ReadKey();

            Categoria.Create();
            Categoria.Read();
        }
    }
}
