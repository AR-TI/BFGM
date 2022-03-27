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
        ClassReadFile classReadingFile;

        public PageFilmsCartoons(ClassReadFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxCartoons_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadFileCartoons();
                isFirstTime = true;
            }
            FillListCartoons();
        }

        public void FillListCartoons()
        {
            ListBoxCartoons.Items.Clear();
            List<Cartoon> listCartoons = classReadingFile.ClassMainInfo.ListCartoons.OrderBy(x => x.Title).ToList();
            for (int i = 0; i < listCartoons.Count; i++)
            {
                ListBoxCartoons.Items.Add(listCartoons[i].Title);
            }
        }

        bool isDescending = false;
        private void ButtonSortCartoons_Click(object sender, RoutedEventArgs e)
        {
            List<Cartoon> listCartoons = classReadingFile.ClassMainInfo.ListCartoons;
            if (!isDescending)
            {
                ListBoxCartoons.Items.Clear();
                List<Cartoon> sorted = listCartoons.OrderByDescending(x => x.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxCartoons.Items.Add(sorted[i].Title);
                }
                isDescending = true;
            }
            else
            {
                ListBoxCartoons.Items.Clear();
                List<Cartoon> sorted = listCartoons.OrderBy(x => x.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxCartoons.Items.Add(sorted[i].Title);
                }
                isDescending = false;
            }
        }

        private void ListBoxCartoons_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxCartoons.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxCartoons.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
