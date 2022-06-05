using BFGM.Classes;
using BFGM.Models;
using BFGM.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BFGM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBooks.xaml
    /// </summary>
    public partial class PageBooks : Page
    {
        readonly ClassMain classMain;
        readonly ClassReadFile classReadFile;
        readonly ClassWriteFile classWriteFile;

        public PageBooks(ClassMain classMain, ClassReadFile classReadFile, ClassWriteFile classWriteFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classReadFile = classReadFile;
            this.classWriteFile = classWriteFile;
        }

        static private bool isFirstTime = false;
        private async void GridBooks_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                await classReadFile.ReadFileBooks();
                isFirstTime = true;
            }
            FillListBooks();
        }

        private void ButtonBooksAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowBooksAdd windowBooksAdd = new WindowBooksAdd(classMain, classWriteFile);
            windowBooksAdd.ShowDialog();
            FillListBooks();
        }
        private async void ButtonBooksDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = ListBoxBooks.SelectedIndex;

            if (selectedIndex != -1)
            {
                Book book = ListBoxBooks.Items[selectedIndex] as Book;
                classMain.DeleteBook(book);
                await classWriteFile.WriteFileBooks();
                FillListBooks();
            }
        }

        public void FillListBooks()
        {
            List<Book> listBooks = classMain.ListBooks.OrderBy(x => x.Title).ToList();
            ListBoxBooks.ItemsSource = listBooks;
        }

        private void ListBoxBooks_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            int selectedItems = ListBoxBooks.SelectedIndex;

            if (selectedItems != -1)
            {
                Book book = ListBoxBooks.Items[selectedItems] as Book;
                Clipboard.SetText($"{book.Title} - {book.Author}");
            }
        }
    }
}
