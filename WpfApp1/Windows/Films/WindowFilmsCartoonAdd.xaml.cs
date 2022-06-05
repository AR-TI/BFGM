using BFGM.Classes;
using BFGM.Models;
using BFGM.Pages.Films;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows.Films
{
    /// <summary>
    /// Логика взаимодействия для WindowFilmsCartoonAdd.xaml
    /// </summary>
    public partial class WindowFilmsCartoonAdd : Window
    {
        readonly ClassMain classMain;
        readonly ClassWriteFile classWriteFile;
        readonly PageFilmsCartoons pageFilmsCartoons;

        public WindowFilmsCartoonAdd(ClassMain classMain, ClassWriteFile classWriteFile, PageFilmsCartoons pageFilmsCartoons)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageFilmsCartoons = pageFilmsCartoons;
            TextBoxCartoon.Focus();
        }

        private async void ButtonCartoonAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddCartoon();
        }

        private async void WindowCartoonAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddCartoon();
            }
        }

        private async Task AddCartoon()
        {
            string title = TextBoxCartoon.Text;
            if (title.Length != 0)
            {
                classMain.ListCartoons.Add(new Cartoon(title));
                await classWriteFile.WriteFileCartoons();
                pageFilmsCartoons.FillListCartoons();
                Close();
            }
        }
    }
}
