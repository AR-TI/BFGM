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
    /// Логика взаимодействия для PageMusicListen.xaml
    /// </summary>
    public partial class PageMusicListen : Page
    {
        readonly ClassMain classMain;

        public PageMusicListen(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        public void FillListListen()
        {
            ListBoxListen.ItemsSource = classMain.ListListen.OrderBy(x => x.Band).ToList();
        }

        private bool isFirstTime = false;
        private async void ListBoxListen_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListListen = await classMain.Read<Listen>(PathFiles.ListenPath);
                isFirstTime = true;
            }

            FillListListen();
        }

        bool isDescending = false;
        private void ButtonSortListen_Click(object sender, RoutedEventArgs e)
        {
            if (!isDescending)
            {
                ListBoxListen.ItemsSource = classMain.ListListen.OrderByDescending(x => x.Band).ToList();
                isDescending = true;
            }
            else
            {
                ListBoxListen.ItemsSource = classMain.ListListen.OrderBy(x => x.Band).ToList();
                isDescending = false;
            }
        }

        private void ListBoxListen_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxListen.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = ListBoxListen.Items[selectedIndex];
                    Listen listen = data as Listen;
                    Clipboard.SetText(listen.Band);
                }
            }
        }
    }
}
