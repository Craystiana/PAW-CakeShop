using CakeShop.Web.DataAccess.Entities;
using CakeShop.Web.DataAccess.Repository;
using CakeShop.Web.Models.Ingredient;

namespace CakeShop.Web.Services
{
    public class IngredientService
    {
        private readonly IRepository<Ingredient> _ingredientRepository;

        public IngredientService(IRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public Ingredient GetIngredient(string ingredientName)
        {
            return _ingredientRepository.SingleOrDefault(pi => pi.Name.ToLower() == ingredientName.ToLower());
        }

        public Ingredient Add(string ingredientName)
        {
            _ingredientRepository.Add(new Ingredient
            {
                Name = ingredientName
            });

            _ingredientRepository.SaveChanges();

            return _ingredientRepository.SingleOrDefault(pi => pi.Name == ingredientName);
        }
    }
}
