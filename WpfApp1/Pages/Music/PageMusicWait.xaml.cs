using BFGM.Classes;
using BFGM.Constants;
using BFGM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BFGM.Pages.Music
{
    /// <summary>
    /// Логика взаимодействия для PageMusicWait.xaml
    /// </summary>
    public partial class PageMusicWait : Page
    {
        readonly ClassMain classMain;

        public PageMusicWait(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        public void FillListWait()
        {
            ListBoxWait.ItemsSource = classMain.ListWait.OrderBy(x => x.Band).ToList();
        }

        private bool isFirstTime = false;
        private async void ListBoxWait_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListWait = await classMain.Read<Wait>(PathFiles.WaitPath);
                isFirstTime = true;
            }

            FillListWait();
        }

        bool isDescending = false;
        private void ButtonSortWait_Click(object sender, RoutedEventArgs e)
        {
            if (!isDescending)
            {
                ListBoxWait.ItemsSource = classMain.ListWait.OrderByDescending(x => x.Band).ToList();
                isDescending = true;
            }
            else
            {
                ListBoxWait.ItemsSource = classMain.ListWait.OrderBy(x => x.Band).ToList();
                isDescending = false;
            }
        }

        private void ListBoxMusicWait_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxWait.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = ListBoxWait.Items[selectedIndex];
                    Wait wait = data as Wait;
                    Clipboard.SetText(wait.Band);
                }
            }
        }
    }
}
