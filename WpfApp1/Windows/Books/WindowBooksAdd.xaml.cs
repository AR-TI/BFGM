using BFGM.Classes;
using BFGM.Constants;
using BFGM.Models;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowBooksAdd.xaml
    /// </summary>
    public partial class WindowBooksAdd : Window
    {
        readonly ClassMain classMain;

        public WindowBooksAdd(ClassMain classMain)
        {
            InitializeComponent();
            this.classMain = classMain;
            TextBoxTitle.Focus();
        }

        private async Task AddBook()
        {
            string title = Functions.ToTitleCaseFirstWord(TextBoxTitle.Text);
            string author = Functions.ToTitleCaseAllWords(TextBoxAuthor.Text);
            if (title.Length != 0 && author.Length != 0)
            {
                await classMain.Add(classMain.ListBooks, new Book(title, author));
                await classMain.Write(classMain.ListBooks, PathFiles.BooksPath);
                Close();
            }
        }

        private async void ButtonBookAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddBook();
        }

        private async void WindowBookAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddBook();
            }
        }
    }
}
