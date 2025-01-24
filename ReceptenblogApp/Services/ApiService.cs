using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReceptenblogApp.Models;

namespace ReceptenblogAPP.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "http://localhost:5014/ApiControllers/";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        // Haal een lijst van recepten op van de API
        public async Task<List<Recipe>> GetRecipesAsync()
        {
            var response = await _httpClient.GetStringAsync($"{ApiBaseUrl}RecipesController");
            return JsonConvert.DeserializeObject<List<Recipe>>(response);
        }

        // Haal details op van een specifiek recept
        public async Task<Recipe> GetRecipeDetailsAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"{ApiBaseUrl}RecipesController/{id}");
            return JsonConvert.DeserializeObject<Recipe>(response);
        }

        // Voeg een nieuw recept toe via de API
        public async Task<bool> AddRecipeAsync(Recipe recipe)
        {
            var json = JsonConvert.SerializeObject(recipe);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{ApiBaseUrl}RecipesController", content);
            return response.IsSuccessStatusCode;
        }

        // Haal een lijst van categorieën op van de API
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetStringAsync($"{ApiBaseUrl}CategoriesController");
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }

        // Haal details van een specifieke categorie op
        public async Task<Category> GetCategoryDetailsAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"{ApiBaseUrl}CategoriesController/{id}");
            return JsonConvert.DeserializeObject<Category>(response);
        }

        // Registreer een gebruiker via de API
        public async Task<bool> RegisterAsync(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{ApiBaseUrl}AccountsController/register", content);
            return response.IsSuccessStatusCode;
        }

        // Log een gebruiker in via de API
        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginData = new { username, password };
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{ApiBaseUrl}AccountsController/login", content);
            return response.IsSuccessStatusCode;
        }

        // Voeg een commentaar toe via de API
        public async Task<bool> AddCommentAsync(Comment comment)
        {
            var json = JsonConvert.SerializeObject(comment);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{ApiBaseUrl}CommentsController", content);
            return response.IsSuccessStatusCode;
        }
    }
}
