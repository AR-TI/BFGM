using BFGM.Classes;
using BFGM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BFGM.Pages.Films
{
    /// <summary>
    /// Логика взаимодействия для PageFilmsCartoons.xaml
    /// </summary>
    public partial class PageFilmsCartoons : Page
    {
        readonly ClassMain classMain;
        readonly ClassReadFile classReadFile;

        public PageFilmsCartoons(ClassMain classMain, ClassReadFile classReadFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
        }

        static private bool isFirstTime = false;
        private async void ListBoxCartoons_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                await classReadFile.ReadFileCartoons();
                isFirstTime = true;
            }
            FillListCartoons();
        }

        public void FillListCartoons()
        {
            ListBoxCartoons.Items.Clear();
            List<Cartoon> listCartoons = classMain.ListCartoons.OrderBy(x => x.Title).ToList();
            for (int i = 0; i < listCartoons.Count; i++)
            {
                ListBoxCartoons.Items.Add(listCartoons[i].Title);
            }
        }

        bool isDescending = false;
        private void ButtonSortCartoons_Click(object sender, RoutedEventArgs e)
        {
            List<Cartoon> listCartoons = classMain.ListCartoons;
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
