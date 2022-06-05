using BFGM.Classes;
using BFGM.Constants;
using BFGM.Models;
using BFGM.Pages.Music;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows.Music
{
    /// <summary>
    /// Логика взаимодействия для WindowsMusicReleasesEdit.xaml
    /// </summary>
    public partial class WindowsMusicReleasesEdit : Window
    {
        readonly ClassMain classMain;
        readonly PageMusicReleases pageMusicReleases;
        readonly Release releaseOld;

        public WindowsMusicReleasesEdit(ClassMain classMain, PageMusicReleases pageMusicReleases, Release releaseOld)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageMusicReleases = pageMusicReleases;
            this.releaseOld = releaseOld;

            TextBoxBand.Text = releaseOld.Band;
            TextBoxAlbum.Text = releaseOld.Album;
            TextBoxDate.Text = releaseOld.Date.ToString("d MMMM yyyy");

            TextBoxBand.Focus();
        }

        private async Task EditRelease()
        {
            string newBand = Functions.ToTitleCaseAllWords(TextBoxBand.Text);
            string newAlbum = Functions.ToTitleCaseAllWords(TextBoxAlbum.Text);
            string newDate = TextBoxDate.Text;
            if (newBand.Length != 0 && newAlbum.Length != 0 && newDate.Length != 0)
            {
                if (!Functions.IsRightDate(newDate, out DateTime newDateTime))
                {
                    MessageBox.Show("Wrong date!");
                }
                else
                {
                    await classMain.Edit(classMain.ListReleases, releaseOld, new Release(newBand, newAlbum, newDateTime));
                    await classMain.Write(classMain.ListReleases, PathFiles.ReleasesPath);
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
