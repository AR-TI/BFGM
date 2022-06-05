using BFGM.Classes;
using BFGM.Constants;
using BFGM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BFGM.Pages.Films
{
    /// <summary>
    /// Логика взаимодействия для PageFilmsFilms.xaml
    /// </summary>
    public partial class PageFilmsFilms : Page
    {
        readonly ClassMain classMain;

        public PageFilmsFilms(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        public void FillListFilms()
        {
            ListBoxFilms.ItemsSource = classMain.ListFilms.OrderBy(x => x.Title).ToList();
        }

        private bool isFirstTime = false;
        private async void ListBoxFilms_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListFilms = await classMain.Read<Film>(PathFiles.FilmsPath);
                isFirstTime = true;
            }

            FillListFilms();
        }

        bool isDescending = false;
        private void ButtonSortFilms_Click(object sender, RoutedEventArgs e)
        {
            if (!isDescending)
            {
                ListBoxFilms.ItemsSource = classMain.ListFilms.OrderByDescending(x => x.Title).ToList();
                isDescending = true;
            }
            else
            {
                ListBoxFilms.ItemsSource = classMain.ListFilms.OrderBy(x => x.Title).ToList();
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
                    object data = ListBoxFilms.Items[selectedIndex];
                    Film film = data as Film;
                    Clipboard.SetText(film.Title);
                }
            }
        }
    }
}
