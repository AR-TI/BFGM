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
    /// Логика взаимодействия для PageFilmsSerials.xaml
    /// </summary>
    public partial class PageFilmsSerials : Page
    {
        readonly ClassMain classMain;

        public PageFilmsSerials(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        public void FillListSerials()
        {
            ListBoxSerials.ItemsSource = classMain.ListSerials.OrderBy(x => x.Title).ToList();
        }

        private bool isFirstTime = false;
        private async void ListBoxSerials_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListSerials = await classMain.Read<Serial>(PathFiles.SerialsPath);
                isFirstTime = true;
            }

            FillListSerials();
        }

        bool isDescending = false;
        private void ButtonSortSeroals_Click(object sender, RoutedEventArgs e)
        {
            if (!isDescending)
            {
                ListBoxSerials.ItemsSource = classMain.ListSerials.OrderByDescending(x => x.Title).ToList();
                isDescending = true;
            }
            else
            {
                ListBoxSerials.ItemsSource = classMain.ListSerials.OrderBy(x => x.Title).ToList();
                isDescending = false;
            }
        }

        private void ListBoxSerials_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxSerials.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = ListBoxSerials.Items[selectedIndex];
                    Serial serial = data as Serial;
                    Clipboard.SetText(serial.Title);
                }
            }
        }
    }
}
