using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;

namespace BFGM.Pages.Games
{
    /// <summary>
    /// Логика взаимодействия для PageGamesPlayStation.xaml
    /// </summary>
    public partial class PageGamesPlayStation : Page
    {
        ClassReadingFile classReadingFile;

        public PageGamesPlayStation(ClassReadingFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxGamesPlayStation_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileGamesPlayStation();
                isFirstTime = true;
            }
            FillListGamesPlayStation();
        }

        bool isAscending = false;
        private void ButtonAscendingPlayStation_Click(object sender, RoutedEventArgs e)
        {
            List<ModelGamesPlayStation> listGamesPlayStation = classReadingFile.ClassMainInfo.ListGamesPlayStation;
            if (!isAscending)
            {
                ListBoxGamesPlayStation.Items.Clear();
                var sorted = listGamesPlayStation.OrderBy(r => r.NameGamesPlayStation).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxGamesPlayStation.Items.Add(sorted[i].NameGamesPlayStation);
                }
                isAscending = true;
            }
            else
            {
                ListBoxGamesPlayStation.Items.Clear();
                var sorted = listGamesPlayStation.OrderByDescending(r => r.NameGamesPlayStation).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxGamesPlayStation.Items.Add(sorted[i].NameGamesPlayStation);
                }
                isAscending = false;
            }
        }

        public void FillListGamesPlayStation()
        {
            ListBoxGamesPlayStation.Items.Clear();
            List<ModelGamesPlayStation> listGamesPlayStation = classReadingFile.ClassMainInfo.ListGamesPlayStation.OrderByDescending(x => x.NameGamesPlayStation.Length).ToList();
            for (int i = 0; i < listGamesPlayStation.Count; i++)
            {
                ListBoxGamesPlayStation.Items.Add(listGamesPlayStation[i].NameGamesPlayStation);
            }
        }

        private void ListBoxGamesPlayStation_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxGamesPlayStation.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxGamesPlayStation.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
