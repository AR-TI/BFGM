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
    /// Логика взаимодействия для PageGamesPlayStation.xaml
    /// </summary>
    public partial class PageGamesPlayStation : Page
    {
        readonly ClassMain classMain;

        public PageGamesPlayStation(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        public void FillListPlayStation()
        {
            ListBoxPlayStation.ItemsSource = classMain.ListPlayStation.OrderBy(x => x.Title).ToList();
        }

        private bool isFirstTime = false;
        private async void ListBoxPlayStation_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListPlayStation = await classMain.Read<PlayStation>(PathFiles.PlayStationPath);
                isFirstTime = true;
            }

            FillListPlayStation();
        }

        bool isDescending = false;
        private void ButtonSortPlayStation_Click(object sender, RoutedEventArgs e)
        {
            if (!isDescending)
            {
                ListBoxPlayStation.ItemsSource = classMain.ListPlayStation.OrderByDescending(x => x.Title).ToList();
                isDescending = true;
            }
            else
            {
                ListBoxPlayStation.ItemsSource = classMain.ListPlayStation.OrderBy(x => x.Title).ToList();
                isDescending = false;
            }
        }

        private void ListBoxPlayStation_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxPlayStation.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = ListBoxPlayStation.Items[selectedIndex];
                    PlayStation playStation = data as PlayStation;
                    Clipboard.SetText(playStation.Title);
                }
            }
        }
    }
}
