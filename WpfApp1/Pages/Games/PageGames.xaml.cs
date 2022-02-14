using System.Windows;
using System.Windows.Controls;
using BFGM.Pages.Games;
using BFGM.Windows.Games;

namespace BFGM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageGames.xaml
    /// </summary>
    public partial class PageGames : Page
    {
        byte pageActivity;

        PageGamesPlayStation pageGamesPlayStation;
        PageGamesHorrors pageGamesHorrors;
        PageGamesPlatformers pageGamesPlatformers;

        ClassWritingFile classWritingFile;
        ClassReadingFile classReadingFile;

        public PageGames(ClassReadingFile classReadingFile, ClassWritingFile classWritingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
            this.classWritingFile = classWritingFile;
        }

        #region Pages Games
        private void Button_Click_GamesPlayStation(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            //frameGames.Content = new PageGamesPlayStation();
            pageGamesPlayStation = new PageGamesPlayStation(classReadingFile);
            frameGames.Content = pageGamesPlayStation;
        }
        private void Button_Click_GamesHorrors(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            //frameGames.Content = new PageGamesHorrors();
            pageGamesHorrors = new PageGamesHorrors(classReadingFile);
            frameGames.Content = pageGamesHorrors;
        }
        private void Button_Click_GamesPlatformers(object sender, RoutedEventArgs e)
        {
            pageActivity = 3;
            //frameGames.Content = new PageGamesPlatformers();
            pageGamesPlatformers = new PageGamesPlatformers(classReadingFile);
            frameGames.Content = pageGamesPlatformers;
        }
        #endregion

        private void ButtonGamesAdd_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                WindowsGamesPlayStationAdd windowsGamesPlayStationAdd = new WindowsGamesPlayStationAdd(classWritingFile, pageGamesPlayStation);
                windowsGamesPlayStationAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowsGamesHorrorAdd windowsGamesHorrorAdd = new WindowsGamesHorrorAdd(classWritingFile, pageGamesHorrors);
                windowsGamesHorrorAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowsGamesPlatformerAdd windowsGamesPlatformerAdd = new WindowsGamesPlatformerAdd(classWritingFile, pageGamesPlatformers);
                windowsGamesPlatformerAdd.ShowDialog();
            }
        }

        private void ButtonGamesDelete_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                int selectedIndex = pageGamesPlayStation.ListBoxGamesPlayStation.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageGamesPlayStation.ListBoxGamesPlayStation.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteGamesPlayStation(selectedName);
                    classWritingFile.RewritingFileAfterDeleteGamesPlayStation();
                    pageGamesPlayStation.ListBoxGamesPlayStation.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 2)
            {
                int selectedIndex = pageGamesHorrors.ListBoxGamesHorrors.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageGamesHorrors.ListBoxGamesHorrors.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteGamesHorrors(selectedName);
                    classWritingFile.RewritingFileAfterDeleteGamesHorrors();
                    pageGamesHorrors.ListBoxGamesHorrors.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 3)
            {
                int selectedIndex = pageGamesPlatformers.ListBoxGamesPlatformers.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageGamesPlatformers.ListBoxGamesPlatformers.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteGamesPlatformers(selectedName);
                    classWritingFile.RewritingFileAfterDeleteGamesPlatformers();
                    pageGamesPlatformers.ListBoxGamesPlatformers.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
