using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Games;

namespace BFGM.Windows.Games
{
    /// <summary>
    /// Логика взаимодействия для WindowsGamesPlatformerAdd.xaml
    /// </summary>
    public partial class WindowsGamesPlatformerAdd : Window
    {
        ClassWritingFile classWritingFile;
        PageGamesPlatformers pageGamesPlatformers;

        public WindowsGamesPlatformerAdd(ClassWritingFile classWritingFile, PageGamesPlatformers pageGamesPlatformers)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageGamesPlatformers = pageGamesPlatformers;
            TextBoxGamesPlatformer.Focus();
        }

        private void ButtonGamesPlatformerAddOK_Click(object sender, RoutedEventArgs e)
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
            string nameGamesPlatformer = TextBoxGamesPlatformer.Text;
            if (nameGamesPlatformer.Length != 0)
            {
                classWritingFile.WritingFileGamesPlatformers(nameGamesPlatformer);
                pageGamesPlatformers.FillListGamesPlatformers();
                Close();
            }
        }
    }
}
