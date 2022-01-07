using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_LivroReceitas
{
    class Ingredientes : IIngrediente
    {
        #region variables
        List<Ingredientes> listIngredients = new List<Ingredientes>();
        string recipeName;
        #endregion

        #region Properties
        public int IngredientsCounter { get; set; }
        public string IngredientName { get; set; }
        public string IngredientQuantity { get; set; }
        public string IngredientRecipe { get; set; }    //*******************
        #endregion

        #region Constructors
        public Ingredientes()
        {
            IngredientName = string.Empty;
            IngredientQuantity = string.Empty;
            IngredientRecipe = string.Empty;    //********************
            IngredientsCounter = 0;
        }
        public Ingredientes(string ingredientRecipe, string ingredientName, string ingredientQuantity)  //*******
        {
            IngredientRecipe = ingredientRecipe;    //***********************
            IngredientName = ingredientName;
            IngredientQuantity = ingredientQuantity;
            IngredientsCounter = 0;
        }
        #endregion

        #region Methods
        
        public void ReadIngredients()  // pedir para informar número de receitas a incluir
        {
            Console.Write("\n    Informe número de ingredientes da receita: ");
            IngredientsCounter = Convert.ToInt16(Console.ReadLine());

            for (int j = 1; j <= IngredientsCounter; j++) // permitir inserir o número de ingredientes informado
            {
                Console.Write($"\n    Nome do ingrediente {j}:");
                IngredientName = Console.ReadLine();

                Console.Write($"\n    Quantidade do ingrediente {j} (Ex: 2 unidades | 2 colheres | 250 gr) :");
                IngredientQuantity = Console.ReadLine();

                listIngredients.Add(new Ingredientes(IngredientRecipe, IngredientName, IngredientQuantity));   // incluir receita na lista
            }
        }
        
        public void ListIngredients()  // listar os ingredientes da receita correspondente
        {
            recipeName = IngredientRecipe;
            foreach (Ingredientes item in listIngredients)
            {
                if (recipeName == item.IngredientRecipe)
                {
                    Console.WriteLine($"    Nome do ingrediente: {item.IngredientName}\n\n    Quantidade: {item.IngredientQuantity}\n\n");
                }
            }
        }
        #endregion
    }
}
