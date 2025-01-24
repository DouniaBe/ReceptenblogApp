using Newtonsoft.Json;
using ReceptenblogApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ReceptenblogApp.ViewModels
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<User> Users { get; set; }

        public AuthViewModel()
        {
            _httpClient = new HttpClient();
            Users = new ObservableCollection<User>();
        }

        public async Task<bool> Login(string username, string password)
        {
            var loginData = new { Username = username, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://localhost:5014//ApiController/accountControlleur", content);
                if (response.IsSuccessStatusCode)
                {
                    // Haal gebruikersgegevens op of geef succesmelding
                    return true;
                }
                else
                {
                    // Foutafhandelingslogica
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Foutafhandelingslogica
                Debug.WriteLine($"Login failed: {ex.Message}");
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


}
