using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPOEPart1
{
    internal class Program
    {
        static List<Recipe> recipes;
        static void Main(string[] args)
        {
            recipes = new List<Recipe>();
            bool exit = false; // loop control variable

            while (!exit)
            {
                Console.WriteLine("1 - Enter the recipe details");
                Console.WriteLine("2 - Display the list of recipes");
                Console.WriteLine("3 - Choose the recipe to display");
                Console.WriteLine("4 - Exit");

                Console.WriteLine("Enter your choice >>>");
                string choice = Console.ReadLine();

                //switch
                switch (choice)
                {
                    case "1": EnterDetails(); break;
                    case "2": DisplayRec(); break;
                    case "3": ChooseRec(); break;
                    case "4": Exit(); break;
                    default: Console.WriteLine("Invalid selection try again"); break;
                }
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }
        private static void ChooseRec()
        {
            Console.WriteLine("Choose a recipe to display");
            DisplayRec();// pulls the method with all the details
            Console.WriteLine("Enter the recipe name >>> ");
            string recName = Console.ReadLine();

            Recipe rec = recipes.FirstOrDefault(r => r.Name == recName);
            if (rec != null)
            {// conversion
                DisplayRecipe(rec); //pull the method
            }
        }

        private static void DisplayRec()
        {
            List<string> recNames = recipes.Select(r => r.Name).OrderBy(name => name).ToList();

            //printing out whats in the the lists
            foreach (var item in recNames)
            {
                Console.WriteLine(item);
            }
        }

        static void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine("Recipe details: ");
            Console.WriteLine($"Name: {recipe.Name}");
            Console.WriteLine("Ingredients: ");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity}" + $"{ingredient.Unit}" + $"{ingredient.Name}" + $"{ingredient.Calories}" + $"{ingredient.FoodGroup}");

            }
            Console.WriteLine("Steps");
            foreach (var step in recipe.steps)
            {
                Console.WriteLine($"{step.Description}");
            }
            int totalCalories = recipe.Ingredients.Sum(ingredient => ingredient.Calories);
            Console.WriteLine($"Total Caloreis: {totalCalories}");
            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: The recipe has exceeded 300 cals");
            }
        }

        private static void EnterDetails()
        {
            //obj recipe class
            Recipe rec = new Recipe();
            rec.Ingredients = new List<Ingredient>();
            rec.steps = new List<Step>();
            Console.WriteLine("Enter the recipe name >>>");
            rec.Name = Console.ReadLine();

            Console.WriteLine("Enter number of ingredients");
            int numIngreds = Int32.Parse(Console.ReadLine());

            // name / qnty / unit / food groups

            for (int i = 0; i < numIngreds; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.WriteLine("Unit: ");
                string unit = Console.ReadLine();
                Console.WriteLine("Calories: ");
                int calories = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Food Group: ");
                string foodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient()
                {
                    Name = name,
                    Quantity = quantity,
                    Unit = unit,
                    Calories = calories,
                    FoodGroup = foodGroup,
                };

                rec.Ingredients.Add(ingredient);
            }
            // for loop ends
            Console.WriteLine("Enter the number of steps >>>");
            int numSteps = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}");
                Console.WriteLine("Description:");
                string description = Console.ReadLine();

                //now add it into the list of steps

                Step step = new Step()
                {
                    Description = description
                };
                rec.steps.Add(step);
            }
            //loop ends
            recipes.Add(rec);
            Console.WriteLine("Recipe details captured successfully");
        }
    }
}