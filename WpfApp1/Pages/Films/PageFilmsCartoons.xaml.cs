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
    /// Логика взаимодействия для PageFilmsCartoons.xaml
    /// </summary>
    public partial class PageFilmsCartoons : Page
    {
        readonly ClassMain classMain;

        public PageFilmsCartoons(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        public void FillListCartoons()
        {
            ListBoxCartoons.ItemsSource = classMain.ListCartoons.OrderBy(x => x.Title).ToList();
        }

        private bool isFirstTime = false;
        private async void ListBoxCartoons_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListCartoons = await classMain.Read<Cartoon>(PathFiles.CartoonsPath);
                isFirstTime = true;
            }

            FillListCartoons();
        }

        bool isDescending = false;
        private void ButtonSortCartoons_Click(object sender, RoutedEventArgs e)
        {
            if (!isDescending)
            {
                ListBoxCartoons.ItemsSource = classMain.ListCartoons.OrderByDescending(x => x.Title).ToList();
                isDescending = true;
            }
            else
            {
                ListBoxCartoons.ItemsSource = classMain.ListCartoons.OrderBy(x => x.Title).ToList();
                isDescending = false;
            }
        }

        private void ListBoxCartoons_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxCartoons.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = ListBoxCartoons.Items[selectedIndex];
                    Cartoon cartoon = data as Cartoon;
                    Clipboard.SetText(cartoon.Title);
                }
            }
        }
    }
}
