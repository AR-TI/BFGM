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
        ClassWritingFile classWritingFile;
        PageFilmsCartoons pageFilmsCartoons;

        public WindowFilmsCartoonAdd(ClassWritingFile classWritingFile, PageFilmsCartoons pageFilmsCartoons)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageFilmsCartoons = pageFilmsCartoons;
            TextBoxFilmsCartoon.Focus();
        }

        private void ButtonFilmsCartoonAddOK_Click(object sender, RoutedEventArgs e)
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
            string nameFilmsCartoon = TextBoxFilmsCartoon.Text;
            if (nameFilmsCartoon.Length != 0)
            {
                classWritingFile.WritingFileFilmsCartoons(nameFilmsCartoon);
                pageFilmsCartoons.FillListFilmsCartoons();
                Close();
            }
        }
    }
}
