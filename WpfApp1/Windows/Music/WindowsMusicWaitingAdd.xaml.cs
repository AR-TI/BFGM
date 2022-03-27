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
        ClassWriteFile classWritingFile;
        PageMusicWait pageMusicWaiting;

        public WindowsMusicWaitingAdd(ClassWriteFile classWritingFile, PageMusicWait pageMusicWaiting)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageMusicWaiting = pageMusicWaiting;
            TextBoxWait.Focus();
        }

        private void ButtonWaitAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddWait();
        }

        private void WindowWaitAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddWait();
            }
        }

        private void AddWait()
        {
            string band = TextBoxWait.Text;
            if (band.Length != 0)
            {
                classWritingFile.WriteFileWait(band);
                pageMusicWaiting.FillListWait();
                Close();
            }
        }
    }
}
