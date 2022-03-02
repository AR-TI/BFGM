using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Music;

namespace BFGM.Windows.Music
{
    /// <summary>
    /// Логика взаимодействия для WindowsMusicReleasesAdd.xaml
    /// </summary>
    public partial class WindowsMusicReleasesAdd : Window
    {
        ClassWritingFile classWritingFile;
        PageMusicReleases pageMusicReleases;

        public WindowsMusicReleasesAdd(ClassWritingFile classWritingFile, PageMusicReleases pageMusicReleases)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageMusicReleases = pageMusicReleases;
            TextBoxMusicReleasesGroup.Focus();
        }

        private void AddReleases()
        {
            string nameMusicReleasesGroup = TextBoxMusicReleasesGroup.Text;
            string nameMusicReleasesAlbum = TextBoxMusicReleasesAlbum.Text;
            string nameMusicReleasesDate = TextBoxMusicReleasesDate.Text;

            if (nameMusicReleasesGroup.Contains("Стиль: "))
            {
                Parsing(nameMusicReleasesGroup);
            }
            else if (nameMusicReleasesGroup.Length != 0 && nameMusicReleasesAlbum.Length != 0 && nameMusicReleasesDate.Length != 0)
            {
                if (!DateTime.TryParse(nameMusicReleasesDate, out DateTime dateTimeMusicReleases) || dateTimeMusicReleases.Year < DateTime.Now.Year)
                    MessageBox.Show("Wrong date!");
                else
                {
                    classWritingFile.WritingFileMusicReleases(ToTitleFirstLetter(nameMusicReleasesGroup), ToTitleFirstLetter(nameMusicReleasesAlbum), dateTimeMusicReleases);
                    pageMusicReleases.FillListBoxMusicReleases();
                    Close();
                }
            }
        }

        private void Parsing(string strAll)
        {
            int indexFirst = strAll.IndexOf(" - ");
            strAll = strAll.Remove(indexFirst, 3).Insert(indexFirst, "^");
            string[] strArray = strAll.Split('^', ':');
            string group = strArray[0];
            string album = strArray[1].Replace("Стиль", "").Trim();
            if (group.Contains("#single"))
            {
                group = group.Replace("#single #details", "").Trim();
                album = string.Concat(album, " [Single]");
            }
            else if (group.Contains("#EP"))
            {
                group = group.Replace("#EP #details", "").Trim();
                album = string.Concat(album, " [EP]");
            }
            string date = strArray[3].Replace(".", "").Trim();
            if (!DateTime.TryParse(date, out DateTime dateTimeMusicReleases) || dateTimeMusicReleases.Year < DateTime.Now.Year)
                MessageBox.Show("Wrong date!");
            else if (group.Length != 0 && album.Length != 0)
            {
                classWritingFile.WritingFileMusicReleases(ToTitleFirstLetter(group), ToTitleFirstLetter(album), dateTimeMusicReleases);
                pageMusicReleases.FillListBoxMusicReleases();
                Close();
            }
        }

        private string ToTitleFirstLetter(string str)
        {
            var textInfo = new CultureInfo("ru-RU").TextInfo;
            return textInfo.ToTitleCase(str);
            //return str = textInfo.ToTitleCase(textInfo.ToLower(str)); //В том числе и аббревиатуры
        }

        private void ButtonMusicReleaseAddOK_Click(object sender, RoutedEventArgs e)
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
