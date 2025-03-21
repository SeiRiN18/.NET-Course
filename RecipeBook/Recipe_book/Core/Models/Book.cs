using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Book
    {
        public string _title;
        public string _author;
        public string _description;
        public List<Recipe> _recipes;

        public string Title
        {
            get => _title;
        }
        public string Author
        {
            get => _author;
        }
        public string Description
        {
            get => _description;
        }
        public List<Recipe> Recipes
        {
            get => _recipes;
        }

        public Book(string title, string author, string description)
        {
            _title = title;
            _author = author;
            _description = description;
            _recipes = new List<Recipe>();
        }


    }
}
