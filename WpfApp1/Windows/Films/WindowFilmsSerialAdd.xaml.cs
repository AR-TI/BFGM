using BFGM.Classes;
using BFGM.Models;
using BFGM.Pages.Films;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BFGM.Windows.Films
{
    /// <summary>
    /// Логика взаимодействия для WindowFilmsSerialAdd.xaml
    /// </summary>
    public partial class WindowFilmsSerialAdd : Window
    {
        readonly ClassMain classMain;
        readonly ClassWriteFile classWriteFile;
        readonly PageFilmsSerials pageFilmsSerials;

        public WindowFilmsSerialAdd(ClassMain classMain, ClassWriteFile classWriteFile, PageFilmsSerials pageFilmsSerials)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.classWriteFile = classWriteFile;
            this.pageFilmsSerials = pageFilmsSerials;
            TextBoxSerial.Focus();
        }

        private async void ButtonSerialAddOK_Click(object sender, RoutedEventArgs e)
        {
            await AddSerial();
        }

        private async void WindowSerialAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                await AddSerial();
            }
        }

        private async Task AddSerial()
        {
            string title = TextBoxSerial.Text;
            if (title.Length != 0)
            {
                classMain.ListSerials.Add(new Serial(title));
                await classWriteFile.WriteFileSerials();
                pageFilmsSerials.FillListSerials();
                Close();
            }
        }
    }
}
