using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;

namespace BFGM.Pages.Games
{
    /// <summary>
    /// Логика взаимодействия для PageGamesPlatformers.xaml
    /// </summary>
    public partial class PageGamesPlatformers : Page
    {
        ClassReadingFile classReadingFile;

        public PageGamesPlatformers(ClassReadingFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxGamesPlatformers_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileGamesPlatformers();
                isFirstTime = true;
            }
            FillListGamesPlatformers();
        }

        bool isAscending = false;
        private void ButtonAscendingPlatformers_Click(object sender, RoutedEventArgs e)
        {
            List<ModelGamesPlatformer> listGamesPlatformers = classReadingFile.ClassMainInfo.ListGamesPlatformers;
            if (!isAscending)
            {
                ListBoxGamesPlatformers.Items.Clear();
                var sorted = listGamesPlatformers.OrderBy(r => r.NameGamesPlatformer).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxGamesPlatformers.Items.Add(sorted[i].NameGamesPlatformer);
                }
                isAscending = true;
            }
            else
            {
                ListBoxGamesPlatformers.Items.Clear();
                var sorted = listGamesPlatformers.OrderByDescending(r => r.NameGamesPlatformer).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxGamesPlatformers.Items.Add(sorted[i].NameGamesPlatformer);
                }
                isAscending = false;
            }
        }

        public void FillListGamesPlatformers()
        {
            ListBoxGamesPlatformers.Items.Clear();
            List<ModelGamesPlatformer> listGamesPlatformers = classReadingFile.ClassMainInfo.ListGamesPlatformers.OrderByDescending(x => x.NameGamesPlatformer.Length).ToList();
            for (int i = 0; i < listGamesPlatformers.Count; i++)
            {
                ListBoxGamesPlatformers.Items.Add(listGamesPlatformers[i].NameGamesPlatformer);
            }
        }

        private void ListBoxGamesPlatformers_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxGamesPlatformers.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxGamesPlatformers.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
