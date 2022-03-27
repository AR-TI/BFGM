using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Games;

namespace BFGM.Windows.Games
{
    /// <summary>
    /// Логика взаимодействия для WindowsGamesHorrorAdd.xaml
    /// </summary>
    public partial class WindowsHorrorAdd : Window
    {
        ClassWriteFile classWritingFile;
        PageGamesHorrors pageGamesHorrors;

        public WindowsHorrorAdd(ClassWriteFile classWritingFile, PageGamesHorrors pageGamesHorrors)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageGamesHorrors = pageGamesHorrors;
            TextBoxHorror.Focus();
        }

        private void ButtonHorrorAddOK_Click(object sender, RoutedEventArgs e)
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
            string title = TextBoxHorror.Text;
            if (title.Length != 0)
            {
                classWritingFile.WriteFileHorrors(title);
                pageGamesHorrors.FillListHorrors();
                Close();
            }
        }
    }
}
