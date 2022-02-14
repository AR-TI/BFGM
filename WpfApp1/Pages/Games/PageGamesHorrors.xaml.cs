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
        ClassReadingFile classReadingFile;

        public PageGamesHorrors(ClassReadingFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxGamesHorrors_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileGamesHorrors();
                isFirstTime = true;
            }
            FillListGamesHorrors();
        }

        bool isAscending = false;
        private void ButtonAscendingHorrors_Click(object sender, RoutedEventArgs e)
        {
            List<ModelGamesHorror> listGamesHorrors = classReadingFile.ClassMainInfo.ListGamesHorrors;
            if (!isAscending)
            {
                ListBoxGamesHorrors.Items.Clear();
                var sorted = listGamesHorrors.OrderBy(r => r.NameGamesHorror).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxGamesHorrors.Items.Add(sorted[i].NameGamesHorror);
                }
                isAscending = true;
            }
            else
            {
                ListBoxGamesHorrors.Items.Clear();
                var sorted = listGamesHorrors.OrderByDescending(r => r.NameGamesHorror).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxGamesHorrors.Items.Add(sorted[i].NameGamesHorror);
                }
                isAscending = false;
            }
        }

        public void FillListGamesHorrors()
        {
            ListBoxGamesHorrors.Items.Clear();
            List<ModelGamesHorror> listGamesHorrors = classReadingFile.ClassMainInfo.ListGamesHorrors.OrderByDescending(x => x.NameGamesHorror.Length).ToList();
            for (int i = 0; i < listGamesHorrors.Count; i++)
            {
                ListBoxGamesHorrors.Items.Add(listGamesHorrors[i].NameGamesHorror);
            }
        }

        private void ListBoxGamesHorrors_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxGamesHorrors.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxGamesHorrors.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
