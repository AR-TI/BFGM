using BFGM.Classes;
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
        readonly ClassReadFile classReadFile;

        public PageGamesPlatformers(ClassMain classMain, ClassReadFile classReadFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
        }

        static private bool isFirstTime = false;
        private async void ListBoxPlatformers_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                await classReadFile.ReadFilePlatformers();
                isFirstTime = true;
            }
            FillListPlatformers();
        }

        bool isDescending = false;
        private void ButtonSortPlatformers_Click(object sender, RoutedEventArgs e)
        {
            List<Platformer> listPlatformers = classMain.ListPlatformers;
            if (!isDescending)
            {
                ListBoxPlatformers.Items.Clear();
                var sorted = listPlatformers.OrderByDescending(r => r.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxPlatformers.Items.Add(sorted[i].Title);
                }
                isDescending = true;
            }
            else
            {
                ListBoxPlatformers.Items.Clear();
                var sorted = listPlatformers.OrderBy(r => r.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxPlatformers.Items.Add(sorted[i].Title);
                }
                isDescending = false;
            }
        }

        public void FillListPlatformers()
        {
            ListBoxPlatformers.Items.Clear();
            List<Platformer> listPlatformers = classMain.ListPlatformers.OrderBy(x => x.Title).ToList();
            for (int i = 0; i < listPlatformers.Count; i++)
            {
                ListBoxPlatformers.Items.Add(listPlatformers[i].Title);
            }
        }

        private void ListBoxPlatformers_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxPlatformers.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxPlatformers.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
