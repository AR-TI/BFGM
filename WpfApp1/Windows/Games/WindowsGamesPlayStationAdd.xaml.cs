using BFGM.Classes;
using BFGM.Constants;
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
    public partial class WindowsGamesPlayStationAdd : Window
    {
        readonly ClassMain classMain;
        readonly PageGamesPlayStation pageGamesPlayStation;

        public WindowsGamesPlayStationAdd(ClassMain classMain, PageGamesPlayStation pageGamesPlayStation)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageGamesPlayStation = pageGamesPlayStation;
            TextBoxPlayStation.Focus();
        }

        private async Task AddPlayStation()
        {
            string title = Functions.ToTitleCaseAllWords(TextBoxPlayStation.Text);
            if (title.Length != 0)
            {
                await classMain.Add(classMain.ListPlayStation, new PlayStation(title));
                await classMain.Write(classMain.ListPlayStation, PathFiles.PlayStationPath);
                pageGamesPlayStation.FillListPlayStation();
                Close();
            }
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
    }
}
