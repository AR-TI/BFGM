using BFGM.Classes;
using BFGM.Models;
using BFGM.Pages.Music;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows.Music
{
    /// <summary>
    /// Логика взаимодействия для WindowsMusicListenAdd.xaml
    /// </summary>
    public partial class WindowsMusicListenAdd : Window
    {
        readonly ClassMain classMain;
        readonly ClassWriteFile classWriteFile;
        readonly PageMusicListen pageMusicListen;

        public WindowsMusicListenAdd(ClassMain classMain, ClassWriteFile classWriteFile, PageMusicListen pageMusicListen)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageMusicListen = pageMusicListen;
            TextBoxListen.Focus();
        }

        private async void ButtonListenAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddListen();
        }

        private async void WindowListenAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddListen();
            }
        }

        private async Task AddListen()
        {
            string band = TextBoxListen.Text;
            if (band.Length != 0)
            {
                classMain.ListListen.Add(new Listen(band));
                await classWriteFile.WriteFileListen();
                pageMusicListen.FillListListen();
                Close();
            }
        }
    }
}
