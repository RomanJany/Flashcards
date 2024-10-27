using Flashcards.ViewModels;
using System.Configuration;
using System.Data;
using System.IO;
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
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/FlashcardSets");

            _navigation.CurrentViewModel = new MenuViewModel(_navigation);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigation)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
