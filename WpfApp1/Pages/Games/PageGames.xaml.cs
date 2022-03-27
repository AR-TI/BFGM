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

        ClassWriteFile classWritingFile;
        ClassReadFile classReadingFile;

        public PageGames(ClassReadFile classReadingFile, ClassWriteFile classWritingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
            this.classWritingFile = classWritingFile;
        }

        #region Pages Games
        private void ButtonPlayStation_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 1;
            //frameGames.Content = new PageGamesPlayStation();
            pageGamesPlayStation = new PageGamesPlayStation(classReadingFile);
            frameGames.Content = pageGamesPlayStation;
        }
        private void ButtonHorrors_Click(object sender, RoutedEventArgs e)
        {
            pageActivity = 2;
            //frameGames.Content = new PageGamesHorrors();
            pageGamesHorrors = new PageGamesHorrors(classReadingFile);
            frameGames.Content = pageGamesHorrors;
        }
        private void ButtonPlatformers_Click(object sender, RoutedEventArgs e)
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
                WindowsPlayStationAdd windowsPlayStationAdd = new WindowsPlayStationAdd(classWritingFile, pageGamesPlayStation);
                windowsPlayStationAdd.ShowDialog();
            }
            else if (pageActivity == 2)
            {
                WindowsHorrorAdd windowsHorrorAdd = new WindowsHorrorAdd(classWritingFile, pageGamesHorrors);
                windowsHorrorAdd.ShowDialog();
            }
            else if (pageActivity == 3)
            {
                WindowsPlatformerAdd windowsPlatformerAdd = new WindowsPlatformerAdd(classWritingFile, pageGamesPlatformers);
                windowsPlatformerAdd.ShowDialog();
            }
        }

        private void ButtonGamesDelete_Click(object sender, RoutedEventArgs e)
        {
            if (pageActivity == 1)
            {
                int selectedIndex = pageGamesPlayStation.ListBoxPlayStation.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageGamesPlayStation.ListBoxPlayStation.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeletePlayStation(selectedName);
                    classWritingFile.RewriteFileAfterDeletePlayStation();
                    pageGamesPlayStation.ListBoxPlayStation.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 2)
            {
                int selectedIndex = pageGamesHorrors.ListBoxHorrors.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageGamesHorrors.ListBoxHorrors.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeleteHorrors(selectedName);
                    classWritingFile.RewriteFileAfterDeleteHorrors();
                    pageGamesHorrors.ListBoxHorrors.Items.RemoveAt(selectedIndex);
                }
            }
            if (pageActivity == 3)
            {
                int selectedIndex = pageGamesPlatformers.ListBoxPlatformers.SelectedIndex;

                if (selectedIndex != -1)
                {
                    string selectedName = pageGamesPlatformers.ListBoxPlatformers.Items[selectedIndex].ToString();
                    classReadingFile.ClassMainInfo.DeletePlatformers(selectedName);
                    classWritingFile.RewriteFileAfterDeletePlatformers();
                    pageGamesPlatformers.ListBoxPlatformers.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
