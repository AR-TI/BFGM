using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;

namespace BFGM.Pages.Films
{
    /// <summary>
    /// Логика взаимодействия для PageFilmsCartoons.xaml
    /// </summary>
    public partial class PageFilmsCartoons : Page
    {
        ClassReadingFile classReadingFile;

        public PageFilmsCartoons(ClassReadingFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxFilmsCartoons_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileFilmsCartoons();
                isFirstTime = true;
            }
            FillListFilmsCartoons();
        }

        bool isAscending = false;
        private void ButtonAscendingCartoons_Click(object sender, RoutedEventArgs e)
        {
            List<ModelFilmsCartoon> listFilmsCartoons = classReadingFile.ClassMainInfo.ListFilmsCartoons;
            if (!isAscending)
            {
                ListBoxFilmsCartoons.Items.Clear();
                var sorted = listFilmsCartoons.OrderBy(x => x.NameFilmsCartoon).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxFilmsCartoons.Items.Add(sorted[i].NameFilmsCartoon);
                }
                isAscending = true;
            }
            else
            {
                ListBoxFilmsCartoons.Items.Clear();
                var sorted = listFilmsCartoons.OrderByDescending(x => x.NameFilmsCartoon).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxFilmsCartoons.Items.Add(sorted[i].NameFilmsCartoon);
                }
                isAscending = false;
            }
        }

        public void FillListFilmsCartoons()
        {
            ListBoxFilmsCartoons.Items.Clear();
            List<ModelFilmsCartoon> listFilmsCartoons = classReadingFile.ClassMainInfo.ListFilmsCartoons.OrderByDescending(x => x.NameFilmsCartoon.Length).ToList();
            for (int i = 0; i < listFilmsCartoons.Count; i++)
            {
                ListBoxFilmsCartoons.Items.Add(listFilmsCartoons[i].NameFilmsCartoon);
            }
        }

        private void ListBoxFilmsCartoons_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxFilmsCartoons.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxFilmsCartoons.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
