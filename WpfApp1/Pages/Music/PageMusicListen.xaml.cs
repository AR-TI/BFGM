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
    /// Логика взаимодействия для PageMusicListen.xaml
    /// </summary>
    public partial class PageMusicListen : Page
    {
        readonly ClassMain classMain;
        readonly ClassReadFile classReadFile;

        public PageMusicListen(ClassMain classMain, ClassReadFile classReadFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
        }

        static private bool isFirstTime = false;
        private async void ListBoxListen_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                await classReadFile.ReadFileListen();
                isFirstTime = true;
            }
            FillListListen();
        }

        bool isDescending = false;
        private void ButtonSortListen_Click(object sender, RoutedEventArgs e)
        {
            List<Listen> listListen = classMain.ListListen;
            if (!isDescending)
            {
                ListBoxListen.Items.Clear();
                List<Listen> sorted = listListen.OrderByDescending(r => r.Band).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxListen.Items.Add(sorted[i].Band);
                }
                isDescending = true;
            }
            else
            {
                ListBoxListen.Items.Clear();
                List<Listen> sorted = listListen.OrderBy(r => r.Band).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxListen.Items.Add(sorted[i].Band);
                }
                isDescending = false;
            }
        }

        public void FillListListen()
        {
            ListBoxListen.Items.Clear();
            List<Listen> listMusicListen = classMain.ListListen.OrderBy(x => x.Band).ToList();
            for (int i = 0; i < listMusicListen.Count; i++)
            {
                ListBoxListen.Items.Add(listMusicListen[i].Band);
            }
        }

        private void ListBoxListen_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxListen.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxListen.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
