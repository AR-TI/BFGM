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
        ClassWritingFile classWritingFile; //mew
        ClassReadingFile classReadingFile;
        List<ModelMusicReleases> listMusicReleases;

        public PageMusicReleases(ClassReadingFile classReadingFile, ClassWritingFile classWritingFile/*new*/)
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
                await classReadingFile.ReadingFileMusicReleases();
                isFirstTime = true;
            }
            FillListBoxMusicReleases();
        }

        public void FillListBoxMusicReleases()
        {
            listMusicReleases = classReadingFile.ClassMainInfo.ListMusicReleases.OrderBy(x => x.NameMusicReleasesDate).ToList();
            ListBoxMusicReleases.ItemsSource = listMusicReleases;
            ButtonSingles.Content = "Singles";
        }

        byte SinglesAlbumsShow = 0;
        private void ButtonSingles_Click(object sender, RoutedEventArgs e)
        {
            List<ModelMusicReleases> listSinglesOrAlbums = new List<ModelMusicReleases>();
            if (SinglesAlbumsShow == 0)
            {
                for (int i = 0; i < listMusicReleases.Count; i++)
                {
                    if (listMusicReleases[i].NameMusicReleasesAlbum.Contains("[Single]"))
                    {
                        listSinglesOrAlbums.Add(listMusicReleases[i]);
                    }
                }
                ListBoxMusicReleases.ItemsSource = listSinglesOrAlbums;
                SinglesAlbumsShow = 1;
                ButtonSingles.Content = "Albums";
            }
            else if (SinglesAlbumsShow == 1)
            {
                for (int i = 0; i < listMusicReleases.Count; i++)
                {
                    if (!listMusicReleases[i].NameMusicReleasesAlbum.Contains("[Single]"))
                    {
                        listSinglesOrAlbums.Add(listMusicReleases[i]);
                    }
                }
                ListBoxMusicReleases.ItemsSource = listSinglesOrAlbums;
                SinglesAlbumsShow = 2;
                ButtonSingles.Content = "All";
            }
            else
            {
                FillListBoxMusicReleases();
                SinglesAlbumsShow = 0;
            }
        }
        private void MenuItem_ClickEdit(object sender, RoutedEventArgs e)
        {
            int selectedIndex = ListBoxMusicReleases.SelectedIndex;
            if (selectedIndex != -1)
            {
                WindowsMusicReleasesEdit windowsMusicReleasesEdit = new WindowsMusicReleasesEdit(classWritingFile, this, selectedIndex);
                windowsMusicReleasesEdit.ShowDialog();
            }
        }
        private void ListBoxMusicReleases_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxMusicReleases.SelectedIndex;

                if (selectedIndex != -1)
                {
                    object data = ListBoxMusicReleases.Items[selectedIndex];
                    ModelMusicReleases release = data as ModelMusicReleases;
                    string fullName = $"{release.NameMusicReleasesGroup} - {release.NameMusicReleasesAlbum}";
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
