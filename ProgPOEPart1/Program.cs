using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPOEPart1
{
    class Ingredient
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public Ingredient(string name, int quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
    class Recipe
    {
        private int numIngredients;
        private Ingredient[] ingredients;
        private int numSteps;
        private string[] steps;

        public Recipe()
        {
            numIngredients = 0;
            numSteps = 0;
            
        }

        public void EnterIngredients()
        {
            Console.WriteLine("Enter the number of ingredients: ");
            numIngredients = Convert.ToInt32(Console.ReadLine());
            ingredients = new Ingredient[numIngredients];

            for (int i = 0; i < numIngredients; i++)

            {
                Console.WriteLine("Enter the name of the ingredient: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the quantity of " + name + ":");
                int quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the unit of mesaurement for  " + name + ":");
                string unit = Console.ReadLine();

                ingredients[i] = new Ingredient(name, quantity, unit);
     
            }

        }

        public void EnterSteps()
        {
            Console.WriteLine("Enter the number of steps: ");
            numSteps = Convert.ToInt32(Console.ReadLine());
            steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                int count = i + 1;
                Console.Write("Enter step " + count + ": ");
                steps[i] = Console.ReadLine();

            }

        }
        
        public void DispllayRecipe()
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");

            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine(ingredient.Quantity + ingredient.Unit + "  " + ingredient.Name);

            }

            Console.WriteLine("\nSteps:");

            for (int i = 0; i < numSteps; i++)
            {
                int countstep = i + 1;
                Console.WriteLine("Step " + countstep + ": " + steps[i]);
            }

                //foreach (var item in steps)
                //{
                //    int countstep = 1;
                //    Console.WriteLine("Step" + countstep + ": " + item.); 
                //}


                Console.WriteLine("type any value to exit");
            string exit = Console.ReadLine();
            if (exit!=null) 
            {
                Environment.Exit(0);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            recipe.EnterIngredients();
            recipe.EnterSteps();
            recipe.DispllayRecipe();
        }
    }
}
