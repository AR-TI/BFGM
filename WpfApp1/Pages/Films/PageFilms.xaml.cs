using System.Windows;
using System.Windows.Controls;
using BFGM.Pages.Films;
using BFGM.Windows.Films;

namespace BFGM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageFilms.xaml
    /// </summary>
    public partial class PageFilms : Page
    {
        PageFilmsFilms pageFilmsFilms;
        PageFilmsSerials pageFilmsSerials;
        PageFilmsCartoons pageFilmsCartoons;

        ClassWriteFile classWritingFile;
        ClassReadFile classReadingFile;

        public PageFilms(ClassReadFile classReadingFile, ClassWriteFile classWritingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
            this.classWritingFile = classWritingFile;
        }

        #region Pages Films
        byte pageActivity;
        private void ButtonFilms_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            //frameFilms.Content = new PageFilmsFilms();
            pageFilmsFilms = new PageFilmsFilms(classReadingFile);
            frameFilms.Content = pageFilmsFilms;
        }

        private void ButtonSerials_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            //frameFilms.Content = new PageFilmsSerials();
            pageFilmsSerials = new PageFilmsSerials(classReadingFile);
            frameFilms.Content = pageFilmsSerials;
        }

        private void ButtonCartoons_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            //frameFilms.Content = new PageFilmsCartoons();
            pageFilmsCartoons = new PageFilmsCartoons(classReadingFile);
            frameFilms.Content = pageFilmsCartoons;
        }
        #endregion

        private void ButtonFilmsAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowFilmsFilmAdd windowsFilmAdd = new WindowFilmsFilmAdd(classWritingFile, pageFilmsFilms);
                windowsFilmAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowFilmsSerialAdd windowsSeriaAdd = new WindowFilmsSerialAdd(classWritingFile, pageFilmsSerials);
                windowsSeriaAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowFilmsCartoonAdd windowCartoonAdd = new WindowFilmsCartoonAdd(classWritingFile, pageFilmsCartoons);
                windowCartoonAdd.ShowDialog();
            }
        }

        private void ButtonFilmsDelete_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                int selectedIndex = pageFilmsFilms.ListBoxFilms.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageFilmsFilms.ListBoxFilms.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteFilm(selectedName);
                    classWritingFile.RewriteFileAfterDeleteFilms();
                    pageFilmsFilms.ListBoxFilms.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 2)
            {
                int selectedIndex = pageFilmsSerials.ListBoxSerials.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageFilmsSerials.ListBoxSerials.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteSerial(selectedName);
                    classWritingFile.RewriteFileAfterDeleteSerials();
                    pageFilmsSerials.ListBoxSerials.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 3)
            {
                int selectedIndex = pageFilmsCartoons.ListBoxCartoons.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageFilmsCartoons.ListBoxCartoons.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteCartoon(selectedName);
                    classWritingFile.RewriteFileAfterDeleteCartoons();
                    pageFilmsCartoons.ListBoxCartoons.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
