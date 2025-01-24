using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReceptenblogApp.Models;

namespace ReceptenblogAPP.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private const string AuthBaseUrl = "http://localhost:5014/ApiControllers/";

        public AuthService()
        {
            _httpClient = new HttpClient();
        }

        // Log een gebruiker in
        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginData = new { username, password };
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{AuthBaseUrl}AccountsController/login", content);
            return response.IsSuccessStatusCode;
        }

        // Registreer een nieuwe gebruiker
        public async Task<bool> RegisterAsync(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{AuthBaseUrl}AccountsController/register", content);
            return response.IsSuccessStatusCode;
        }
    }
}
