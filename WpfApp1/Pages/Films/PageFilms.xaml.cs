using BFGM.Classes;
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
        readonly ClassReadFile classReadFile;
        readonly ClassWriteFile classWriteFile;

        PageFilmsFilms pageFilmsFilms;
        PageFilmsSerials pageFilmsSerials;
        PageFilmsCartoons pageFilmsCartoons;

        public PageFilms(ClassMain classMain, ClassReadFile classReadFile, ClassWriteFile classWriteFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
            this.classWriteFile = classWriteFile;
        }

        #region Pages Films
        byte pageActivity;
        private void ButtonFilms_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            pageFilmsFilms = new PageFilmsFilms(classMain, classReadFile);
            FilmsFrame.Content = pageFilmsFilms;
        }

        private void ButtonSerials_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            pageFilmsSerials = new PageFilmsSerials(classMain, classReadFile);
            FilmsFrame.Content = pageFilmsSerials;
        }

        private void ButtonCartoons_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            pageFilmsCartoons = new PageFilmsCartoons(classMain, classReadFile);
            FilmsFrame.Content = pageFilmsCartoons;
        }
        #endregion

        private void ButtonFilmsAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowFilmsFilmAdd windowsFilmAdd = new WindowFilmsFilmAdd(classMain, classWriteFile, pageFilmsFilms);
                windowsFilmAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowFilmsSerialAdd windowsSeriaAdd = new WindowFilmsSerialAdd(classMain, classWriteFile, pageFilmsSerials);
                windowsSeriaAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowFilmsCartoonAdd windowCartoonAdd = new WindowFilmsCartoonAdd(classMain, classWriteFile, pageFilmsCartoons);
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
                    string selectedName = pageFilmsFilms.ListBoxFilms.Items[selectedIndex].ToString();
                    classMain.DeleteFilm(selectedName);
                    await classWriteFile.WriteFileFilms();
                    pageFilmsFilms.ListBoxFilms.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 2)
            {
                int selectedIndex = pageFilmsSerials.ListBoxSerials.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageFilmsSerials.ListBoxSerials.Items[selectedIndex].ToString();
                    classMain.DeleteSerial(selectedName);
                    await classWriteFile.WriteFileSerials();
                    pageFilmsSerials.ListBoxSerials.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 3)
            {
                int selectedIndex = pageFilmsCartoons.ListBoxCartoons.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageFilmsCartoons.ListBoxCartoons.Items[selectedIndex].ToString();
                    classMain.DeleteCartoon(selectedName);
                    await classWriteFile.WriteFileCartoons();
                    pageFilmsCartoons.ListBoxCartoons.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
