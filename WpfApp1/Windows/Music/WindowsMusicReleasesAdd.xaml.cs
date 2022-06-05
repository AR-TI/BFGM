using BFGM.Classes;
using BFGM.Models;
using BFGM.Pages.Music;
using System;
using System.Globalization;
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
        readonly ClassWriteFile classWriteFile;
        readonly PageMusicReleases pageMusicReleases;

        public WindowsMusicReleasesAdd(ClassMain classMain, ClassWriteFile classWriteFile, PageMusicReleases pageMusicReleases)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageMusicReleases = pageMusicReleases;
            TextBoxBand.Focus();
        }

        private async Task AddReleases()
        {
            string band = TextBoxBand.Text;
            string album = TextBoxAlbum.Text;
            string date = TextBoxDate.Text;

            if (band.Contains("\r\n"))
            {
                await Parsing(band);
            }
            else if (band.Length != 0 && album.Length != 0 && date.Length != 0)
            {
                if (!IsRightDate(date, out DateTime dateTime))
                {
                    MessageBox.Show("Wrong date!");
                }
                else
                {
                    classMain.ListReleases.Add(new Release(ToTitleFirstLetter(band), ToTitleFirstLetter(album), dateTime));
                    await classWriteFile.WriteFileReleases();
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

            string band = strArrBandAlbum[0];
            string album = strArrBandAlbum[1];
            string date = dateArr[1].Replace(".", string.Empty);

            if (strArr[0].Contains("#single"))
            {
                album = string.Concat(album, " [Single]");
            }
            else if (strArr[0].Contains("#EP"))
            {
                album = string.Concat(album, " [EP]");
            }

            if (!IsRightDate(date, out DateTime dateTime))
            {
                MessageBox.Show("Wrong date!");
            }
            else if (band.Length != 0 && album.Length != 0)
            {
                classMain.ListReleases.Add(new Release(ToTitleFirstLetter(band), ToTitleFirstLetter(album), dateTime));
                await classWriteFile.WriteFileReleases();
                pageMusicReleases.CurrentSort();
                Close();
            }
        }

        public static bool IsRightDate(string date, out DateTime dateTime)
        {
            return DateTime.TryParse(date, out dateTime) && dateTime.Year >= DateTime.Now.Year;
        }

        private static string ToTitleFirstLetter(string str)
        {
            TextInfo textInfo = new CultureInfo("ru-RU").TextInfo;
            return textInfo.ToTitleCase(str);
            //return str = textInfo.ToTitleCase(textInfo.ToLower(str)); //В том числе и аббревиатуры
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
