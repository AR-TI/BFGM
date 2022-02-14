using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Music;

namespace BFGM.Windows.Music
{
    /// <summary>
    /// Логика взаимодействия для WindowsMusicWaitingAdd.xaml
    /// </summary>
    public partial class WindowsMusicWaitingAdd : Window
    {
        ClassWritingFile classWritingFile;
        PageMusicWaiting pageMusicWaiting;

        public WindowsMusicWaitingAdd(ClassWritingFile classWritingFile, PageMusicWaiting pageMusicWaiting)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageMusicWaiting = pageMusicWaiting;
            TextBoxMusicWaiting.Focus();
        }

        private void ButtonMusicWaitingAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddWaiting();
        }

        private void WindowWaitingAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddWaiting();
            }
        }

        private void AddWaiting()
        {
            string nameMusicWaiting = TextBoxMusicWaiting.Text;
            if (nameMusicWaiting.Length != 0)
            {
                classWritingFile.WritingFileMusicWaiting(nameMusicWaiting);
                pageMusicWaiting.FillListMusicWaiting();
                Close();
            }
        }
    }
}
