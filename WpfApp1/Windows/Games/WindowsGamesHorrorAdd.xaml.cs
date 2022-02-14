using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Games;

namespace BFGM.Windows.Games
{
    /// <summary>
    /// Логика взаимодействия для WindowsGamesHorrorAdd.xaml
    /// </summary>
    public partial class WindowsGamesHorrorAdd : Window
    {
        ClassWritingFile classWritingFile;
        PageGamesHorrors pageGamesHorrors;

        public WindowsGamesHorrorAdd(ClassWritingFile classWritingFile, PageGamesHorrors pageGamesHorrors)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageGamesHorrors = pageGamesHorrors;
            TextBoxGamesHorror.Focus();
        }

        private void ButtonGamesHorrorAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddHorror();
        }

        private void WindowHorrorAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddHorror();
            }
        }

        private void AddHorror()
        {
            string nameGamesHorror = TextBoxGamesHorror.Text;
            if (nameGamesHorror.Length != 0)
            {
                classWritingFile.WritingFileGamesHorrors(nameGamesHorror);
                pageGamesHorrors.FillListGamesHorrors();
                Close();
            }
        }
    }
}
