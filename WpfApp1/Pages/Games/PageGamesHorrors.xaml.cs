using BFGM.Classes;
using BFGM.Constants;
using BFGM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BFGM.Pages.Games
{
    /// <summary>
    /// Логика взаимодействия для PageGamesHorrors.xaml
    /// </summary>
    public partial class PageGamesHorrors : Page
    {
        readonly ClassMain classMain;

        public PageGamesHorrors(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        public void FillListHorrors()
        {
            ListBoxHorrors.ItemsSource = classMain.ListHorrors.OrderBy(x => x.Title).ToList();
        }

        private bool isFirstTime = false;
        private async void ListBoxHorrors_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListHorrors = await classMain.Read<Horror>(PathFiles.HorrorsPath);
                isFirstTime = true;
            }

            FillListHorrors();
        }

        bool isDescending = false;
        private void ButtonSortHorrors_Click(object sender, RoutedEventArgs e)
        {
            if (!isDescending)
            {
                ListBoxHorrors.ItemsSource = classMain.ListHorrors.OrderByDescending(x => x.Title).ToList();
                isDescending = true;
            }
            else
            {
                ListBoxHorrors.ItemsSource = classMain.ListHorrors.OrderBy(x => x.Title).ToList();
                isDescending = false;
            }
        }

        private void ListBoxHorrors_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxHorrors.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = ListBoxHorrors.Items[selectedIndex];
                    Horror horror = data as Horror;
                    Clipboard.SetText(horror.Title);
                }
            }
        }
    }
}
