using BFGM.Classes;
using BFGM.Constants;
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
        readonly PageMusicListen pageMusicListen;

        public WindowsMusicListenAdd(ClassMain classMain, PageMusicListen pageMusicListen)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageMusicListen = pageMusicListen;
            TextBoxListen.Focus();
        }

        private async Task AddListen()
        {
            string band = Functions.ToTitleCaseAllWords(TextBoxListen.Text);
            if (band.Length != 0)
            {
                await classMain.Add(classMain.ListListen, new Listen(band));
                await classMain.Write(classMain.ListListen, PathFiles.ListenPath);
                pageMusicListen.FillListListen();
                Close();
            }
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
    }
}
