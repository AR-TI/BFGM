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
        ClassReadingFile classReadingFile;

        public PageFilmsFilms(ClassReadingFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxFilmsFilms_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileFilmsFilms();
                isFirstTime = true;
            }
            FillListFilmsFilms();
        }

        bool isAscending = false;
        private void ButtonAscendingFilms_Click(object sender, RoutedEventArgs e)
        {
            List<ModelFilmsFilms> listFilmsFilms = classReadingFile.ClassMainInfo.ListFilmsFilms;
            if (!isAscending)
            {
                ListBoxFilmsFilms.Items.Clear();
                var sorted = listFilmsFilms.OrderBy(x => x.NameFilmsFilm).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxFilmsFilms.Items.Add(sorted[i].NameFilmsFilm);
                }
                isAscending = true;
            }
            else
            {
                ListBoxFilmsFilms.Items.Clear();
                var sorted = listFilmsFilms.OrderByDescending(x => x.NameFilmsFilm).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxFilmsFilms.Items.Add(sorted[i].NameFilmsFilm);
                }
                isAscending = false;
            }
        }

        public void FillListFilmsFilms()
        {
            ListBoxFilmsFilms.Items.Clear();
            List<ModelFilmsFilms> listFilmsFilms = classReadingFile.ClassMainInfo.ListFilmsFilms.OrderByDescending(x => x.NameFilmsFilm.Length).ToList();
            for (int i = 0; i < listFilmsFilms.Count; i++)
            {
                ListBoxFilmsFilms.Items.Add(listFilmsFilms[i].NameFilmsFilm);
            }
        }

        private void ListBoxFilmsFilms_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxFilmsFilms.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxFilmsFilms.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
