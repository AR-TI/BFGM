using BFGM.Classes;
using BFGM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BFGM.Pages.Music
{
    /// <summary>
    /// Логика взаимодействия для PageMusicWaiting.xaml
    /// </summary>
    public partial class PageMusicWait : Page
    {
        readonly ClassMain classMain;
        readonly ClassReadFile classReadFile;

        public PageMusicWait(ClassMain classMain, ClassReadFile classReadFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
        }

        static private bool isFirstTime = false;
        private async void ListBoxWait_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                await classReadFile.ReadFileWait();
                isFirstTime = true;
            }
            FillListWait();
        }

        bool isDescending = false;
        private void ButtonSortWaiting_Click(object sender, RoutedEventArgs e)
        {
            List<Wait> listMusicWaiting = classMain.ListWait;
            if (!isDescending)
            {
                ListBoxWait.Items.Clear();
                List<Wait> sorted = listMusicWaiting.OrderByDescending(r => r.Band).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxWait.Items.Add(sorted[i].Band);
                }
                isDescending = true;
            }
            else
            {
                ListBoxWait.Items.Clear();
                List<Wait> sorted = listMusicWaiting.OrderBy(r => r.Band).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxWait.Items.Add(sorted[i].Band);
                }
                isDescending = false;
            }
        }

        public void FillListWait()
        {
            ListBoxWait.Items.Clear();
            List<Wait> listWait = classMain.ListWait.OrderBy(x => x.Band).ToList();
            for (int i = 0; i < listWait.Count; i++)
            {
                ListBoxWait.Items.Add(listWait[i].Band);
            }
        }

        private void ListBoxMusicWaiting_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxWait.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxWait.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
