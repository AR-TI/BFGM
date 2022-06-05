using BFGM.Classes;
using BFGM.Constants;
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
        readonly PageFilmsFilms pageFilmsFilms;

        public WindowFilmsFilmAdd(ClassMain classMain, PageFilmsFilms pageFilmsFilms)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageFilmsFilms = pageFilmsFilms;
            TextBoxFilm.Focus();
        }

        private async Task AddFilm()
        {
            string title = Functions.ToTitleCaseFirstWord(TextBoxFilm.Text);
            if (title.Length != 0)
            {
                await classMain.Add(classMain.ListFilms, new Film(title));
                await classMain.Write(classMain.ListFilms, PathFiles.FilmsPath);
                pageFilmsFilms.FillListFilms();
                Close();
            }
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
    }
}
