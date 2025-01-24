using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptenblogApp.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string _appTheme;
        private bool _notificationsEnabled;

        public string AppTheme
        {
            get => _appTheme;
            set
            {
                _appTheme = value;
                OnPropertyChanged(nameof(AppTheme));
            }
        }

        public bool NotificationsEnabled
        {
            get => _notificationsEnabled;
            set
            {
                _notificationsEnabled = value;
                OnPropertyChanged(nameof(NotificationsEnabled));
            }
        }

        public SettingsViewModel()
        {
            // Load settings from storage (or set default values)
            AppTheme = "Light"; // Example default
            NotificationsEnabled = true; // Example default
        }

        public void SaveSettings()
        {
            // Save settings (to storage, preferences, etc.)
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
