using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;

namespace BFGM.Pages.Music
{
    /// <summary>
    /// Логика взаимодействия для PageMusicListen.xaml
    /// </summary>
    public partial class PageMusicListen : Page
    {
        ClassReadingFile classReadingFile;

        public PageMusicListen(ClassReadingFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxMusicListen_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileMusicListen();
                isFirstTime = true;
            }
            FillListMusicListen();
        }

        bool isAscending = false;
        private void ButtonAscendingListen_Click(object sender, RoutedEventArgs e)
        {
            List<ModelMusicListen> listMusicListen = classReadingFile.ClassMainInfo.ListMusicListen;
            if (!isAscending)
            {
                ListBoxMusicListen.Items.Clear();
                var sorted = listMusicListen.OrderBy(r => r.NameMusicListen).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxMusicListen.Items.Add(sorted[i].NameMusicListen);
                }
                isAscending = true;
            }
            else
            {
                ListBoxMusicListen.Items.Clear();
                var sorted = listMusicListen.OrderByDescending(r => r.NameMusicListen).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxMusicListen.Items.Add(sorted[i].NameMusicListen);
                }
                isAscending = false;
            }
        }

        public void FillListMusicListen()
        {
            ListBoxMusicListen.Items.Clear();
            List<ModelMusicListen> listMusicListen = classReadingFile.ClassMainInfo.ListMusicListen.OrderByDescending(x => x.NameMusicListen.Length).ToList();
            for (int i = 0; i < listMusicListen.Count; i++)
            {
                ListBoxMusicListen.Items.Add(listMusicListen[i].NameMusicListen);
            }
        }

        private void ListBoxMusicListen_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxMusicListen.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxMusicListen.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
