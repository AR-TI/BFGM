using BFGM.Classes;
using BFGM.Pages.Games;
using BFGM.Windows.Games;
using System.Windows;
using System.Windows.Controls;

namespace BFGM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageGames.xaml
    /// </summary>
    public partial class PageGames : Page
    {
        readonly ClassMain classMain;
        readonly ClassReadFile classReadFile;
        readonly ClassWriteFile classWriteFile;

        PageGamesPlayStation pageGamesPlayStation;
        PageGamesHorrors pageGamesHorrors;
        PageGamesPlatformers pageGamesPlatformers;

        byte pageActivity;

        public PageGames(ClassMain classMain, ClassReadFile classReadFile, ClassWriteFile classWriteFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
            this.classWriteFile = classWriteFile;
        }

        #region Pages Games
        private void ButtonPlayStation_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            pageGamesPlayStation = new PageGamesPlayStation(classMain, classReadFile);
            GamesFrame.Content = pageGamesPlayStation;
        }
        private void ButtonHorrors_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            pageGamesHorrors = new PageGamesHorrors(classMain, classReadFile);
            GamesFrame.Content = pageGamesHorrors;
        }
        private void ButtonPlatformers_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            pageGamesPlatformers = new PageGamesPlatformers(classMain, classReadFile);
            GamesFrame.Content = pageGamesPlatformers;
        }
        #endregion

        private void ButtonGamesAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowsPlayStationAdd windowsPlayStationAdd = new WindowsPlayStationAdd(classMain, classWriteFile, pageGamesPlayStation);
                windowsPlayStationAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowsHorrorAdd windowsHorrorAdd = new WindowsHorrorAdd(classMain, classWriteFile, pageGamesHorrors);
                windowsHorrorAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowsPlatformerAdd windowsPlatformerAdd = new WindowsPlatformerAdd(classMain, classWriteFile, pageGamesPlatformers);
                windowsPlatformerAdd.ShowDialog();
            }
        }

        private async void ButtonGamesDelete_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                int selectedIndex = pageGamesPlayStation.ListBoxPlayStation.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageGamesPlayStation.ListBoxPlayStation.Items[selectedIndex].ToString();
                    classMain.DeletePlayStation(selectedName);
                    await classWriteFile.WriteFilePlayStation();
                    pageGamesPlayStation.ListBoxPlayStation.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 2)
            {
                int selectedIndex = pageGamesHorrors.ListBoxHorrors.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageGamesHorrors.ListBoxHorrors.Items[selectedIndex].ToString();
                    classMain.DeleteHorrors(selectedName);
                    await classWriteFile.WriteFileHorrors();
                    pageGamesHorrors.ListBoxHorrors.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 3)
            {
                int selectedIndex = pageGamesPlatformers.ListBoxPlatformers.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageGamesPlatformers.ListBoxPlatformers.Items[selectedIndex].ToString();
                    classMain.DeletePlatformers(selectedName);
                    await classWriteFile.WriteFilePlatformers();
                    pageGamesPlatformers.ListBoxPlatformers.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
