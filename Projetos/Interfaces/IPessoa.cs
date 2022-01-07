using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_LivroReceitas
{
    interface IPessoa
    {
        #region Properties
        string UserName { get; }
        string UserPassword { get; }
        int UserPin { get; }
        #endregion


        #region Methods
        //void ShowMenu();

        void Insert();

        void Actualize();

        void Delete();

        void Search();

        void TestLogin();

        string ReadUsername();

        string ReadUserpassword();

        bool ValidateLogin(string userName, string userPassword);

        bool ValidateLogin(int Pin);

        int ReadPin();

        #endregion

    }
}
