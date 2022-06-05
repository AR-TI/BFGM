using BFGM.Classes;
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
        readonly ClassReadFile classReadFile;
        readonly ClassWriteFile classWriteFile;

        PageMusicReleases pageMusicReleases;
        PageMusicWait pageMusicWaiting;
        PageMusicListen pageMusicListen;

        public PageMusic(ClassMain classMain, ClassReadFile classReadFile, ClassWriteFile classWriteFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
            this.classWriteFile = classWriteFile;
        }

        #region Pages Music
        byte pageActivity;

        private void ButtonReleases_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            pageMusicReleases = new PageMusicReleases(classMain, classReadFile, classWriteFile);
            MusicFrame.Content = pageMusicReleases;
        }
        private void ButtonWait_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            pageMusicWaiting = new PageMusicWait(classMain, classReadFile);
            MusicFrame.Content = pageMusicWaiting;
        }
        private void ButtonListen_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            pageMusicListen = new PageMusicListen(classMain, classReadFile);
            MusicFrame.Content = pageMusicListen;
        }
        #endregion

        private void ButtonMusicAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowsMusicReleasesAdd windowsMusicReleasesAdd = new WindowsMusicReleasesAdd(classMain, classWriteFile, pageMusicReleases);
                windowsMusicReleasesAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowsMusicWaitingAdd windowsMusicWaitingAdd = new WindowsMusicWaitingAdd(classMain, classWriteFile, pageMusicWaiting);
                windowsMusicWaitingAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowsMusicListenAdd windowsMusicListenAdd = new WindowsMusicListenAdd(classMain, classWriteFile, pageMusicListen);
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

                    classMain.DeleteRelease(release);
                    await classWriteFile.WriteFileReleases();

                    pageMusicReleases.CurrentSort();
                }
            }
            else if (pageActivity == 2)
            {
                int selectedIndex = pageMusicWaiting.ListBoxWait.SelectedIndex;
                if (selectedIndex != -1)
                {
                    string selectedName = pageMusicWaiting.ListBoxWait.Items[selectedIndex].ToString();
                    classMain.DeleteWait(selectedName);
                    await classWriteFile.WriteFileWait();
                    pageMusicWaiting.ListBoxWait.Items.RemoveAt(selectedIndex);
                }
            }
            else if (pageActivity == 3)
            {
                int selectedIndex = pageMusicListen.ListBoxListen.SelectedIndex;
                if (selectedIndex != -1)
                {
                    string selectedName = pageMusicListen.ListBoxListen.Items[selectedIndex].ToString();
                    classMain.DeleteListen(selectedName);
                    await classWriteFile.WriteFileListen();
                    pageMusicListen.ListBoxListen.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
