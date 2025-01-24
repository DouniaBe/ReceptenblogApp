using Microsoft.Maui.Controls;
using ReceptenblogApp.ViewModels;

namespace ReceptenblogAPP.Views
{
    public partial class SettingsPage : ContentPage
    {
        private readonly SettingsViewModel _settingsViewModel;

        public SettingsPage()
        {
            InitializeComponent();
            _settingsViewModel = (SettingsViewModel)BindingContext;
        }

        // Voeg hier extra eventhandlers toe voor het opslaan van instellingen
        private void OnSaveSettingsClicked(object sender, EventArgs e)
        {
            // Stel instellingen op basis van de UI in
            bool areNotificationsEnabled = NotificationSwitch.IsToggled;

            // Logica om instellingen op te slaan
            // _settingsViewModel.SaveSettings(areNotificationsEnabled);
        }
    }
}
