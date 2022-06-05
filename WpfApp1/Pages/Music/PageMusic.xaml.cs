using BFGM.Classes;
using BFGM.Constants;
using BFGM.Models;
using BFGM.Pages.Music;
using BFGM.Windows.Music;
using System.Windows;
using System.Windows.Controls;

namespace BFGM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMusic.xaml
    /// </summary>
    public partial class PageMusic : Page
    {
        readonly ClassMain classMain;

        PageMusicReleases pageMusicReleases;
        PageMusicWait pageMusicWait;
        PageMusicListen pageMusicListen;

        public PageMusic(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        #region Pages Music
        byte pageActivity;

        private void ButtonReleases_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            pageMusicReleases = new PageMusicReleases(classMain);
            MusicFrame.Content = pageMusicReleases;
        }
        private void ButtonWait_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            pageMusicWait = new PageMusicWait(classMain);
            MusicFrame.Content = pageMusicWait;
        }
        private void ButtonListen_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            pageMusicListen = new PageMusicListen(classMain);
            MusicFrame.Content = pageMusicListen;
        }
        #endregion

        private void ButtonMusicAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowsMusicReleasesAdd windowsMusicReleasesAdd = new WindowsMusicReleasesAdd(classMain, pageMusicReleases);
                windowsMusicReleasesAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowsMusicWaitAdd windowsMusicWaitAdd = new WindowsMusicWaitAdd(classMain, pageMusicWait);
                windowsMusicWaitAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowsMusicListenAdd windowsMusicListenAdd = new WindowsMusicListenAdd(classMain, pageMusicListen);
                windowsMusicListenAdd.ShowDialog();
            }
        }

        private async void ButtonMusicDelete_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                int selectedIndex = pageMusicReleases.ListBoxReleases.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = pageMusicReleases.ListBoxReleases.Items[selectedIndex];
                    Release release = data as Release;
                    await classMain.Remove(classMain.ListReleases, release);
                    await classMain.Write(classMain.ListReleases, PathFiles.ReleasesPath);
                    pageMusicReleases.CurrentSort();
                }
            }
            else if (pageActivity == 2)
            {
                int selectedIndex = pageMusicWait.ListBoxWait.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = pageMusicWait.ListBoxWait.Items[selectedIndex];
                    Wait wait = data as Wait;
                    await classMain.Remove(classMain.ListWait, wait);
                    await classMain.Write(classMain.ListWait, PathFiles.WaitPath);
                    pageMusicWait.FillListWait();
                }
            }
            else if (pageActivity == 3)
            {
                int selectedIndex = pageMusicListen.ListBoxListen.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = pageMusicListen.ListBoxListen.Items[selectedIndex];
                    Listen listen = data as Listen;
                    await classMain.Remove(classMain.ListListen, listen);
                    await classMain.Write(classMain.ListListen, PathFiles.ListenPath);
                    pageMusicListen.FillListListen();
                }
            }
        }
    }
}
