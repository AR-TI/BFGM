using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Films;

namespace BFGM.Windows.Films
{
    /// <summary>
    /// Логика взаимодействия для WindowFilmsFilmAdd.xaml
    /// </summary>
    public partial class WindowFilmsFilmAdd : Window
    {
        ClassWriteFile classWritingFile;
        PageFilmsFilms pageFilmsFilms;

        public WindowFilmsFilmAdd(ClassWriteFile classWritingFile, PageFilmsFilms pageFilmsFilms)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageFilmsFilms = pageFilmsFilms;
            TextBoxFilm.Focus();
        }

        private void ButtonFilmAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddFilm();
        }

        private void WindowsFilmAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddFilm();
            }
        }

        private void AddFilm()
        {
            string title = TextBoxFilm.Text;
            if (title.Length != 0)
            {
                classWritingFile.WriteFileFilms(title);
                pageFilmsFilms.FillListFilms();
                Close();
            }
        }
    }
}
