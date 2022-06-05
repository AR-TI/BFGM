using BFGM.Classes;
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
    public partial class WindowsPlatformerAdd : Window
    {
        readonly ClassMain classMain;
        readonly ClassWriteFile classWriteFile;
        readonly PageGamesPlatformers pageGamesPlatformers;

        public WindowsPlatformerAdd(ClassMain classMain, ClassWriteFile classWriteFile, PageGamesPlatformers pageGamesPlatformers)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageGamesPlatformers = pageGamesPlatformers;
            TextBoxPlatformer.Focus();
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

        private async Task AddPlatformer()
        {
            string title = TextBoxPlatformer.Text;
            if (title.Length != 0)
            {
                classMain.ListPlatformers.Add(new Platformer(title));
                await classWriteFile.WriteFilePlatformers();
                pageGamesPlatformers.FillListPlatformers();
                Close();
            }
        }
    }
}
