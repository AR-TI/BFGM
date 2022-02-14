using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Music;

namespace BFGM.Windows.Music
{
    /// <summary>
    /// Логика взаимодействия для WindowsMusicListenAdd.xaml
    /// </summary>
    public partial class WindowsMusicListenAdd : Window
    {
        ClassWritingFile classWritingFile;
        PageMusicListen pageMusicListen;

        public WindowsMusicListenAdd(ClassWritingFile classWritingFile, PageMusicListen pageMusicListen)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageMusicListen = pageMusicListen;
            TextBoxMusicListen.Focus();
        }

        private void ButtonMusicListenAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddListen();
        }

        private void WindowMusicAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddListen();
            }
        }

        private void AddListen()
        {
            string nameMusicListen = TextBoxMusicListen.Text;
            if (nameMusicListen.Length != 0)
            {
                classWritingFile.WritingFileMusicListen(nameMusicListen);
                pageMusicListen.FillListMusicListen();
                Close();
            }
        }
    }
}
