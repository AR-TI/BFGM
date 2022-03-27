using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;

namespace BFGM.Pages.Films
{
    /// <summary>
    /// Логика взаимодействия для PageFilmsFilms.xaml
    /// </summary>
    public partial class PageFilmsFilms : Page
    {
        ClassReadFile classReadingFile;

        public PageFilmsFilms(ClassReadFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxFilms_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadFileFilms();
                isFirstTime = true;
            }
            FillListFilms();
        }

        public void FillListFilms()
        {
            ListBoxFilms.Items.Clear();
            List<Film> listFilms = classReadingFile.ClassMainInfo.ListFilms.OrderBy(x => x.Title).ToList();
            for (int i = 0; i < listFilms.Count; i++)
            {
                ListBoxFilms.Items.Add(listFilms[i].Title);
            }
        }

        bool isDescending = false;
        private void ButtonSortFilms_Click(object sender, RoutedEventArgs e)
        {
            List<Film> listFilms = classReadingFile.ClassMainInfo.ListFilms;
            if (!isDescending)
            {
                ListBoxFilms.Items.Clear();
                List<Film> sorted = listFilms.OrderByDescending(x => x.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxFilms.Items.Add(sorted[i].Title);
                }
                isDescending = true;
            }
            else
            {
                ListBoxFilms.Items.Clear();
                List<Film> sorted = listFilms.OrderBy(x => x.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxFilms.Items.Add(sorted[i].Title);
                }
                isDescending = false;
            }
        }

        private void ListBoxFilms_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxFilms.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxFilms.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
