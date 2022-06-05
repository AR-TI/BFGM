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
    /// Логика взаимодействия для WindowsGamesPlatformerAdd.xaml
    /// </summary>
    public partial class WindowsGamesPlatformerAdd : Window
    {
        readonly ClassMain classMain;
        readonly PageGamesPlatformers pageGamesPlatformers;

        public WindowsGamesPlatformerAdd(ClassMain classMain, PageGamesPlatformers pageGamesPlatformers)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageGamesPlatformers = pageGamesPlatformers;
            TextBoxPlatformer.Focus();
        }

        private async Task AddPlatformer()
        {
            string title = Functions.ToTitleCaseAllWords(TextBoxPlatformer.Text);
            if (title.Length != 0)
            {
                await classMain.Add(classMain.ListPlatformers, new Platformer(title));
                await classMain.Write(classMain.ListPlatformers, PathFiles.PlatformersPath);
                pageGamesPlatformers.FillListPlatformers();
                Close();
            }
        }

        private async void ButtonPlatformerAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddPlatformer();
        }

        private async void WindowPlatformerAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddPlatformer();
            }
        }
    }
}
