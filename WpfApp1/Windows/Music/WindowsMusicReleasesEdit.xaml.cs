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
        ClassWritingFile classWritingFile;
        PageMusicReleases pageMusicReleases;
        readonly string oldGroup, oldAlbum, oldDate;
        public WindowsMusicReleasesEdit(ClassWritingFile classWritingFile, PageMusicReleases pageMusicReleases, int selectedIndex)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageMusicReleases = pageMusicReleases;

            object data = pageMusicReleases.ListBoxMusicReleases.Items[selectedIndex];
            ModelMusicReleases release = data as ModelMusicReleases;

            oldGroup = release.NameMusicReleasesGroup;
            oldAlbum = release.NameMusicReleasesAlbum;
            oldDate = release.NameMusicReleasesDate.ToString("d MMMM yyyy");

            TextBoxMusicReleasesGroup.Text = oldGroup;
            TextBoxMusicReleasesAlbum.Text = oldAlbum;
            TextBoxMusicReleasesDate.Text = oldDate;

            TextBoxMusicReleasesGroup.Focus();
        }

        private void EditRelease()
        {
            string newGroup = TextBoxMusicReleasesGroup.Text;
            string newAlbum = TextBoxMusicReleasesAlbum.Text;
            string newDate = TextBoxMusicReleasesDate.Text;
            if (newGroup.Length != 0 && newGroup.Length != 0 && newDate.Length != 0)
            {
                if (!DateTime.TryParse(newDate, out DateTime newDateTime) || newDateTime.Year < DateTime.Now.Year)
                    MessageBox.Show("Wrong date!");
                else
                {
                    classWritingFile.ClassMainInfo.EditMusicReleases(oldGroup, oldAlbum, DateTime.Parse(oldDate), newGroup, newAlbum, newDateTime);
                    classWritingFile.RewritingFileAfterDeleteMusicReleases();
                    pageMusicReleases.FillListBoxMusicReleases();
                    Close();
                }
            }
        }

        private void ButtonMusicReleaseEditOK_Click(object sender, RoutedEventArgs e)
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
