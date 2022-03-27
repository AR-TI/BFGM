using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;

namespace BFGM.Pages.Games
{
    /// <summary>
    /// Логика взаимодействия для PageGamesHorrors.xaml
    /// </summary>
    public partial class PageGamesHorrors : Page
    {
        ClassReadFile classReadingFile;

        public PageGamesHorrors(ClassReadFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxHorrors_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadFileHorrors();
                isFirstTime = true;
            }
            FillListHorrors();
        }

        bool isDescending = false;
        private void ButtonSortHorrors_Click(object sender, RoutedEventArgs e)
        {
            List<Horror> listHorrors = classReadingFile.ClassMainInfo.ListHorrors;
            if (!isDescending)
            {
                ListBoxHorrors.Items.Clear();
                var sorted = listHorrors.OrderByDescending(r => r.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxHorrors.Items.Add(sorted[i].Title);
                }
                isDescending = true;
            }
            else
            {
                ListBoxHorrors.Items.Clear();
                var sorted = listHorrors.OrderBy(r => r.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxHorrors.Items.Add(sorted[i].Title);
                }
                isDescending = false;
            }
        }

        public void FillListHorrors()
        {
            ListBoxHorrors.Items.Clear();
            List<Horror> listHorrors = classReadingFile.ClassMainInfo.ListHorrors.OrderBy(x => x.Title).ToList();
            for (int i = 0; i < listHorrors.Count; i++)
            {
                ListBoxHorrors.Items.Add(listHorrors[i].Title);
            }
        }

        private void ListBoxHorrors_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxHorrors.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxHorrors.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
