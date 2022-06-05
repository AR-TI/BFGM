using BFGM.Classes;
using BFGM.Models;
using BFGM.Pages.Games;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows.Games
{
    /// <summary>
    /// Логика взаимодействия для WindowsGamesPlayStationAdd.xaml
    /// </summary>
    public partial class WindowsPlayStationAdd : Window
    {
        readonly ClassMain classMain;
        readonly ClassWriteFile classWriteFile;
        readonly PageGamesPlayStation pageGamesPlayStation;

        public WindowsPlayStationAdd(ClassMain classMain, ClassWriteFile classWriteFile, PageGamesPlayStation pageGamesPlayStation)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageGamesPlayStation = pageGamesPlayStation;
            TextBoxPlayStation.Focus();
        }

        private async void ButtonPlayStationAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddPlayStation();
        }

        private async void WindowPlayStationAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddPlayStation();
            }
        }

        private async Task AddPlayStation()
        {
            string title = TextBoxPlayStation.Text;
            if (title.Length != 0)
            {
                classMain.ListPlayStation.Add(new PlayStation(title));
                await classWriteFile.WriteFilePlayStation();
                pageGamesPlayStation.FillListPlayStation();
                Close();
            }
        }
    }
}
