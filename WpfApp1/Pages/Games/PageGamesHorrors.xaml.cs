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
    /// Логика взаимодействия для PageGamesHorrors.xaml
    /// </summary>
    public partial class PageGamesHorrors : Page
    {
        readonly ClassMain classMain;
        readonly ClassReadFile classReadFile;

        public PageGamesHorrors(ClassMain classMain, ClassReadFile classReadFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
        }

        static private bool isFirstTime = false;
        private async void ListBoxHorrors_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                await classReadFile.ReadFileHorrors();
                isFirstTime = true;
            }
            FillListHorrors();
        }

        bool isDescending = false;
        private void ButtonSortHorrors_Click(object sender, RoutedEventArgs e)
        {
            List<Horror> listHorrors = classMain.ListHorrors;
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
            List<Horror> listHorrors = classMain.ListHorrors.OrderBy(x => x.Title).ToList();
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
