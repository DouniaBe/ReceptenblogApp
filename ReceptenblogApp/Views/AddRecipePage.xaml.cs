using Microsoft.Maui.Controls;
using ReceptenblogApp.ViewModels;
using ReceptenblogAPP.ViewModels;

namespace ReceptenblogApp.Views
{
    public partial class AddRecipePage : ContentPage
    {
        private readonly RecipeViewModel _recipeViewModel;

        public AddRecipePage()
        {
            InitializeComponent();
            _recipeViewModel = (RecipeViewModel)BindingContext;
        }

        private async void OnSaveRecipeClicked(object sender, EventArgs e)
        {
            var recipeName = RecipeNameEntry.Text;
            var ingredients = IngredientsEntry.Text;
            var instructions = InstructionsEditor.Text;

            // Voeg logica toe voor het toevoegen van een nieuw recept
            var success = await _recipeViewModel.AddRecipe(recipeName, ingredients, instructions);

            if (success)
            {
                // Navigeren naar de HomePage of een ander scherm
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Failed to add recipe. Try again.", "OK");
            }
        }
    }
}
