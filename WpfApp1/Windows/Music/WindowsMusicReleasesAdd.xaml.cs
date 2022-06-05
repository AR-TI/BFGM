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
    /// Логика взаимодействия для WindowsMusicReleasesAdd.xaml
    /// </summary>
    public partial class WindowsMusicReleasesAdd : Window
    {
        readonly ClassMain classMain;
        readonly PageMusicReleases pageMusicReleases;

        public WindowsMusicReleasesAdd(ClassMain classMain, PageMusicReleases pageMusicReleases)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageMusicReleases = pageMusicReleases;
            TextBoxBand.Focus();
        }

        private async Task AddReleases()
        {
            string band = Functions.ToTitleCaseAllWords(TextBoxBand.Text);
            string album = Functions.ToTitleCaseAllWords(TextBoxAlbum.Text);
            string date = TextBoxDate.Text;

            if (band.Contains("\r\n"))
            {
                await Parsing(band);
            }
            else if (band.Length != 0 && album.Length != 0 && date.Length != 0)
            {
                if (!Functions.IsRightDate(date, out DateTime dateTime))
                {
                    MessageBox.Show("Wrong date!");
                }
                else
                {
                    await classMain.Add(classMain.ListReleases, new Release(band, album, dateTime));
                    await classMain.Write(classMain.ListReleases, PathFiles.ReleasesPath);
                    pageMusicReleases.CurrentSort();
                    Close();
                }
            }
        }

        private async Task Parsing(string strFull)
        {
            string[] strArr = strFull.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] strArrBandAlbum = strArr[1].Split(new string[] { " - " }, StringSplitOptions.None);
            string[] dateArr = strArr[3].Split(new string[] { ": " }, StringSplitOptions.None);

            string band = Functions.ToTitleCaseAllWords(strArrBandAlbum[0]);
            string album = Functions.ToTitleCaseAllWords(strArrBandAlbum[1]);
            string date = dateArr[1].Replace(".", string.Empty);

            if (strArr[0].Contains("#single"))
            {
                album = string.Concat(album, " [Single]");
            }
            else if (strArr[0].Contains("#EP"))
            {
                album = string.Concat(album, " [EP]");
            }

            if (!Functions.IsRightDate(date, out DateTime dateTime))
            {
                MessageBox.Show("Wrong date!");
            }
            else if (band.Length != 0 && album.Length != 0)
            {
                await classMain.Add(classMain.ListReleases, new Release(band, album, dateTime));
                await classMain.Write(classMain.ListReleases, PathFiles.ReleasesPath);
                pageMusicReleases.CurrentSort();
                Close();
            }
        }

        private async void ButtonReleaseAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddReleases();
        }

        private async void WindowReleaseAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddReleases();
            }
        }
    }
}
