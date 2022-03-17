using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;
using BFGM.Windows.Music;

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
            /*Добавление*/
            WindowsMusicReleasesAdd windowsMusicReleasesAdd = new WindowsMusicReleasesAdd(classWritingFile, this);
            int selectedIndex = ListBoxMusicReleasesAlbum.SelectedIndex;
            string selectedName = ListBoxMusicReleasesAlbum.Items[selectedIndex].ToString();
            windowsMusicReleasesAdd.TextBoxMusicReleasesGroup.Text = ListBoxMusicReleasesGroup.Items[selectedIndex].ToString();
            windowsMusicReleasesAdd.TextBoxMusicReleasesAlbum.Text = ListBoxMusicReleasesAlbum.Items[selectedIndex].ToString();
            windowsMusicReleasesAdd.TextBoxMusicReleasesDate.Text = ListBoxMusicReleasesDate.Items[selectedIndex].ToString();
            windowsMusicReleasesAdd.ShowDialog();
            /*Удаление*/
            if (selectedIndex != -1)
            {
                //classReadingFile.ClassMainInfo.DeleteMusicReleases(selectedName);
                classWritingFile.RewritingFileAfterDeleteMusicReleases();
                ListBoxMusicReleasesGroup.Items.RemoveAt(selectedIndex);
                ListBoxMusicReleasesAlbum.Items.RemoveAt(selectedIndex);
                ListBoxMusicReleasesDate.Items.RemoveAt(selectedIndex);
            }
        }
    }
}
