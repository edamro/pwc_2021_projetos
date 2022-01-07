using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_LivroReceitas
{
    interface IIngrediente
    {

        #region Properties
        int IngredientsCounter { get; }
        string IngredientName { get; }
        string IngredientQuantity { get; }
        string IngredientRecipe { get; }    //****************
        #endregion

        #region Methods

        void ReadIngredients();

        void ListIngredients();

        #endregion


    }
}
