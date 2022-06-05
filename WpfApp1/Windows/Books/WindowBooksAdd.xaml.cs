using BFGM.Classes;
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
        readonly ClassWriteFile classWriteFile;

        public WindowBooksAdd(ClassMain classMain, ClassWriteFile classWriteFile)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            TextBoxTitle.Focus();
        }

        private async Task AddBook()
        {
            string title = TextBoxTitle.Text;
            string author = TextBoxAuthor.Text;
            if (title.Length != 0 && author.Length != 0)
            {
                classMain.ListBooks.Add(new Book(title, author));
                await classWriteFile.WriteFileBooks();
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
