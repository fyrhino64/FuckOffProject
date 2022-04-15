using System;
using System.Threading;
using FuckOffProject.Clients;
using FuckOffProject.Context;
using FuckOffProject.Components;
using System.Threading.Tasks;

namespace FuckOffProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("This is a console app that will look up recipes based on an ingredient you provide!");
            Console.WriteLine("\n");
            Console.WriteLine("-----------------------");
            Console.WriteLine("To begin, please enter your name: ");
            var userName = Console.ReadLine();
            Console.WriteLine("Please enter the ingredient you would like to search recipes for: ");
            var ingredeintName = Console.ReadLine();
            Thread.Sleep(1000);
            Console.WriteLine($"Please wait while we query our recipe database for {ingredeintName}...");
            Console.WriteLine("---------------------------------------");
            SearchIngredient(ingredeintName);

              void SearchIngredient(string ingredientName)
            {
                char recipeIndicator = 'R';
                var component = new SpoonComponent(new RecipeContext(), new SpoonClients());
                var recipes = component.GetRecipesByIngredient(ingredientName, recipeIndicator).ToArray();
                Console.WriteLine($"We found {recipes.Length} recipes for your ingredient: {ingredientName}");
                if (recipes.Length == 0)
                {
                    Console.WriteLine("---------------------------------------");
                    var effOffGenerator = new FuckOffComponent(new FuckOffMessageContext(), new FuckOffClient());
                    var randomizer = new Random();
                    var chooser = randomizer.Next(2);
                    var fuckOff = effOffGenerator.GetChoiceAndCallEndPoint(userName, chooser);
                    Console.WriteLine(fuckOff.Result.Result.message);
                    Console.WriteLine(fuckOff.Result.Result.subtitle);
                }
                else
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Please enter the number for the following found recipes: ");
                    var i = 0;
                    foreach (var recipe in recipes)
                    {
                        Console.WriteLine($"Please enter {i} to select {recipe.Title}");
                        i++;
                    }
                    var recipeChoice = Convert.ToInt32(Console.ReadLine());
                    var recipeChoiceTitle = recipes[recipeChoice].Title;
                    Console.WriteLine($" You chose {recipeChoiceTitle}");
                    var callindicator = 'I';
                    var recipeDetail = component.GetRecipeDetailsById(recipes[recipeChoice].Id, callindicator);
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine($"{recipeChoiceTitle} has {recipeDetail.ExtendedIngredients.Count} ingredients");
                    var ingredientList = recipeDetail.ExtendedIngredients;
                    foreach (var ingredient in ingredientList)
                    {
                        Console.WriteLine($"{ingredient.Amount} {ingredient.Unit} {ingredient.Name}");
                        Console.WriteLine("");
                    }
                    Console.WriteLine($"To Make {recipeChoiceTitle}: ");
                    Console.WriteLine($"{ recipeDetail.instructions}");
                }

            }
        }
        
    }
}
