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

        ClassWritingFile classWritingFile;
        ClassReadingFile classReadingFile;

        public PageFilms(ClassReadingFile classReadingFile, ClassWritingFile classWritingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
            this.classWritingFile = classWritingFile;
        }

        #region Pages Films
        byte pageActivity;
        private void Button_Click_FilmsFilms(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            //frameFilms.Content = new PageFilmsFilms();
            pageFilmsFilms = new PageFilmsFilms(classReadingFile);
            frameFilms.Content = pageFilmsFilms;
        }
        private void Button_Click_FilmsSerials(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            //frameFilms.Content = new PageFilmsSerials();
            pageFilmsSerials = new PageFilmsSerials(classReadingFile);
            frameFilms.Content = pageFilmsSerials;
        }
        private void Button_Click_FilmsCartoons(object sender, RoutedEventArgs e)
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
                WindowFilmsFilmAdd windowsFilmsFilmAdd = new WindowFilmsFilmAdd(classWritingFile, pageFilmsFilms);
                windowsFilmsFilmAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowFilmsSerialAdd windowsFilmsSeriaAdd = new WindowFilmsSerialAdd(classWritingFile, pageFilmsSerials);
                windowsFilmsSeriaAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowFilmsCartoonAdd windowFilmsCartoonAdd = new WindowFilmsCartoonAdd(classWritingFile, pageFilmsCartoons);
                windowFilmsCartoonAdd.ShowDialog();
            }
        }

        private void ButtonFilmsDelete_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                int selectedIndex = pageFilmsFilms.ListBoxFilmsFilms.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageFilmsFilms.ListBoxFilmsFilms.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteFilmsFilms(selectedName);
                    classWritingFile.RewritingFileAfterDeleteFilmsFilms();
                    pageFilmsFilms.ListBoxFilmsFilms.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 2)
            {
                int selectedIndex = pageFilmsSerials.ListBoxFilmsSerials.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageFilmsSerials.ListBoxFilmsSerials.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteFilmsSerials(selectedName);
                    classWritingFile.RewritingFileAfterDeleteFilmsSerials();
                    pageFilmsSerials.ListBoxFilmsSerials.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 3)
            {
                int selectedIndex = pageFilmsCartoons.ListBoxFilmsCartoons.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageFilmsCartoons.ListBoxFilmsCartoons.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteFilmsCartoons(selectedName);
                    classWritingFile.RewritingFileAfterDeleteFilmsCartoons();
                    pageFilmsCartoons.ListBoxFilmsCartoons.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
