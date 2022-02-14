using System.Windows;
using System.Windows.Controls;
using BFGM.Pages.Music;
using BFGM.Windows.Music;

namespace BFGM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMusic.xaml
    /// </summary>
    public partial class PageMusic : Page
    {
        PageMusicReleases pageMusicReleases;
        PageMusicWaiting pageMusicWaiting;
        PageMusicListen pageMusicListen;

        ClassWritingFile classWritingFile;
        ClassReadingFile classReadingFile;

        public PageMusic(ClassReadingFile classReadingFile, ClassWritingFile classWritingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
            this.classWritingFile = classWritingFile;
        }

        #region Pages Music
        byte pageActivity;
        private void Button_Click_MusicReleases(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            //frameMusic.Content = new Music.PageMusicReleases();
            pageMusicReleases = new PageMusicReleases(classReadingFile, classWritingFile/*new*/);
            frameMusic.Content = pageMusicReleases;
        }
        private void Button_Click_MusicWaiting(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            //frameMusic.Content = new Music.PageMusicWaiting();
            pageMusicWaiting = new PageMusicWaiting(classReadingFile);
            frameMusic.Content = pageMusicWaiting;
        }
        private void Button_Click_MusicListen(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            //frameMusic.Content = new Music.PageMusicListen();
            pageMusicListen = new PageMusicListen(classReadingFile);
            frameMusic.Content = pageMusicListen;
        }
        #endregion

        private void ButtonMusicAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowsMusicReleasesAdd windowsMusicReleasesAdd = new WindowsMusicReleasesAdd(classWritingFile, pageMusicReleases);
                windowsMusicReleasesAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowsMusicWaitingAdd windowsMusicWaitingAdd = new WindowsMusicWaitingAdd(classWritingFile, pageMusicWaiting);
                windowsMusicWaitingAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowsMusicListenAdd windowsMusicListenAdd = new WindowsMusicListenAdd(classWritingFile, pageMusicListen);
                windowsMusicListenAdd.ShowDialog();
            }
        }

        private void ButtonMusicDelete_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                int selectedIndexGroup = pageMusicReleases.ListBoxMusicReleasesGroup.SelectedIndex;
                int selectedIndexAlbum = pageMusicReleases.ListBoxMusicReleasesAlbum.SelectedIndex;
                //int selectedIndexDate = pageMusicReleases.ListBoxMusicReleasesDate.SelectedIndex;
                if (selectedIndexGroup != -1)
                {
                    string selectedName = pageMusicReleases.ListBoxMusicReleasesGroup.Items[selectedIndexGroup].ToString();
                    classReadingFile.ClassMainInfo.DeleteMusicReleases(selectedName);
                    classWritingFile.RewritingFileAfterDeleteMusicReleases();
                    pageMusicReleases.ListBoxMusicReleasesGroup.Items.RemoveAt(selectedIndexGroup);
                    pageMusicReleases.ListBoxMusicReleasesAlbum.Items.RemoveAt(selectedIndexGroup);
                    pageMusicReleases.ListBoxMusicReleasesDate.Items.RemoveAt(selectedIndexGroup);
                }
                if (selectedIndexAlbum != -1)
                {
                    string selectedName = pageMusicReleases.ListBoxMusicReleasesAlbum.Items[selectedIndexAlbum].ToString();
                    classReadingFile.ClassMainInfo.DeleteMusicReleases(selectedName);
                    classWritingFile.RewritingFileAfterDeleteMusicReleases();
                    pageMusicReleases.ListBoxMusicReleasesGroup.Items.RemoveAt(selectedIndexAlbum);
                    pageMusicReleases.ListBoxMusicReleasesAlbum.Items.RemoveAt(selectedIndexAlbum);
                    pageMusicReleases.ListBoxMusicReleasesDate.Items.RemoveAt(selectedIndexAlbum);
                }
                //if (selectedIndexDate != -1)
                //{
                //    string selectedName = pageMusicReleases.ListBoxMusicReleasesDate.Items[selectedIndexDate].ToString();
                //    classReadingFile.ClassMainInfo.DeleteMusicReleases(selectedName);
                //    classWritingFile.RewritingFileAfterDeleteMusicReleases();
                //    pageMusicReleases.ListBoxMusicReleasesGroup.Items.RemoveAt(selectedIndexDate);
                //    pageMusicReleases.ListBoxMusicReleasesAlbum.Items.RemoveAt(selectedIndexDate);
                //    pageMusicReleases.ListBoxMusicReleasesDate.Items.RemoveAt(selectedIndexDate);
                //}
            }
            if (pageActivity == 2)
            {
                int selectedIndex = pageMusicWaiting.ListBoxMusicWaiting.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageMusicWaiting.ListBoxMusicWaiting.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteMusicWaiting(selectedName);
                    classWritingFile.RewritingFileAfterDeleteMusicWaiting();
                    pageMusicWaiting.ListBoxMusicWaiting.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 3)
            {
                int selectedIndex = pageMusicListen.ListBoxMusicListen.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageMusicListen.ListBoxMusicListen.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteMusicListen(selectedName);
                    classWritingFile.RewritingFileAfterDeleteMusicListen();
                    pageMusicListen.ListBoxMusicListen.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
