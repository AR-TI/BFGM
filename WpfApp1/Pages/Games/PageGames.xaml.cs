using BFGM.Classes;
using BFGM.Constants;
using BFGM.Models;
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

        PageGamesPlayStation pageGamesPlayStation;
        PageGamesHorrors pageGamesHorrors;
        PageGamesPlatformers pageGamesPlatformers;

        byte pageActivity;

        public PageGames(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        #region Pages Games
        private void ButtonPlayStation_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            pageGamesPlayStation = new PageGamesPlayStation(classMain);
            GamesFrame.Content = pageGamesPlayStation;
        }
        private void ButtonHorrors_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            pageGamesHorrors = new PageGamesHorrors(classMain);
            GamesFrame.Content = pageGamesHorrors;
        }
        private void ButtonPlatformers_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            pageGamesPlatformers = new PageGamesPlatformers(classMain);
            GamesFrame.Content = pageGamesPlatformers;
        }
        #endregion

        private void ButtonGamesAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowsGamesPlayStationAdd windowsPlayStationAdd = new WindowsGamesPlayStationAdd(classMain, pageGamesPlayStation);
                windowsPlayStationAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowsGamesHorrorAdd windowsHorrorAdd = new WindowsGamesHorrorAdd(classMain, pageGamesHorrors);
                windowsHorrorAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowsGamesPlatformerAdd windowsPlatformerAdd = new WindowsGamesPlatformerAdd(classMain, pageGamesPlatformers);
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
                    object data = pageGamesPlayStation.ListBoxPlayStation.Items[selectedIndex];
                    PlayStation playStation = data as PlayStation;
                    await classMain.Remove(classMain.ListPlayStation, playStation);
                    await classMain.Write(classMain.ListPlayStation, PathFiles.PlayStationPath);
                    pageGamesPlayStation.FillListPlayStation();
                }
            }
            if (pageActivity == 2)
            {
                int selectedIndex = pageGamesHorrors.ListBoxHorrors.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = pageGamesHorrors.ListBoxHorrors.Items[selectedIndex];
                    Horror horror = data as Horror;
                    await classMain.Remove(classMain.ListHorrors, horror);
                    await classMain.Write(classMain.ListHorrors, PathFiles.HorrorsPath);
                    pageGamesHorrors.FillListHorrors();
                }
            }
            if (pageActivity == 3)
            {
                int selectedIndex = pageGamesPlatformers.ListBoxPlatformers.SelectedIndex;
                if (selectedIndex != -1)
                {
                    object data = pageGamesPlatformers.ListBoxPlatformers.Items[selectedIndex];
                    Platformer platformer = data as Platformer;
                    await classMain.Remove(classMain.ListPlatformers, platformer);
                    await classMain.Write(classMain.ListPlatformers, PathFiles.PlatformersPath);
                    pageGamesPlatformers.FillListPlatformers();
                }
            }
        }
    }
}
