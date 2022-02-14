using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;

namespace BFGM.Pages.Music
{
    /// <summary>
    /// Логика взаимодействия для PageMusicWaiting.xaml
    /// </summary>
    public partial class PageMusicWaiting : Page
    {
        ClassReadingFile classReadingFile;

        public PageMusicWaiting(ClassReadingFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxMusicWaiting_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileMusicWaiting();
                isFirstTime = true;
            }
            FillListMusicWaiting();
        }

        bool isAscending = false;
        private void ButtonAscendingWaiting_Click(object sender, RoutedEventArgs e)
        {
            List<ModelMusicWaiting> listMusicWaiting = classReadingFile.ClassMainInfo.ListMusicWaiting;
            if (!isAscending)
            {
                ListBoxMusicWaiting.Items.Clear();
                var sorted = listMusicWaiting.OrderBy(r => r.NameMusicWaiting).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxMusicWaiting.Items.Add(sorted[i].NameMusicWaiting);
                }
                isAscending = true;
            }
            else
            {
                ListBoxMusicWaiting.Items.Clear();
                var sorted = listMusicWaiting.OrderByDescending(r => r.NameMusicWaiting).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxMusicWaiting.Items.Add(sorted[i].NameMusicWaiting);
                }
                isAscending = false;
            }
        }

        public void FillListMusicWaiting()
        {
            ListBoxMusicWaiting.Items.Clear();
            List<ModelMusicWaiting> listMusicWaiting = classReadingFile.ClassMainInfo.ListMusicWaiting.OrderByDescending(x => x.NameMusicWaiting.Length).ToList();
            for (int i = 0; i < listMusicWaiting.Count; i++)
            {
                ListBoxMusicWaiting.Items.Add(listMusicWaiting[i].NameMusicWaiting);
            }
        }

        private void ListBoxMusicWaiting_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxMusicWaiting.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxMusicWaiting.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
