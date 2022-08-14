using System;
using CommunityToolkit.Mvvm.Input;

namespace SteamCMD_GUI2.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private string Version => "v0.1.0";
        public string Title => $"SteamCMD GUI 2 {Version}";
        public string Tool => "Workshop Mod Downloader:";
        public string Status => "Starting...";
        public string Prompt => "Enter Workshop Mod URL Address Here";
        public string ButtonLeft => "Open Directory";
        public string ButtonRight => "Start Download";
        
    }
}
