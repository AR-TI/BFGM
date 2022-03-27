using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using BFGM.Models;
using BFGM.Pages.Music;

namespace BFGM.Windows.Music
{
    /// <summary>
    /// Логика взаимодействия для WindowsMusicReleasesAdd.xaml
    /// </summary>
    public partial class WindowsMusicReleasesAdd : Window
    {
        ClassWriteFile classWritingFile;
        PageMusicReleases pageMusicReleases;

        public WindowsMusicReleasesAdd(ClassWriteFile classWritingFile, PageMusicReleases pageMusicReleases)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageMusicReleases = pageMusicReleases;
            TextBoxBand.Focus();
        }

        private void AddReleases()
        {
            string band = TextBoxBand.Text;
            string album = TextBoxAlbum.Text;
            string date = TextBoxDate.Text;

            if (band.Contains("\r\n"))
            {
                Parsing(band);
            }
            else if (band.Length != 0 && album.Length != 0 && date.Length != 0)
            {
                if (!DateTime.TryParse(date, out DateTime dateTime) || dateTime.Year < DateTime.Now.Year)
                    MessageBox.Show("Wrong date!");
                else
                {
                    classWritingFile.WriteFileReleases(new Release (ToTitleFirstLetter(band), ToTitleFirstLetter(album), dateTime));
                    pageMusicReleases.CurrentSort();
                    Close();
                }
            }
        }

        private void Parsing(string strFull)
        {
            //int indexFirst = strFull.IndexOf(" - ");
            //string[] strArr = strFull.Remove(indexFirst, 3).Insert(indexFirst, "^").Split("\r\n");

            string[] strArr = strFull.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] strArrBandAlbum = strArr[1].Split(new string[] { " - " }, StringSplitOptions.None);
            string[] dateArr = strArr[3].Split(new string[] { ": " }, StringSplitOptions.None);

            string band = strArrBandAlbum[0];
            string album = strArrBandAlbum[1];
            string date = dateArr[1].Replace(".", "");

            if (strArr[0].Contains("#single"))
            {
                album = string.Concat(album, " [Single]");
            }
            else if (strArr[0].Contains("#EP"))
            {
                album = string.Concat(album, " [EP]");
            }

            if (!DateTime.TryParse(date, out DateTime dateTimeMusicReleases) || dateTimeMusicReleases.Year < DateTime.Now.Year)
                MessageBox.Show("Wrong date!");
            else if (band.Length != 0 && album.Length != 0)
            {
                classWritingFile.WriteFileReleases(new Release (ToTitleFirstLetter(band), ToTitleFirstLetter(album), dateTimeMusicReleases));
                pageMusicReleases.CurrentSort();
                Close();
            }
        }

        private string ToTitleFirstLetter(string str)
        {
            TextInfo textInfo = new CultureInfo("ru-RU").TextInfo;
            return textInfo.ToTitleCase(str);
            //return str = textInfo.ToTitleCase(textInfo.ToLower(str)); //В том числе и аббревиатуры
        }

        private void ButtonReleaseAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddReleases();
        }

        private void WindowReleaseAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddReleases();
            }
        }
    }
}
