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
        ClassWritingFile classWritingFile;
        PageFilmsFilms pageFilmsFilms;

        public WindowFilmsFilmAdd(ClassWritingFile classWritingFile, PageFilmsFilms pageFilmsFilms)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageFilmsFilms = pageFilmsFilms;
            TextBoxFilmsFilm.Focus();
        }

        private void ButtonFilmsFilmAddOK_Click(object sender, RoutedEventArgs e)
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
            string nameFilmsFilm = TextBoxFilmsFilm.Text;
            if (nameFilmsFilm.Length != 0)
            {
                classWritingFile.WritingFileFilmsFilms(nameFilmsFilm);
                pageFilmsFilms.FillListFilmsFilms();
                Close();
            }
        }
    }
}
