using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Models;
using WpfApp1.Windows.Music;

namespace BFGM.Pages.Music
{
    /// <summary>
    /// Логика взаимодействия для PageMusicReleases.xaml
    /// </summary>
    public partial class PageMusicReleases : Page
    {
        ClassWriteFile classWritingFile; //mew
        ClassReadFile classReadingFile;
        List<Release> listReleases;
        byte SinglesAlbumsShow = 0;

        public PageMusicReleases(ClassReadFile classReadingFile, ClassWriteFile classWritingFile/*new*/)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;  //new
            this.classReadingFile = classReadingFile;
        }

        static private bool isFirstTime = false;
        private async void GridMusicReleases_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                await classReadingFile.ReadFileReleases();
                isFirstTime = true;
            }
            FillListBoxMusicReleases();
        }

        public void FillListBoxMusicReleases()
        {
            listReleases = classReadingFile.ClassMainInfo.ListReleases.OrderBy(x => x.Date).ToList();
            ListBoxReleases.ItemsSource = listReleases;
        }

        public void SortBySinglesAlbums()
        {
            List<Release> listSinglesOrAlbums = new List<Release>();
            if (SinglesAlbumsShow == 0)
            {
                for (int i = 0; i < listReleases.Count; i++)
                {
                    if (listReleases[i].Album.Contains("[Single]"))
                    {
                        listSinglesOrAlbums.Add(listReleases[i]);
                    }
                }
                ListBoxReleases.ItemsSource = listSinglesOrAlbums;
                SinglesAlbumsShow = 1;
                ButtonSinglesAlbums.Content = "Albums";
            }
            else if (SinglesAlbumsShow == 1)
            {
                for (int i = 0; i < listReleases.Count; i++)
                {
                    if (!listReleases[i].Album.Contains("[Single]"))
                    {
                        listSinglesOrAlbums.Add(listReleases[i]);
                    }
                }
                ListBoxReleases.ItemsSource = listSinglesOrAlbums;
                SinglesAlbumsShow = 2;
                ButtonSinglesAlbums.Content = "All";
            }
            else
            {
                FillListBoxMusicReleases();
                SinglesAlbumsShow = 0;
                ButtonSinglesAlbums.Content = "Singels";
            }
        }
        public void CurrentSort()
        {
            FillListBoxMusicReleases();
            SinglesAlbumsShow--;
            SortBySinglesAlbums();
        }
        private void ButtonSinglesAlbums_Click(object sender, RoutedEventArgs e)
        {
            SortBySinglesAlbums();
        }

        private void MenuItem_ClickEdit(object sender, RoutedEventArgs e)
        {
            int selectedIndex = ListBoxReleases.SelectedIndex;
            if (selectedIndex != -1)
            {
                Release releaseOld = ListBoxReleases.Items[selectedIndex] as Release;
                WindowsMusicReleasesEdit windowsMusicReleasesEdit = new WindowsMusicReleasesEdit(classWritingFile, this, releaseOld);
                windowsMusicReleasesEdit.ShowDialog();
            }
        }

        private void ListBoxMusicReleases_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxReleases.SelectedIndex;

                if (selectedIndex != -1)
                {
                    object data = ListBoxReleases.Items[selectedIndex];
                    Release release = data as Release;
                    string fullName = $"{release.Band} - {release.Album}";
                    if (fullName.Contains(" [Single]"))
                        fullName = fullName.Replace(" [Single]", "");
                    else if (fullName.Contains(" [EP]"))
                        fullName = fullName.Replace(" [EP]", "");
                    Clipboard.SetText(fullName);
                }
            }
        }
    }
}
