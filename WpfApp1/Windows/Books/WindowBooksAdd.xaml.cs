using BFGM.Models;
using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowBooksAdd.xaml
    /// </summary>
    public partial class WindowBooksAdd : Window
    {
        ClassWriteFile classWritingFile;

        public WindowBooksAdd(ClassWriteFile classWritingFile)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            TextBoxTitle.Focus();
        }

        private void AddBook()
        {
            string title = TextBoxTitle.Text;
            string author = TextBoxAuthor.Text;
            if (title.Length != 0 && author.Length != 0)
            {
                classWritingFile.WriteFileBooks(new Book(title, author));
                Close();
            }
        }

        private void ButtonBookAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddBook();
        }

        private void WindowBookAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddBook();
            }
        }
    }
}
