using Newtonsoft.Json;
using ReceptenblogApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptenblogApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Recipe> Recipes { get; set; }

        public HomeViewModel()
        {
            _httpClient = new HttpClient();
            Recipes = new ObservableCollection<Recipe>();
            LoadRecipes();
        }

        private async void LoadRecipes()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://localhost:5014//ApiController/recipes");
                var recipes = JsonConvert.DeserializeObject<List<Recipe>>(response);
                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe);
                }
            }
            catch (Exception ex)
            {
                // Foutafhandelingslogica
                Debug.WriteLine($"Error loading recipes: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
