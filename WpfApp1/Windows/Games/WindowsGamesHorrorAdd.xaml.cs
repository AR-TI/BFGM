using BFGM.Classes;
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
    public partial class WindowsHorrorAdd : Window
    {
        readonly ClassMain classMain;
        readonly ClassWriteFile classWriteFile;
        readonly PageGamesHorrors pageGamesHorrors;

        public WindowsHorrorAdd(ClassMain classMain, ClassWriteFile classWriteFile, PageGamesHorrors pageGamesHorrors)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageGamesHorrors = pageGamesHorrors;
            TextBoxHorror.Focus();
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

        private async Task AddHorror()
        {
            string title = TextBoxHorror.Text;
            if (title.Length != 0)
            {
                classMain.ListHorrors.Add(new Horror(title));
                await classWriteFile.WriteFileHorrors();
                pageGamesHorrors.FillListHorrors();
                Close();
            }
        }
    }
}
