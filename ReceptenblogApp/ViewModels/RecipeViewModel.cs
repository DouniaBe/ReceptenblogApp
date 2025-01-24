using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReceptenblogApp.Models;
using ReceptenblogAPP.Services;

namespace ReceptenblogAPP.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Recipe> Recipes { get; set; }

        public RecipeViewModel()
        {
            _apiService = new ApiService();
            Recipes = new ObservableCollection<Recipe>();
        }

        // Haal recepten op van de API
        public async Task LoadRecipesAsync()
        {
            var recipes = await _apiService.GetRecipesAsync();
            Recipes.Clear();
            foreach (var recipe in recipes)
            {
                Recipes.Add(recipe);
            }
        }

        // Voeg recept toe via API
        public async Task AddRecipeAsync(Recipe recipe)
        {
            var success = await _apiService.AddRecipeAsync(recipe);
            if (success)
            {
                Recipes.Add(recipe); // Voeg toe aan de lijst
            }
        }
    }
}
