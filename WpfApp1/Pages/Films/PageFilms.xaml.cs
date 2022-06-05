using BFGM.Classes;
using BFGM.Constants;
using BFGM.Models;
using BFGM.Pages.Films;
using BFGM.Windows.Films;
using System.Windows;
using System.Windows.Controls;

namespace BFGM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageFilms.xaml
    /// </summary>
    public partial class PageFilms : Page
    {
        readonly ClassMain classMain;

        PageFilmsFilms pageFilmsFilms;
        PageFilmsSerials pageFilmsSerials;
        PageFilmsCartoons pageFilmsCartoons;

        public PageFilms(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        #region Pages Films
        byte pageActivity;
        private void ButtonFilms_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            pageFilmsFilms = new PageFilmsFilms(classMain);
            FilmsFrame.Content = pageFilmsFilms;
        }

        private void ButtonSerials_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            pageFilmsSerials = new PageFilmsSerials(classMain);
            FilmsFrame.Content = pageFilmsSerials;
        }

        private void ButtonCartoons_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            pageFilmsCartoons = new PageFilmsCartoons(classMain);
            FilmsFrame.Content = pageFilmsCartoons;
        }
        #endregion

        private void ButtonFilmsAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowFilmsFilmAdd windowsFilmAdd = new WindowFilmsFilmAdd(classMain, pageFilmsFilms);
                windowsFilmAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowFilmsSerialAdd windowsSeriaAdd = new WindowFilmsSerialAdd(classMain, pageFilmsSerials);
                windowsSeriaAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowFilmsCartoonAdd windowCartoonAdd = new WindowFilmsCartoonAdd(classMain, pageFilmsCartoons);
                windowCartoonAdd.ShowDialog();
            }
        }

        private async void ButtonFilmsDelete_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                int selectedIndex = pageFilmsFilms.ListBoxFilms.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = pageFilmsFilms.ListBoxFilms.Items[selectedIndex];
                    Film film = data as Film;
                    await classMain.Remove(classMain.ListFilms, film);
                    await classMain.Write(classMain.ListFilms, PathFiles.FilmsPath);
                    pageFilmsFilms.FillListFilms();
                }
            }
            if (pageActivity == 2)
            {
                int selectedIndex = pageFilmsSerials.ListBoxSerials.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = pageFilmsSerials.ListBoxSerials.Items[selectedIndex];
                    Serial serial = data as Serial;
                    await classMain.Remove(classMain.ListSerials, serial);
                    await classMain.Write(classMain.ListSerials, PathFiles.SerialsPath);
                    pageFilmsSerials.FillListSerials();
                }
            }
            if (pageActivity == 3)
            {
                int selectedIndex = pageFilmsCartoons.ListBoxCartoons.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = pageFilmsCartoons.ListBoxCartoons.Items[selectedIndex];
                    Cartoon cartoon = data as Cartoon;
                    await classMain.Remove(classMain.ListCartoons, cartoon);
                    await classMain.Write(classMain.ListCartoons, PathFiles.CartoonsPath);
                    pageFilmsCartoons.FillListCartoons();
                }
            }
        }
    }
}
