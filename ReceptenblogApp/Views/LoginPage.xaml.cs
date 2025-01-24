using Microsoft.Maui.Controls;
using System;
using ReceptenblogApp.ViewModels;
using ReceptenblogApp.Views;

namespace ReceptenblogApp.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthViewModel _authViewModel;

        public LoginPage()
        {
            InitializeComponent();
            _authViewModel = (AuthViewModel)BindingContext;
        }

        // Event voor Login knop
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            bool isSuccess = await _authViewModel.Login(username, password);

            if (isSuccess)
            {
                // Navigeren naar de HomePage of een andere pagina
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                // Toon een foutmelding bij mislukte login
                await DisplayAlert("Error", "Login failed. Please check your credentials.", "OK");
            }
        }

        // Event voor Register knop
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Navigeren naar de RegisterPage
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
