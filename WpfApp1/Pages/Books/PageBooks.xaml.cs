using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Windows;
using BFGM.Models;
using System.Linq;

namespace BFGM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBooks.xaml
    /// </summary>
    public partial class PageBooks : Page
    {
        ClassReadFile classReadingFile;
        ClassWriteFile classWritingFile;

        public PageBooks(ClassReadFile classReadingFile, ClassWriteFile classWritingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
            this.classWritingFile = classWritingFile;
        }

        static private bool isFirstTime = false;
        private void GridBooks_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadFileBooks();
                isFirstTime = true;
            }
            FillListBooks();
        }

        private void ButtonBooksAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowBooksAdd windowBooksAdd = new WindowBooksAdd(classWritingFile);
            windowBooksAdd.ShowDialog();
            FillListBooks();
        }
        private void ButtonBooksDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = ListBoxBooks.SelectedIndex;

            if (selectedIndex != -1)
            {
                Book book = ListBoxBooks.Items[selectedIndex] as Book;
                classReadingFile.ClassMainInfo.DeleteBook(book);
                classWritingFile.RewriteFileAfterDeleteBooks();
                FillListBooks();
            }
        }

        public void FillListBooks()
        {
            List<Book> listBooks = classReadingFile.ClassMainInfo.ListBooks.OrderBy(x => x.Title).ToList();
            ListBoxBooks.ItemsSource = listBooks;
        }

        private void ListBoxBooks_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            int selectedItems = ListBoxBooks.SelectedIndex;

            if (selectedItems !=-1)
            {
                Book book = ListBoxBooks.Items[selectedItems] as Book;
                Clipboard.SetText($"{book.Title} - {book.Author}");
            }
        }
    }
}
