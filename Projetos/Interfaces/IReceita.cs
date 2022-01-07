using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_LivroReceitas
{
    interface IReceita
    {

        #region Properties
        string RecipeName { get; }
        string Cathegory { get; }
        string Ingredient { get; }
        int Quantity { get; }
        string Description { get; }
        string Difficult { get; }
        int Duration { get; }
        int RecipesCounter { get; }

        string RecipeTested { get; }
        #endregion


        #region Methods
        void Actualize();

        void Delete();

        void Search();

        void TasksMenu();

        void ShowMenu(string option1, string option2, string option3, string option4, string option5);

        void ReadMenuOption();

        bool ValidateEntry();

        void ReadRecipeNumber();

        void RealizeAutentication();

        void ReadRecipeContents();

        void ReadCathegory();

        void ReadDifficulty();

        void ListRecipeContents();

        void ListRecipeContents(bool listTested);

        void Exit();

        #endregion

    }
}
