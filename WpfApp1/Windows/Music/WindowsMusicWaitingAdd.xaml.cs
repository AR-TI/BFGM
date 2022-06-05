using BFGM.Classes;
using BFGM.Models;
using BFGM.Pages.Music;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows.Music
{
    /// <summary>
    /// Логика взаимодействия для WindowsMusicWaitingAdd.xaml
    /// </summary>
    public partial class WindowsMusicWaitingAdd : Window
    {
        readonly ClassMain classMain;
        readonly ClassWriteFile classWriteFile;
        readonly PageMusicWait pageMusicWaiting;

        public WindowsMusicWaitingAdd(ClassMain classMain, ClassWriteFile classWriteFile, PageMusicWait pageMusicWaiting)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageMusicWaiting = pageMusicWaiting;
            TextBoxWait.Focus();
        }

        private async void ButtonWaitAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddWait();
        }

        private async void WindowWaitAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddWait();
            }
        }

        private async Task AddWait()
        {
            string band = TextBoxWait.Text;
            if (band.Length != 0)
            {
                classMain.ListWait.Add(new Wait(band));
                await classWriteFile.WriteFileWait();
                pageMusicWaiting.FillListWait();
                Close();
            }
        }
    }
}
