using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Recipe
    {
        private string _title;
        private List<string> _ingredients;
        private string _instructions;
        public string Title
        {
            get => _title;
        }
        public List<string> Ingredients
        {
            get => _ingredients;
        }
        public string Instructions
        {
            get => _instructions;
        }
        public Recipe(string title, List<string> ingredients,
            string instructions)
        {
            _title = title;
            _ingredients = ingredients;
            _instructions = instructions;
        }

    }
}
