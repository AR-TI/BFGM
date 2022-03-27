using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;

namespace BFGM.Pages.Films
{
    /// <summary>
    /// Логика взаимодействия для PageFilmsSerials.xaml
    /// </summary>
    public partial class PageFilmsSerials : Page
    {
        ClassReadFile classReadingFile;

        public PageFilmsSerials(ClassReadFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxSerials_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadFileSerials();
                isFirstTime = true;
            }
            FillListSerials();
        }

        public void FillListSerials()
        {
            ListBoxSerials.Items.Clear();
            List<Serial> listSerials = classReadingFile.ClassMainInfo.ListSerials.OrderBy(x => x.Title).ToList();
            for (int i = 0; i < listSerials.Count; i++)
            {
                ListBoxSerials.Items.Add(listSerials[i].Title);
            }
        }

        bool isDescending = false;
        private void ButtonSortSeroals_Click(object sender, RoutedEventArgs e)
        {
            List<Serial> listSerials = classReadingFile.ClassMainInfo.ListSerials;
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
