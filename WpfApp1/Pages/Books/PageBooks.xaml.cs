using BFGM.Classes;
using BFGM.Constants;
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

        public PageBooks(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
        }

        public void FillListBooks()
        {
            ListBoxBooks.ItemsSource = classMain.ListBooks.OrderBy(x => x.Title).ToList();
        }

        private bool isFirstTime = false;
        private async void ListBoxBooks_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classMain.ListBooks = await classMain.Read<Book>(PathFiles.BooksPath);
                isFirstTime = true;
            }

            FillListBooks();
        }

        private void ButtonBooksAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowBooksAdd windowBooksAdd = new WindowBooksAdd(classMain);
            windowBooksAdd.ShowDialog();
            FillListBooks();
        }
        private async void ButtonBooksDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = ListBoxBooks.SelectedIndex;
            if (selectedIndex != -1)
            {
                object data = ListBoxBooks.Items[selectedIndex];
                Book book = data as Book;
                await classMain.Remove(classMain.ListBooks, book);
                await classMain.Write(classMain.ListBooks, PathFiles.BooksPath);
                FillListBooks();
            }
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
