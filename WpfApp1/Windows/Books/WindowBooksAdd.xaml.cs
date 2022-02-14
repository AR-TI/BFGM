using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowBooksAdd.xaml
    /// </summary>
    public partial class WindowBooksAdd : Window
    {
        ClassWritingFile classWritingFile;

        public WindowBooksAdd(ClassWritingFile classWritingFile)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            TextBoxBooksBook.Focus();
        }
        
        private void ButtonBooksAddOK_Click(object sender, RoutedEventArgs e)
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

        private void AddBook()
        {
            string nameBook = TextBoxBooksBook.Text;
            string nameAuthor = TextBoxBooksAuthor.Text;
            if (nameBook.Length != 0 && nameAuthor.Length != 0)
            {
                classWritingFile.WritingFileBooks(nameBook, nameAuthor);
                Close();
            }
        }
    }
}
