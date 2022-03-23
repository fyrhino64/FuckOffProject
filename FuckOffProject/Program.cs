using System;
using System.Threading;
using RestSharp;
using FuckOffProject.Clients;


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
                var client = new SpoonClients();
                var recipes = client.GetRecipesByIngredient(ingredientName).ToArray();
                Console.WriteLine($"We found {recipes.Length} recipes for your ingredient: {ingredientName}");
                if (recipes.Length == 0)
                {
                    Console.WriteLine("---------------------------------------");
                    var effOffClient = new FuckOffClient();
                    var fuckOff = effOffClient.GenericFuckOff();
                    Console.WriteLine(fuckOff.message);
                    Console.WriteLine(fuckOff.subtitle);
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
                }

            }
        }

        
    }
}
