using System;
using System.Windows;
using System.Windows.Controls;
using BFGM.Models;
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
        PageMusicWait pageMusicWaiting;
        PageMusicListen pageMusicListen;

        ClassWriteFile classWriteFile;
        ClassReadFile classReadFile;

        public PageMusic(ClassReadFile classReadFile, ClassWriteFile classWriteFile)
        {
            InitializeComponent();
            this.classReadFile = classReadFile;
            this.classWriteFile = classWriteFile;
        }

        #region Pages Music
        byte pageActivity;

        private void ButtonReleases_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            //frameMusic.Content = new Music.PageMusicReleases();
            pageMusicReleases = new PageMusicReleases(classReadFile, classWriteFile/*new*/);
            frameMusic.Content = pageMusicReleases;
        }
        private void ButtonWait_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            //frameMusic.Content = new Music.PageMusicWaiting();
            pageMusicWaiting = new PageMusicWait(classReadFile);
            frameMusic.Content = pageMusicWaiting;
        }
        private void ButtonListen_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            //frameMusic.Content = new Music.PageMusicListen();
            pageMusicListen = new PageMusicListen(classReadFile);
            frameMusic.Content = pageMusicListen;
        }
        #endregion

        private void ButtonMusicAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowsMusicReleasesAdd windowsMusicReleasesAdd = new WindowsMusicReleasesAdd(classWriteFile, pageMusicReleases);
                windowsMusicReleasesAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowsMusicWaitingAdd windowsMusicWaitingAdd = new WindowsMusicWaitingAdd(classWriteFile, pageMusicWaiting);
                windowsMusicWaitingAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowsMusicListenAdd windowsMusicListenAdd = new WindowsMusicListenAdd(classWriteFile, pageMusicListen);
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

                    classReadFile.ClassMainInfo.DeleteRelease(release);
                    await classWriteFile.RewriteFileAfterDeleteReleases();

                    pageMusicReleases.CurrentSort();
                }
            }
            else if (pageActivity == 2)
            {
                int selectedIndex = pageMusicWaiting.ListBoxWait.SelectedIndex;
                if (selectedIndex != -1)
                {
                    string selectedName = pageMusicWaiting.ListBoxWait.Items[selectedIndex].ToString();
                    classReadFile.ClassMainInfo.DeleteWait(selectedName);
                    classWriteFile.RewriteFileAfterDeleteWait();
                    pageMusicWaiting.ListBoxWait.Items.RemoveAt(selectedIndex);
                }
            }
            else if (pageActivity == 3)
            {
                int selectedIndex = pageMusicListen.ListBoxListen.SelectedIndex;
                if (selectedIndex != -1)
                {
                    string selectedName = pageMusicListen.ListBoxListen.Items[selectedIndex].ToString();
                    classReadFile.ClassMainInfo.DeleteListen(selectedName);
                    classWriteFile.RewriteFileAfterDeleteListen();
                    pageMusicListen.ListBoxListen.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
