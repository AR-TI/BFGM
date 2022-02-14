using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Games;

namespace BFGM.Windows.Games
{
    /// <summary>
    /// Логика взаимодействия для WindowsGamesPlayStationAdd.xaml
    /// </summary>
    public partial class WindowsGamesPlayStationAdd : Window
    {
        ClassWritingFile classWritingFile;
        PageGamesPlayStation pageGamesPlayStation;

        public WindowsGamesPlayStationAdd(ClassWritingFile classWritingFile, PageGamesPlayStation pageGamesPlayStation)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageGamesPlayStation = pageGamesPlayStation;
            TextBoxGamesPlayStation.Focus();
        }

        private void ButtonGamesPlayStationAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddPlayStation();
        }

        private void WindowPlayStationAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddPlayStation();
            }
        }

        private void AddPlayStation()
        {
            string nameGamesPlayStation = TextBoxGamesPlayStation.Text;
            if (nameGamesPlayStation.Length != 0)
            {
                classWritingFile.WritingFileGamesPlayStation(nameGamesPlayStation);
                pageGamesPlayStation.FillListGamesPlayStation();
                Close();
            }
        }
    }
}
