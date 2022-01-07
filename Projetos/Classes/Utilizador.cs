using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_LivroReceitas
{
    class Utilizador : IPessoa
    {
        #region Variables
        string message;
        bool login; // informa se autenticação está correta
        int chances = 3;    //3 chances para se autenticar no login
        string userName;
        string userPassword;
        int userPin;
        string Option;
        bool validated = false; // opção válida no menu ?
        #endregion

        #region Properties
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserPin { get; set; }
        #endregion

        #region Constructors
        public Utilizador(string userName, string userPassword, int userPin)
        {
            UserName = userName;
            UserPassword = userPassword;
            UserPin = userPin;
        }
        #endregion

        #region Methods

        public void Insert()
        {
        }

        public void Actualize()
        {
        }

        public void Delete()
        {
        }

        public void Search()
        {
        }

        public void TestLogin()
        {

            while (!validated) // Forçar usuário a escolher opções disponíveis
            {
                ShowMenu("    [1]- Login com username e password", "    [2]- Login com PIN", "    [0]- Sair");  // Mostrar menu para escolher tipo de autenticação

                ReadAutenticationOption(); // Ler a escolha da autenticação

                ValidateEntry();   // Verificar se digitou uma opção válida
            }
        }

        public void ShowMenu(string option1, string option2, string option3)   // mostrar menu para se autenticar
        {
            string[] menu = new string[]
            {
                option1,
                option2,
                option3
            };

            Console.WriteLine("\n    Escolha uma opção abaixo para se autenticar:\n\n");

            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }

        public void ReadAutenticationOption()   // permitir escolher o tipo de autenticação (Pin ou password)
        {
            Console.Write("\n\n    Digite a opção: ");
            Option = (Console.ReadLine());
            Console.WriteLine();
        }


        public bool ValidateEntry()
        {
            // Ver se a operação está dentro duma das hipóteses do menu com switch
            // Se sim, atribuir a uma variável boolean o valor true,
            // caso contrário, atribuir false

            switch (Option)
            {

                case "1":
                    validated = true;
                    break;
                case "2":
                    validated = true;
                    break;
                case "0":
                    validated = true;
                    break;
                default:
                    validated = false;
                    break;
            }
            return validated;
        }


        public void RealizeAutentication()  // testar código de acesso
        {

            switch (Option)
            {
                case "1":
                    while (login == false && chances != 0)
                    {
                        ReadUsername();
                        ReadUserpassword();
                        ValidateLogin(userName, userPassword);
                        chances--;
                    }
                    if (login == false && chances == 0) Exit();   // se errar 3 vezes sai do programa
                    break;
                case "2":
                    while (login == false && chances != 0)
                    {
                        ReadPin();
                        ValidateLogin(userPin);
                        chances--;
                    }
                    if (login == false && chances == 0) Exit();   // se errar 3 vezes sai do programa
                    break;
                case "0":
                    Exit();
                    break;
            }
        }

        public void Exit()  // se escolher opção sair
        {
            System.Environment.Exit(0); // sair da aplicação e fechar o console
        }

        public void Message(string message, string startLine = "", string endLine = "")
        {
            Console.Write($"{startLine}{message}{endLine}\n");
        }

        public bool ValidateLogin(string userName, string userPassword)
        {
            if (userName == UserName && userPassword == UserPassword)
            {
                login = true;   // autenticação correta
                return login;
            }
            else
            {
                message = ($"    Username ou password incorretos --> Você tem mais {chances - 1} chance(s).\n");
                Message(message, "\n\n");
                login = false;  // autenticação falhou
                return login;
            }
        }

        public bool ValidateLogin(int userPin)
        {
            if (userPin == UserPin)
            {
                login = true;   // PIN correto
                return login;
            }
            else
            {
                message = ($"    PIN incorreto --> Você tem mais {chances - 1} chance(s).\n");
                Message(message, "\n\n");
                login = false;  // autenticação falhou
                return login;
            }
        }

        public int ReadPin()   // permitir digitar login
        {
            Console.Write("\n    Digite o pin de 4 dígitos: ");
            userPin = Convert.ToInt32(Console.ReadLine());
            return userPin; // retorne o valor para ser testado
        }

        public string ReadUsername()   // permitir digitar login
        {
            Console.Write("    Username: ");
            userName = (Console.ReadLine());
            return userName;
        }

        public string ReadUserpassword()   // permitir digitar password
        {
            Console.Write("    Password: ");
            userPassword = (Console.ReadLine());
            return userPassword;
        }
        #endregion
    }
}
