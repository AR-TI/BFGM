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
        ClassReadingFile classReadingFile;

        public PageFilmsSerials(ClassReadingFile classReadingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private void ListBoxFilmsSerials_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileFilmsSerials();
                isFirstTime = true;
            }
            FillListFilmsSerials();
        }

        bool isAscending = false;
        private void ButtonAscendingSeroals_Click(object sender, RoutedEventArgs e)
        {
            List<ModelFilmsSerial> listFilmsSerials = classReadingFile.ClassMainInfo.ListFilmsSerials;
            if (!isAscending)
            {
                ListBoxFilmsSerials.Items.Clear();
                var sorted = listFilmsSerials.OrderBy(r => r.NameFilmsSerial).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxFilmsSerials.Items.Add(sorted[i].NameFilmsSerial);
                }
                isAscending = true;
            }
            else
            {
                ListBoxFilmsSerials.Items.Clear();
                var sorted = listFilmsSerials.OrderByDescending(r => r.NameFilmsSerial).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    ListBoxFilmsSerials.Items.Add(sorted[i].NameFilmsSerial);
                }
                isAscending = false;
            }
        }

        public void FillListFilmsSerials()
        {
            ListBoxFilmsSerials.Items.Clear();
            List<ModelFilmsSerial> listFilmsSerials = classReadingFile.ClassMainInfo.ListFilmsSerials.OrderByDescending(x => x.NameFilmsSerial.Length).ToList();
            for (int i = 0; i < listFilmsSerials.Count; i++)
            {
                ListBoxFilmsSerials.Items.Add(listFilmsSerials[i].NameFilmsSerial);
            }
        }

        private void ListBoxFilmsSerials_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxFilmsSerials.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxFilmsSerials.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
