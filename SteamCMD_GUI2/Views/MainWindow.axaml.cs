using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SteamCMD_GUI2.Models;
using SteamCMD_GUI2.ViewModels;

namespace SteamCMD_GUI2.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //runs init and any other future methods inside of our main model
            initalizeApp();
            
        }
        
        private async void initalizeApp()
        {
            var model = new MainModel();
            await model.Init();
            
            var context = DataContext as MainWindowViewModel;
            context.Path = "Started";
            

        }
        private async Task<string> GetPath()
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            
            string? result = await dialog.ShowAsync(this);

            return result;
        }
        public async void open_Directory(object sender,  RoutedEventArgs e)
        {
            string _path = await GetPath();

            var context = DataContext as MainWindowViewModel;
            context.Path = _path;
            
        }
        
        public async void start_Download(object sender, RoutedEventArgs e)
        {
            //download code here
        }
    }
}