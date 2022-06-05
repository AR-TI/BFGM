using BFGM;
using BFGM.Classes;
using BFGM.Models;
using BFGM.Pages.Music;
using BFGM.Windows.Music;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Windows.Music
{
    /// <summary>
    /// Логика взаимодействия для WindowsMusicReleasesEdit.xaml
    /// </summary>
    public partial class WindowsMusicReleasesEdit : Window
    {
        readonly ClassMain classMain;
        readonly ClassWriteFile classWriteFile;
        readonly PageMusicReleases pageMusicReleases;
        readonly Release releaseOld;
        public WindowsMusicReleasesEdit(ClassMain classMain, ClassWriteFile classWriteFile, PageMusicReleases pageMusicReleases, Release releaseOld)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageMusicReleases = pageMusicReleases;
            this.releaseOld = releaseOld;

            TextBoxBand.Text = releaseOld.Band;
            TextBoxAlbum.Text = releaseOld.Album;
            TextBoxDate.Text = releaseOld.Date.ToString("d MMMM yyyy");

            TextBoxBand.Focus();
        }

        private async Task EditRelease()
        {
            string newBand = TextBoxBand.Text;
            string newAlbum = TextBoxAlbum.Text;
            string newDate = TextBoxDate.Text;
            if (newBand.Length != 0 && newAlbum.Length != 0 && newDate.Length != 0)
            {
                if (!WindowsMusicReleasesAdd.IsRightDate(newDate, out DateTime newDateTime))
                {
                    MessageBox.Show("Wrong date!");
                }
                else
                {
                    classMain.EditRelease(releaseOld, new Release(newBand, newAlbum, newDateTime));
                    await classWriteFile.WriteFileReleases();
                    pageMusicReleases.CurrentSort();
                    Close();
                }
            }
        }

        private async void ButtonReleaseEditOK_Click(object sender, RoutedEventArgs e)
        {
            await EditRelease();
        }

        private async void WindowReleaseAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await EditRelease();
            }
        }
    }
}
