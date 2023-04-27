using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPOEPart1
{
    // CLASS FOR INGREDIENTS
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public Ingredient(string name, int quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }

    // CLASS FOR RECIPE
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

        // METHOD FOR ENTERING THE INGREDIENTS FOR THE RECIPE
        public void EnterIngredients()
        {
            // GETTING THE NUMBER OF INGREDIENTS
            Console.WriteLine("Enter the number of ingredients: ");
            numIngredients = Convert.ToInt32(Console.ReadLine());
            ingredients = new Ingredient[numIngredients];

            for (int i = 0; i < numIngredients; i++)



            {
                // GETTING THE NAME OF THE INGREDIENT
                Console.WriteLine("Enter the name of the ingredient: ");
                string name = Console.ReadLine();

                // GETTING THE QUANTITY
                Console.WriteLine("Enter the quantity of " + name + ":");
                int quantity = Convert.ToInt32(Console.ReadLine());

                // GETTING THE UNIT OF MEASUREMENT
                Console.WriteLine("Enter the unit of mesaurement for  " + name + ":");
                string unit = Console.ReadLine();

                ingredients[i] = new Ingredient(name, quantity, unit);
     
            }

        }

        // METHOD FOR GETTING THE STEPS FOR THE RECIPE
        public void EnterSteps()
        {

            // GETTING THE NUMBER OF STEPS FOR THE RECIPE
            Console.WriteLine("Enter the number of steps: ");
            numSteps = Convert.ToInt32(Console.ReadLine());
            steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                int count = i + 1;

                // GETTING THE INSTRUCTIONS FOR EACH STEP FOR THE RECIPE
                Console.Write("Enter step " + count + ": ");
                steps[i] = Console.ReadLine();

            }

        }
        
        // METHOD FOR DISPLAYING THE RECIPE
        public void DisplayRecipe()
        {
            
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");

            //DISPLAYING THE INGREDIENTS FOR THE RECIPE
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine(ingredient.Quantity + ingredient.Unit + "  " + ingredient.Name);

            }

            Console.WriteLine("\nSteps:");

            // DISPLAYS THE NUMBER OF STEPS FOR THE RECIPE
            for (int i = 0; i < numSteps; i++)
            {
                int countstep = i + 1;
                Console.WriteLine("Step " + countstep + ": " + steps[i]);
            }

            // GETTING THE SCALING FACTOR 
            Console.WriteLine("Enter the scaling factor (0.5, 2, or 3) or press E to exit ");
            string exit = Console.ReadLine();

            // A STATEMENT TO DISPLAY THE NEW QUANTITIES FOR THE INGREDIENTS OR TO EXIT THE CONSOLE
            if (exit == "E" || exit == "e")
            {
                Environment.Exit(0);
            }
            else
            {
                DisplayScaleRecipe(exit);
            }

        }

        // DISPLAYS THE SCALE RECIPE
        public void DisplayScaleRecipe(string value)
        {
            double num = double.Parse(value);
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");

            // DISPLAYS THE SCALED UP INGREDIENTS
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine(ingredient.Quantity * num + ingredient.Unit + "  " + ingredient.Name);

            }

            // DISPLAYS THE NUMBER OF STEPS
            Console.WriteLine("\nSteps:");

            for (int i = 0; i < numSteps; i++)
            {
                int countstep = i + 1;
                Console.WriteLine("Step " + countstep + ": " + steps[i]);
            }

            // A IF ELSE STATEMENT TO RESET THE QUANTITIES TO THE ORIGINAL VALUES OR CLEAR THE DATA AND RESTART THE PROCESS OR EXIT THE CONSOLE
            Console.WriteLine("Enter R to reset quantities or C to clear data and restart  or E to exit");
            string exit = Console.ReadLine();
            if (exit == "E" || exit == "e")
            {
                Environment.Exit(0);
            }
            else if(exit == "R"|| exit == "r")
            {
                DisplayRecipe();
            }
            else if(exit == "C"|| exit == "c")
            {
                EnterIngredients();
                EnterSteps();
                DisplayRecipe();
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
            recipe.DisplayRecipe();
        }
    }
}
