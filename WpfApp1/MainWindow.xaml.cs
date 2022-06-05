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
        readonly ClassReadFile classReadingFile;
        readonly ClassWriteFile classWritingFile;

        public MainWindow()
        {
            InitializeComponent();
            classMain = new ClassMain();
            classMain.CheckDirectoryAndFilesExist();
            classReadingFile = new ClassReadFile(classMain);
            classWritingFile = new ClassWriteFile(classMain);
        }

        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageHome();
        }

        private void Button_Click_Books(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageBooks(classMain, classReadingFile, classWritingFile);
        }

        private void Button_Click_Films(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageFilms(classMain, classReadingFile, classWritingFile);
        }

        private void Button_Click_Games(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageGames(classMain, classReadingFile, classWritingFile);
        }

        private void Button_Click_Music(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageMusic(classMain, classReadingFile, classWritingFile);
        }
    }
}
