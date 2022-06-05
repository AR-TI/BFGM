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
    /// Логика взаимодействия для WindowsMusicWaitAdd.xaml
    /// </summary>
    public partial class WindowsMusicWaitAdd : Window
    {
        readonly ClassMain classMain;
        readonly PageMusicWait pageMusicWait;

        public WindowsMusicWaitAdd(ClassMain classMain, PageMusicWait pageMusicWait)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageMusicWait = pageMusicWait;
            TextBoxWait.Focus();
        }

        private async Task AddWait()
        {
            string band = Functions.ToTitleCaseAllWords(TextBoxWait.Text);
            if (band.Length != 0)
            {
                await classMain.Add(classMain.ListWait, new Wait(band));
                await classMain.Write(classMain.ListWait, PathFiles.WaitPath);
                pageMusicWait.FillListWait();
                Close();
            }
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
    }
}
