using BFGM.Classes;
using BFGM.Pages;
using System.Windows;

namespace BFGM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ClassMain classMain;

        public MainWindow()
        {
            InitializeComponent();
            classMain = new ClassMain();
            classMain.CheckDirectoryAndFilesExist();
        }

        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageHome();
        }

        private void Button_Click_Books(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageBooks(classMain);
        }

        private void Button_Click_Films(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageFilms(classMain);
        }

        private void Button_Click_Games(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageGames(classMain);
        }

        private void Button_Click_Music(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageMusic(classMain);
        }
    }
}
