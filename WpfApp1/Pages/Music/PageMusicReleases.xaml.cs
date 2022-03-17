using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;
using BFGM.Windows.Music;
using WpfApp1.Windows.Music;

namespace BFGM.Pages.Music
{
    /// <summary>
    /// Логика взаимодействия для PageMusicReleases.xaml
    /// </summary>
    public partial class PageMusicReleases : Page
    {
        ClassWritingFile classWritingFile; //mew
        ClassReadingFile classReadingFile;

        public PageMusicReleases(ClassReadingFile classReadingFile, ClassWritingFile classWritingFile/*new*/)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;  //new
            this.classReadingFile = classReadingFile;
            ListBoxMusicReleasesGroup.SelectedItem = ListBoxMusicReleasesAlbum.SelectedItem;
        }

        static private bool isFirstTime = false;
        private void GridMusicReleases_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileMusicReleases();
                isFirstTime = true;
            }
            FillListBoxMusicReleases();
        }

        public void FillListBoxMusicReleases()
        {
            ListBoxClear();
            List<ModelMusicReleases> listMusicReleasesSorted = classReadingFile.ClassMainInfo.ListMusicReleases.OrderBy(x => x.NameMusicReleasesDate).ToList();

            for (int i = 0; i < listMusicReleasesSorted.Count; i++)
            {
                ListBoxAdd(listMusicReleasesSorted, i);
            }
        }

        byte SinglesAlbumsShow = 0;
        private void ButtonSingles_Click(object sender, RoutedEventArgs e)
        {
            List<ModelMusicReleases> listMusicReleasesSorted = classReadingFile.ClassMainInfo.ListMusicReleases.OrderBy(x => x.NameMusicReleasesDate).ToList();
            if (SinglesAlbumsShow == 0)
            {
                ListBoxClear();
                for (int i = 0; i < listMusicReleasesSorted.Count; i++)
                {
                    if (listMusicReleasesSorted[i].NameMusicReleasesAlbum.Contains("[Single]"))
                    {
                        ListBoxAdd(listMusicReleasesSorted, i);
                    }
                }
                SinglesAlbumsShow = 1;
                ButtonSingles.Content = "Albums";
            }
            else if (SinglesAlbumsShow == 1)
            {
                ListBoxClear();
                for (int i = 0; i < listMusicReleasesSorted.Count; i++)
                {
                    if (!listMusicReleasesSorted[i].NameMusicReleasesAlbum.Contains("[Single]"))
                    {
                        ListBoxAdd(listMusicReleasesSorted, i);
                    }
                }
                SinglesAlbumsShow = 2;
                ButtonSingles.Content = "All";
            }
            else if (SinglesAlbumsShow == 2)
            {
                FillListBoxMusicReleases();
                SinglesAlbumsShow = 0;
                ButtonSingles.Content = "Single";
            }
        }

        void ListBoxClear()
        {
            ListBoxMusicReleasesAlbum.Items.Clear();
            ListBoxMusicReleasesGroup.Items.Clear();
            ListBoxMusicReleasesDate.Items.Clear();
        }

        void ListBoxAdd(List<ModelMusicReleases> list, int i)
        {
            ListBoxMusicReleasesGroup.Items.Add(list[i].NameMusicReleasesGroup);
            ListBoxMusicReleasesAlbum.Items.Add(list[i].NameMusicReleasesAlbum);
            ListBoxMusicReleasesDate.Items.Add(list[i].NameMusicReleasesDate.ToString("d MMMM yyyy"));
        }

        private void ListBoxMusicReleasesGroup_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxMusicReleasesGroup.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxMusicReleasesGroup.Items[selectedIndex].ToString());
                }
            }
        }

        private void ListBoxMusicReleasesAlbum_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxMusicReleasesAlbum.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxMusicReleasesAlbum.Items[selectedIndex].ToString());
                }
            }
        }

        private void MenuItem_ClickEdit(object sender, RoutedEventArgs e)
        {
            int selectedIndexGroup = ListBoxMusicReleasesGroup.SelectedIndex;
            int selectedIndexAlbum = ListBoxMusicReleasesAlbum.SelectedIndex;
            int selectedIndexDate = ListBoxMusicReleasesDate.SelectedIndex;
            if (selectedIndexGroup != -1 || selectedIndexAlbum != -1 || selectedIndexDate != -1)
            {
                int index = PageMusic.CheckIndex(selectedIndexGroup, selectedIndexAlbum, selectedIndexDate);
                string oldGroup = ListBoxMusicReleasesGroup.Items[index].ToString();
                string oldAlbum = ListBoxMusicReleasesAlbum.Items[index].ToString();
                string oldDate = ListBoxMusicReleasesDate.Items[index].ToString();
                WindowsMusicReleasesEdit windowsMusicReleasesEdit = new WindowsMusicReleasesEdit(classWritingFile, this, oldGroup, oldAlbum, oldDate);
                windowsMusicReleasesEdit.TextBoxMusicReleasesGroup.Text = oldGroup;
                windowsMusicReleasesEdit.TextBoxMusicReleasesAlbum.Text = oldAlbum;
                windowsMusicReleasesEdit.TextBoxMusicReleasesDate.Text = oldDate;
                windowsMusicReleasesEdit.ShowDialog();
            }
        }
    }
}
