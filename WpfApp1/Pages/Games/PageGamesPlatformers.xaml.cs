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
    /// Логика взаимодействия для PageGamesPlatformers.xaml
    /// </summary>
    public partial class PageGamesPlatformers : Page
    {
        readonly ClassMain classMain;

        public PageGamesPlatformers(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        public void FillListPlatformers()
        {
            ListBoxPlatformers.ItemsSource = classMain.ListPlatformers.OrderBy(x => x.Title).ToList();
        }

        private bool isFirstTime = false;
        private async void ListBoxPlatformers_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListPlatformers = await classMain.Read<Platformer>(PathFiles.PlatformersPath);
                isFirstTime = true;
            }

            FillListPlatformers();
        }

        bool isDescending = false;
        private void ButtonSortPlatformers_Click(object sender, RoutedEventArgs e)
        {
            if (!isDescending)
            {
                ListBoxPlatformers.ItemsSource = classMain.ListPlatformers.OrderByDescending(x => x.Title).ToList();
                isDescending = true;
            }
            else
            {
                ListBoxPlatformers.ItemsSource = classMain.ListPlatformers.OrderBy(x => x.Title).ToList();
                isDescending = false;
            }
        }

        private void ListBoxPlatformers_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxPlatformers.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = ListBoxPlatformers.Items[selectedIndex];
                    Platformer platformer = data as Platformer;
                    Clipboard.SetText(platformer.Title);
                }
            }
        }
    }
}
