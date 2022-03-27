using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Games;

namespace BFGM.Windows.Games
{
    /// <summary>
    /// Логика взаимодействия для WindowsGamesPlatformerAdd.xaml
    /// </summary>
    public partial class WindowsPlatformerAdd : Window
    {
        ClassWriteFile classWritingFile;
        PageGamesPlatformers pageGamesPlatformers;

        public WindowsPlatformerAdd(ClassWriteFile classWritingFile, PageGamesPlatformers pageGamesPlatformers)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageGamesPlatformers = pageGamesPlatformers;
            TextBoxPlatformer.Focus();
        }

        private void ButtonPlatformerAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddPlatformer();
        }

        private void WindowPlatformerAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddPlatformer();
            }
        }

        private void AddPlatformer()
        {
            string title = TextBoxPlatformer.Text;
            if (title.Length != 0)
            {
                classWritingFile.WriteFilePlatformers(title);
                pageGamesPlatformers.FillListPlatformers();
                Close();
            }
        }
    }
}
