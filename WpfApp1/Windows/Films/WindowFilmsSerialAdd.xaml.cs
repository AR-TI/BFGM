using System.Windows;
using System.Windows.Input;
using BFGM.Pages.Films;

namespace BFGM.Windows.Films
{
    /// <summary>
    /// Логика взаимодействия для WindowFilmsSerialAdd.xaml
    /// </summary>
    public partial class WindowFilmsSerialAdd : Window
    {
        ClassWriteFile classWritingFile;
        PageFilmsSerials pageFilmsSerials;

        public WindowFilmsSerialAdd(ClassWriteFile classWritingFile, PageFilmsSerials pageFilmsSerials)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageFilmsSerials = pageFilmsSerials;
            TextBoxSerial.Focus();
        }

        private void ButtonSerialAddOK_Click(object sender, RoutedEventArgs e)
        {
            AddSerial();
        }

        private void WindowSerialAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddSerial();
            }
        }

        private void AddSerial()
        {
            string title = TextBoxSerial.Text;
            if (title.Length != 0)
            {
                classWritingFile.WriteFileSerials(title);
                pageFilmsSerials.FillListSerials();
                Close();
            }
        }
    }
}
