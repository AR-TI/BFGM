using BFGM.Classes;
using BFGM.Constants;
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
        readonly PageFilmsSerials pageFilmsSerials;

        public WindowFilmsSerialAdd(ClassMain classMain, PageFilmsSerials pageFilmsSerials)
        {
            InitializeComponent();
            this.classMain = classMain;
            this.pageFilmsSerials = pageFilmsSerials;
            TextBoxSerial.Focus();
        }

        private async Task AddSerial()
        {
            string title = Functions.ToTitleCaseFirstWord(TextBoxSerial.Text);
            if (title.Length != 0)
            {
                await classMain.Add(classMain.ListSerials, new Serial(title));
                await classMain.Write(classMain.ListSerials, PathFiles.SerialsPath);
                pageFilmsSerials.FillListSerials();
                Close();
            }
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
    }
}
