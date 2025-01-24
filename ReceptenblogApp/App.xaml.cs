using Microsoft.Maui.Controls;
using ReceptenblogApp;
using ReceptenblogAPP.Services;

namespace ReceptenblogAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Stel services in
            DependencyService.Register<ApiService>();
            DependencyService.Register<AuthService>();
            DependencyService.Register<OfflineStorageService>();

            MainPage = new AppShell();
        }
    }
}
