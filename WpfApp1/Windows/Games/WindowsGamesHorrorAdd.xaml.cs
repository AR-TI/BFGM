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
    /// Логика взаимодействия для WindowsGamesHorrorAdd.xaml
    /// </summary>
    public partial class WindowsGamesHorrorAdd : Window
    {
        readonly ClassMain classMain;
        readonly PageGamesHorrors pageGamesHorrors;

        public WindowsGamesHorrorAdd(ClassMain classMain, PageGamesHorrors pageGamesHorrors)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageGamesHorrors = pageGamesHorrors;
            TextBoxHorror.Focus();
        }

        private async Task AddHorror()
        {
            string title = Functions.ToTitleCaseAllWords(TextBoxHorror.Text);
            if (title.Length != 0)
            {
                await classMain.Add(classMain.ListHorrors, new Horror(title));
                await classMain.Write(classMain.ListHorrors, PathFiles.HorrorsPath);
                pageGamesHorrors.FillListHorrors();
                Close();
            }
        }

        private async void ButtonHorrorAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddHorror();
        }

        private async void WindowHorrorAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddHorror();
            }
        }
    }
}
