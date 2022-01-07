using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_LivroReceitas
{
    class Receita : IReceita
    {
        #region variables
        string menuOption;  // guarda a tarefa escolhida
        bool listHeaders;   //permite listar somente os nomes das receitas inseridas
        bool validated; // opção válida no menu ?
        bool listTested;   //permite listar somente as receitas testadas

        List<Receita> listRecipe = new List<Receita>();
        Ingredientes ingredientes = new Ingredientes(" ", "tomate", "2 unidades");  //*********
        #endregion

        #region Properties
        public string RecipeName { get; set; }
        public string Cathegory { get; set; }
        public string Ingredient { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Difficult { get; set; }
        public int Duration { get; set; }
        public int RecipesCounter { get; set; }
        public string RecipeTested { get; set; }  // indicador de receita testada
        #endregion

        #region Constructors
        public Receita()
        {
            RecipeName = string.Empty;
            Cathegory = string.Empty;
            Ingredient = string.Empty;
            Quantity = 0;
            Description = string.Empty;
            Difficult = string.Empty;
            Duration = 0;
            RecipesCounter = 0;
            RecipeTested = string.Empty;
        }
        public Receita(string recipeName, string cathegory, string description, string difficult, int duration, string valtest)
        {
            RecipeName = recipeName;
            Cathegory = cathegory;
            Description = description;
            Difficult = difficult;
            Duration = duration;
            RecipesCounter = 0;
            RecipeTested = valtest;
        }
        #endregion

        #region Methods
        public void Actualize()
        {
        }

        public void Delete()
        {
        }

        public void Search()
        {
        }

        public void TasksMenu()
        {
            validated = false; // Forçar usuário a escolher opções disponíveis
            while (!validated)
            {
                ShowMenu("    [1]- Inserir receitas", "    [2]- Listar todas as receitas", "    [3]- Listar nomes das receitas", "    [4]- Listar receitas testadas", "    [0]- Sair"); // opção para guardar ou listar receitas

                ReadMenuOption();   // Ler o que usuário deseja fazer

                ValidateEntry();   // Verificar se digitou uma opção válida
            }
        }

        public void ShowMenu(string option1, string option2, string option3, string option4, string option5)   // mostrar menu para se autenticar
        {
            string[] menu = new string[]
            {
                option1,
                option2,
                option3,
                option4,
                option5
            };
            Console.Clear();    // limpar a console para novo menu
            Console.WriteLine("\n    Escolha a opção para continuar\n\n");
            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }

        public void ReadMenuOption()   // permitir escolher listar ou salvar
        {
            Console.Write("\n    Digite a opção: ");
            menuOption = (Console.ReadLine());
            Console.WriteLine();
        }

        public bool ValidateEntry()
        {

            switch (menuOption)
            {

                case "1":
                    validated = true;
                    break;
                case "2":
                    validated = true;
                    break;
                case "3":
                    validated = true;
                    break;
                case "4":
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

            switch (menuOption)
            {
                case "1":
                    ReadRecipeNumber();
                    ReadRecipeContents();
                    break;
                case "2":
                    Console.Clear();    //limpar console para listar receitas
                    ListRecipeContents();
                    break;
                case "3":
                    Console.Clear();    //limpar console para listar receitas
                    listHeaders = true;
                    ListRecipeContents();
                    break;
                case "4":
                    Console.Clear();    //limpar console para listar receitas
                    listTested = true;
                    ListRecipeContents(listTested);
                    break;
                case "0":
                    Exit();
                    break;
            }
        }

        public void ReadRecipeNumber()  // pedir para informar número de receitas a incluir
        {
            RecipesCounter = 0; // reiniciar contador para nova inserção de receitas
            while (RecipesCounter == 0)
            {
                Console.Write("\n    Informe número de receitas a incluir: ");
                RecipesCounter = Convert.ToInt16(Console.ReadLine());
            }
        }

        public void ReadRecipeContents()    // pedir para informar os dados da receita
        {
            for (int i = 1; i <= RecipesCounter; i++) // permitir inserir o número de receitas informado
            {
                Console.Clear();
                Console.Write($"\n    Nome da receita {i}:");
                RecipeName = Console.ReadLine();
                ingredientes.IngredientRecipe = RecipeName;    // receita que está sendo usada

                Console.Write("\n    Esta receita foi testada ? (s/n): ");  // informar se receita foi testada
                RecipeTested = Console.ReadLine();
                if (RecipeTested == "S" || RecipeTested == "s" || RecipeTested == "sim")
                {
                    RecipeTested = "Sim";
                } else
                {
                    RecipeTested = "Não";
                }

                ReadCathegory();    // ler a categoria da receita

                ReadDifficulty();   // ler o grau de dificuldade

                Console.Write("\n    Duração do preparo em minutos (somente algarismos) : ");
                Duration = Convert.ToInt32(Console.ReadLine());

                Console.Write("\n    Descrição do preparo: ");
                Description = Console.ReadLine();

                ingredientes.ReadIngredients(); // pedir para informar número de ingredientes a incluir

                listRecipe.Add(new Receita(RecipeName, Cathegory, Description, Difficult, Duration, RecipeTested));   // incluir receita na lista
            }
        }

        public void ReadCathegory()    // pedir para informar a categoria da receita
        {
            validated = false; // Forçar usuário a escolher opções disponíveis
            while (!validated)
            {

                Console.Write("\n\n    Escolha o número da categoria: ");   // menu para categoria

                ShowMenu("    [1]- Aperitivo", "    [2]- Entrada", "    [3]- Principal", "    [4]- Acompanhamento", "    [0]- Sobremesa"); // opção para escolher categoria

                ReadMenuOption();   // Ler o que usuário deseja fazer

                ValidateEntry();   // Verificar se digitou uma opção válida
            }

            switch (menuOption)
            {
                case "1":
                    Cathegory = "Aperitivo";
                    break;
                case "2":
                    Cathegory = "Entrada";
                    break;
                case "3":
                    Cathegory = "Principal";
                    break;
                case "4":
                    Cathegory = "Acompanhamento";
                    break;
                case "0":
                    Cathegory = "Sobremesa";
                    break;
            }
        }

        public void ReadDifficulty()    // pedir para informar a dificuldade da receita
        {
            validated = false; // Forçar usuário a escolher opções disponíveis
            while (!validated)
            {

                Console.Write("\n\n    Escolha a dificuldade da categoria: ");   // menu para dificuldade

                ShowMenu("    [1]- Muito fácil", "    [2]- Fácil", "    [3]- Médio", "    [4]- Difícil", "    [0]- Chef"); // opção para escolher categoria

                ReadMenuOption();   // Ler o que usuário deseja fazer

                ValidateEntry();   // Verificar se digitou uma opção válida
            }

            switch (menuOption)
            {
                case "1":
                    Difficult = "Muito fácil";
                    break;
                case "2":
                    Difficult = "Fácil";
                    break;
                case "3":
                    Difficult = "Médio";
                    break;
                case "4":
                    Difficult = "Difícil";
                    break;
                case "0":
                    Difficult = "Chef";
                    break;
            }
        }

        public void ListRecipeContents()
        {
            int recipeNum = 0;  // indicar número da receita a ser listada
            foreach (Receita item in listRecipe)    // listar as receitas
            {
                recipeNum++;    // apontar para ordem da receita a listar
                if (listHeaders == false)
                {
                    Console.WriteLine($"\n\n    ************* RECEITA {recipeNum} *************");
                    Console.WriteLine($"\n    Nome da receita: {item.RecipeName}\n\n    Receita testada ? {item.RecipeTested}\n\n    Categoria: {item.Cathegory}\n\n" +
                        $"    Grau de dificuldade: {item.Difficult}\n\n    Tempo de preparo: {item.Duration} minutos\n\n" +
                        $"    Modo de Preparo: {item.Description}\n\n");
                    ingredientes.IngredientRecipe = item.RecipeName;
                    ingredientes.ListIngredients();
                    Console.WriteLine("    Aperte uma tecla para ler a próxima receita");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"\n    RECEITA {recipeNum}: {item.RecipeName}");   // mostrar só os nomes das receitas
                }
                
            }
            if (listHeaders == true)    //testar se foi escolhido para listar somente os nomes das receitas
            {
                listHeaders = false;
                Console.WriteLine("\n\n    Aperte uma tecla para retornar ao menu");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ListRecipeContents(bool listTested) // listar somente receitas testadas
        {

            int recipeNum = 0;  // indicar número da receita a ser listada
            foreach (Receita item in listRecipe)    // ler as receitas
            {
                recipeNum++;    // apontar para ordem da receita a listar
                if (item.RecipeTested == "Sim") // testar se a receita foi testada
                {
                    Console.WriteLine($"\n\n************* RECEITAS TESTADAS ****************");
                    Console.WriteLine($"\n    Nome da receita: {item.RecipeName}\n\n    Categoria: {item.Cathegory}\n\n" +
                        $"    Grau de dificuldade: {item.Difficult}\n\n    Tempo de preparo: {item.Duration} minutos\n\n" +
                        $"    Modo de Preparo: {item.Description}\n\n");
                    ingredientes.IngredientRecipe = item.RecipeName;
                    ingredientes.ListIngredients();
                    Console.WriteLine("    Aperte uma tecla para ler a próxima receita");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            listTested = false;
        }

        public void Exit()  // se não tem mais receitas a inserir
        {
            System.Environment.Exit(0); // sair da aplicação e fechar o console
        }
        #endregion
    }

}

