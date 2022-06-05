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
    /// Логика взаимодействия для PageGamesPlayStation.xaml
    /// </summary>
    public partial class PageGamesPlayStation : Page
    {
        readonly ClassMain classMain;
        readonly ClassReadFile classReadFile;

        public PageGamesPlayStation(ClassMain classMain, ClassReadFile classReadFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
        }

        static private bool isFirstTime = false;
        private async void ListBoxPlayStation_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                await classReadFile.ReadFilePlayStation();
                isFirstTime = true;
            }
            FillListPlayStation();
        }

        bool isDescending = false;
        private void ButtonSortPlayStation_Click(object sender, RoutedEventArgs e)
        {
            List<PlayStation> listPlayStation = classMain.ListPlayStation;
            if (!isDescending)
            {
                ListBoxPlayStation.Items.Clear();
                List<PlayStation> sorted = listPlayStation.OrderByDescending(r => r.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxPlayStation.Items.Add(sorted[i].Title);
                }
                isDescending = true;
            }
            else
            {
                ListBoxPlayStation.Items.Clear();
                List<PlayStation> sorted = listPlayStation.OrderBy(r => r.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxPlayStation.Items.Add(sorted[i].Title);
                }
                isDescending = false;
            }
        }

        public void FillListPlayStation()
        {
            ListBoxPlayStation.Items.Clear();
            List<PlayStation> listlPayStation = classMain.ListPlayStation.OrderBy(x => x.Title).ToList();
            for (int i = 0; i < listlPayStation.Count; i++)
            {
                ListBoxPlayStation.Items.Add(listlPayStation[i].Title);
            }
        }

        private void ListBoxPlayStation_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxPlayStation.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxPlayStation.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
