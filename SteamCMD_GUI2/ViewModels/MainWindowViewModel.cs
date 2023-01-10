using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;

namespace SteamCMD_GUI2.ViewModels
{
    public  class MainWindowViewModel : ViewModelBase
    {
        private string Version => "v0.1.0";
        public string Title => $"SteamCMD GUI 2 {Version}";
        public string Tool => "Workshop Mod Downloader:";
        private string status;
        public string Status
        {
            get => status;
            
            set
            {
                    status = value;
                    OnPropertyChanged();

            }
        }
        public string Prompt => "Enter Workshop Mod URL Address Here";
        public string ButtonLeft => "Open Directory";
        public string ButtonRight => "Start Download";

        private string _path;
        public string Path
        {
            get => _path;
            set
            {
                if (value != _path)
                {
                    _path = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
