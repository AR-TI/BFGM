using BFGM.Classes;
using BFGM.Constants;
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
        readonly PageFilmsCartoons pageFilmsCartoons;

        public WindowFilmsCartoonAdd(ClassMain classMain, PageFilmsCartoons pageFilmsCartoons)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageFilmsCartoons = pageFilmsCartoons;
            TextBoxCartoon.Focus();
        }

        private async Task AddCartoon()
        {
            string title = Functions.ToTitleCaseFirstWord(TextBoxCartoon.Text);
            if (title.Length != 0)
            {
                await classMain.Add(classMain.ListCartoons, new Cartoon(title));
                await classMain.Write(classMain.ListCartoons, PathFiles.CartoonsPath);
                pageFilmsCartoons.FillListCartoons();
                Close();
            }
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
    }
}
