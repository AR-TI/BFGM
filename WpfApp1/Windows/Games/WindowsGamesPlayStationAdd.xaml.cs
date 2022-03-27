using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Games;

namespace BFGM.Windows.Games
{
    /// <summary>
    /// Логика взаимодействия для WindowsGamesPlayStationAdd.xaml
    /// </summary>
    public partial class WindowsPlayStationAdd : Window
    {
        ClassWriteFile classWritingFile;
        PageGamesPlayStation pageGamesPlayStation;

        public WindowsPlayStationAdd(ClassWriteFile classWritingFile, PageGamesPlayStation pageGamesPlayStation)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageGamesPlayStation = pageGamesPlayStation;
            TextBoxPlayStation.Focus();
        }

        private void ButtonPlayStationAddOK_Click(object sender, RoutedEventArgs e)
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
            string title = TextBoxPlayStation.Text;
            if (title.Length != 0)
            {
                classWritingFile.WriteFilePlayStation(title);
                pageGamesPlayStation.FillListPlayStation();
                Close();
            }
        }
    }
}
