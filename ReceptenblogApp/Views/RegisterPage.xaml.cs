using Microsoft.Maui.Controls;
using ReceptenblogApp.ViewModels;
using ReceptenblogAPP.ViewModels;

namespace ReceptenblogAPP.Views
{
    public partial class RegisterPage : ContentPage
    {
        private readonly AuthViewModel _authViewModel;

        public RegisterPage()
        {
            InitializeComponent();
            _authViewModel = (AuthViewModel)BindingContext;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            var confirmPassword = ConfirmPasswordEntry.Text;

            // Voeg logica toe voor registratie en check of het wachtwoord overeenkomt
            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            bool isSuccess = await _authViewModel.Register(username, password);

            if (isSuccess)
            {
                // Navigeren naar de LoginPage na registratie
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Error", "Registration failed. Try again.", "OK");
            }
        }
    }
}
