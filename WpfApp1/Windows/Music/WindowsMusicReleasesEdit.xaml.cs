using BFGM;
using BFGM.Models;
using BFGM.Pages.Music;
using System;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Windows.Music
{
    /// <summary>
    /// Логика взаимодействия для WindowsMusicReleasesEdit.xaml
    /// </summary>
    public partial class WindowsMusicReleasesEdit : Window
    {
        ClassWriteFile classWritingFile;
        PageMusicReleases pageMusicReleases;
        readonly Release releaseOld;
        public WindowsMusicReleasesEdit(ClassWriteFile classWritingFile, PageMusicReleases pageMusicReleases, Release releaseOld)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageMusicReleases = pageMusicReleases;
            this.releaseOld = releaseOld;

            TextBoxBand.Text = releaseOld.Band;
            TextBoxAlbum.Text = releaseOld.Album;
            TextBoxDate.Text = releaseOld.Date.ToString("d MMMM yyyy");

            TextBoxBand.Focus();
        }

        private async void EditRelease()
        {
            string newBand = TextBoxBand.Text;
            string newAlbum = TextBoxAlbum.Text;
            string newDate = TextBoxDate.Text;
            if (newBand.Length != 0 && newAlbum.Length != 0 && newDate.Length != 0)
            {
                if (!DateTime.TryParse(newDate, out DateTime newDateTime) || newDateTime.Year < DateTime.Now.Year)
                    MessageBox.Show("Wrong date!");
                else
                {
                    classWritingFile.ClassMainInfo.EditRelease(releaseOld, new Release(newBand, newAlbum, newDateTime));
                    await classWritingFile.RewriteFileAfterDeleteReleases();
                    pageMusicReleases.CurrentSort();
                    Close();
                }
            }
        }

        private void ButtonReleaseEditOK_Click(object sender, RoutedEventArgs e)
        {
            EditRelease();
        }

        private void WindowReleaseAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EditRelease();
            }
        }
    }
}
