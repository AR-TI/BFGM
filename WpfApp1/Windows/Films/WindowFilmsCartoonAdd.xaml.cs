using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Films;

namespace BFGM.Windows.Films
{
    /// <summary>
    /// Логика взаимодействия для WindowFilmsCartoonAdd.xaml
    /// </summary>
    public partial class WindowFilmsCartoonAdd : Window
    {
        ClassWriteFile classWritingFile;
        PageFilmsCartoons pageFilmsCartoons;

        public WindowFilmsCartoonAdd(ClassWriteFile classWritingFile, PageFilmsCartoons pageFilmsCartoons)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageFilmsCartoons = pageFilmsCartoons;
            TextBoxCartoon.Focus();
        }

        private void ButtonCartoonAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddCartoon();
        }

        private void WindowCartoonAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddCartoon();
            }
        }

        private void AddCartoon()
        {
            string title = TextBoxCartoon.Text;
            if (title.Length != 0)
            {
                classWritingFile.WriteFileCartoons(title);
                pageFilmsCartoons.FillListCartoons();
                Close();
            }
        }
    }
}
