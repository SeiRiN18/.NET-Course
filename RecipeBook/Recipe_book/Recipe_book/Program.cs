

using Application.Abstractions;
using Core.Models;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Recipe_book

{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceCollection();

            container.AddSingleton<IUserRepository, UserRepository>();
            container.AddSingleton<IBookRepository, BookRepository>();

            container.AddSingleton<IUserService, UserService>();
            container.AddSingleton<IBookService, BookService>();
            container.AddSingleton<IRecipeService, RecipeService>();

            var provider = container.BuildServiceProvider();

            var userService = provider.GetService<IUserService>();
            var bookService = provider.GetService<IBookService>();
            var recipeService = provider.GetService<IRecipeService>();
            

           

        }
    }
}
