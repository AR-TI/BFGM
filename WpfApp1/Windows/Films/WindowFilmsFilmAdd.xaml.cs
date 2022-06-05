using BFGM.Classes;
using BFGM.Models;
using BFGM.Pages.Films;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows.Films
{
    /// <summary>
    /// Логика взаимодействия для WindowFilmsFilmAdd.xaml
    /// </summary>
    public partial class WindowFilmsFilmAdd : Window
    {
        readonly ClassMain classMain;
        readonly ClassWriteFile classWriteFile;
        readonly PageFilmsFilms pageFilmsFilms;

        public WindowFilmsFilmAdd(ClassMain classMain, ClassWriteFile classWriteFile, PageFilmsFilms pageFilmsFilms)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageFilmsFilms = pageFilmsFilms;
            TextBoxFilm.Focus();
        }

        private async void ButtonFilmAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddFilm();
        }

        private async void WindowsFilmAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddFilm();
            }
        }

        private async Task AddFilm()
        {
            string title = TextBoxFilm.Text;
            if (title.Length != 0)
            {
                classMain.ListFilms.Add(new Film(title));
                await classWriteFile.WriteFileFilms();
                pageFilmsFilms.FillListFilms();
                Close();
            }
        }
    }
}
