using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BFGM.Windows;
using BFGM.Models;

namespace BFGM.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBooks.xaml
    /// </summary>
    public partial class PageBooks : Page
    {
        ClassReadingFile classReadingFile;
        ClassWritingFile classWritingFile;

        public PageBooks(ClassReadingFile classReadingFile, ClassWritingFile classWritingFile)
        {
            InitializeComponent();
            this.classReadingFile = classReadingFile;
            this.classWritingFile = classWritingFile;
        }

        static private bool isFirstTime = false;
        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isFirstTime)
            {
                classReadingFile.ReadingFileBooksBooks();
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

        private int CheckIndex(int indexBook, int indexAuthor)
        {
            if (indexBook != -1)
                return indexBook;
            return indexAuthor;
        }
        private void ButtonBooksDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndexBook = ListBoxBooksBook.SelectedIndex;
            int selectedIndexAuthor = ListBoxBooksAuthor.SelectedIndex;
            if (selectedIndexBook != -1 || selectedIndexAuthor != -1)
            {
                int index = CheckIndex(selectedIndexBook, selectedIndexAuthor);
                string selectedBook = ListBoxBooksBook.Items[index].ToString();
                string selectedAuthor = ListBoxBooksAuthor.Items[index].ToString();
                classReadingFile.ClassMainInfo.DeleteBooks(selectedBook, selectedAuthor);
                classWritingFile.RewritingFileAfterDeleteBooks();
                ListBoxBooksBook.Items.RemoveAt(index);
                ListBoxBooksAuthor.Items.RemoveAt(index);
            }
        }

        public void FillListBooks()
        {
            ListBoxBooksBook.Items.Clear();
            ListBoxBooksAuthor.Items.Clear();
            List<ModelBook> listBooks = classReadingFile.ClassMainInfo.ListBooks;
            for (int i = 0; i < listBooks.Count; i++)
            {
                ListBoxBooksBook.Items.Add(listBooks[i].NameBooksBook);
            }
            for (int i = 0; i < listBooks.Count; i++)
            {
                ListBoxBooksAuthor.Items.Add(listBooks[i].NameBooksAuthor);
            }
        }

        private void ListBoxBooksBook_KeyDown_Clipboard(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int selectedIndex = ListBoxBooksBook.SelectedIndex;

                if (selectedIndex != -1)
                {
                    Clipboard.SetText(ListBoxBooksBook.Items[selectedIndex].ToString());
                }
            }
        }
    }
}
