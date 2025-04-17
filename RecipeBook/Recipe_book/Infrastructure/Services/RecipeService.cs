using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeService _bookRecipeService;
        public RecipeService(IRecipeService bookRecipeService)
        {
            _bookRecipeService = bookRecipeService;
        }
        public void Publish()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void View()
        {
            throw new NotImplementedException();
        }
    }
}
