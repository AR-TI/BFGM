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
        ClassWriteFile classWritingFile;
        PageMusicListen pageMusicListen;

        public WindowsMusicListenAdd(ClassWriteFile classWritingFile, PageMusicListen pageMusicListen)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageMusicListen = pageMusicListen;
            TextBoxListen.Focus();
        }

        private void ButtonListenAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddListen();
        }

        private void WindowListenAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddListen();
            }
        }

        private void AddListen()
        {
            string band = TextBoxListen.Text;
            if (band.Length != 0)
            {
                classWritingFile.WriteFileListen(band);
                pageMusicListen.FillListListen();
                Close();
            }
        }
    }
}
