using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using ReceptenblogApp;
using ReceptenblogAPP.Services;

namespace ReceptenblogAPP
{
    public class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            // Registreren van services
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<OfflineStorageService>();

            return builder.Build();
        }
    }
}
