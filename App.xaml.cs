using Flashcards.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Flashcards
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Navigation _navigation;

        public App()
        {
            _navigation = new Navigation();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigation.CurrentViewModel = new MenuViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigation)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
