using BFGM.Classes;
using BFGM.Constants;
using BFGM.Models;
using BFGM.Windows.Music;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BFGM.Pages.Music
{
    /// <summary>
    /// Логика взаимодействия для PageMusicReleases.xaml
    /// </summary>
    public partial class PageMusicReleases : Page
    {
        readonly ClassMain classMain;

        public PageMusicReleases(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        private bool isFirstTime = false;
        private async void GridMusicReleases_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListReleases = await classMain.Read<Release>(PathFiles.ReleasesPath);
                isFirstTime = true;
            }

            FillListBoxMusicReleases();
        }

        public void FillListBoxMusicReleases()
        {
            ListBoxReleases.ItemsSource = classMain.ListReleases.OrderBy(x => x.Date).ThenBy(x => x.Band).ToList();
        }

        byte SinglesAlbumsShow = 0;
        public void SortBySinglesAlbums()
        {
            if (SinglesAlbumsShow == 0)
            {
                ListBoxReleases.ItemsSource = classMain.ListReleases.Where(x => x.Album.Contains("[Single]")).OrderBy(x => x.Date).ThenBy(x => x.Band).ToList();
                SinglesAlbumsShow = 1;
                ButtonSinglesAlbums.Content = "Albums";
            }
            else if (SinglesAlbumsShow == 1)
            {
                ListBoxReleases.ItemsSource = classMain.ListReleases.Where(x => !x.Album.Contains("[Single]")).OrderBy(x => x.Date).ThenBy(x => x.Band).ToList();
                SinglesAlbumsShow = 2;
                ButtonSinglesAlbums.Content = "All";
            }
            else
            {
                FillListBoxMusicReleases();
                SinglesAlbumsShow = 0;
                ButtonSinglesAlbums.Content = "Singles";
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
                WindowsMusicReleasesEdit windowsMusicReleasesEdit = new WindowsMusicReleasesEdit(classMain, this, releaseOld);
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
                    string fullName = $"{release.Band} {release.Album}";
                    if (fullName.Contains(" [Single]"))
                    {
                        fullName = fullName.Replace(" [Single]", "");
                    }
                    else if (fullName.Contains(" [EP]"))
                    {
                        fullName = fullName.Replace(" [EP]", "");
                    }

                    Clipboard.SetText(fullName);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ListBoxReleases.ItemsSource = classMain.ListReleases.OrderBy(x => x.Band).ThenBy(x => x.Date).ToList();
        }
    }
}
