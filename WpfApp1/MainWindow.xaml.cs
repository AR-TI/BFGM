using System.Windows;
using BFGM.Classes;
using BFGM.Pages;

namespace BFGM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassReadingFile classReadingFile;
        ClassWritingFile classWritingFile;

        public MainWindow()
        {
            InitializeComponent();
            ClassMain classMain = new ClassMain();
            classReadingFile = new ClassReadingFile(classMain);
            classWritingFile = new ClassWritingFile(classMain);
        }

        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new PageHome();
        }

        private void Button_Click_Books(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new PageBooks(classReadingFile, classWritingFile);
        }

        private void Button_Click_Films(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new PageFilms(classReadingFile, classWritingFile);
        }

        private void Button_Click_Games(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new PageGames(classReadingFile, classWritingFile);
        }

        private void Button_Click_Music(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new PageMusic(classReadingFile, classWritingFile);
        }
    }
}
