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
    /// Логика взаимодействия для PageFilmsSerials.xaml
    /// </summary>
    public partial class PageFilmsSerials : Page
    {
        readonly ClassMain classMain;
        readonly ClassReadFile classReadFile;

        public PageFilmsSerials(ClassMain classMain, ClassReadFile classReadFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
        }

        static private bool isFirstTime = false;
        private async void ListBoxSerials_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                await classReadFile.ReadFileSerials();
                isFirstTime = true;
            }
            FillListSerials();
        }

        public void FillListSerials()
        {
            ListBoxSerials.Items.Clear();
            List<Serial> listSerials = classMain.ListSerials.OrderBy(x => x.Title).ToList();
            for (int i = 0; i < listSerials.Count; i++)
            {
                ListBoxSerials.Items.Add(listSerials[i].Title);
            }
        }

        bool isDescending = false;
        private void ButtonSortSeroals_Click(object sender, RoutedEventArgs e)
        {
            List<Serial> listSerials = classMain.ListSerials;
            if (!isDescending)
            {
                ListBoxSerials.Items.Clear();
                var sorted = listSerials.OrderByDescending(r => r.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxSerials.Items.Add(sorted[i].Title);
                }
                isDescending = true;
            }
            else
            {
                ListBoxSerials.Items.Clear();
                var sorted = listSerials.OrderBy(r => r.Title).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxSerials.Items.Add(sorted[i].Title);
                }
                isDescending = false;
            }
        }

        private void ListBoxSerials_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxSerials.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxSerials.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
