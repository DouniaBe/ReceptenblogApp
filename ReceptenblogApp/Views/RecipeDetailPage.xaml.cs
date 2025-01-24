using Microsoft.Maui.Controls;
using ReceptenblogApp.ViewModels;
using ReceptenblogAPP.ViewModels;

namespace ReceptenblogApp.Views
{
    public partial class RecipeDetailPage : ContentPage
    {
        private readonly RecipeViewModel _recipeViewModel;

        public RecipeDetailPage(int recipeId)
        {
            InitializeComponent();
            _recipeViewModel = (RecipeViewModel)BindingContext;

            // Laad de recepten details voor de specifieke recipeId
            _recipeViewModel.LoadRecipeDetails(recipeId);
        }
    }
}
