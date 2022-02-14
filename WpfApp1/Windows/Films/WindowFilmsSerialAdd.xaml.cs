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
        ClassWritingFile classWritingFile;
        PageFilmsSerials pageFilmsSerials;

        public WindowFilmsSerialAdd(ClassWritingFile classWritingFile, PageFilmsSerials pageFilmsSerials)
        {
            InitializeComponent();
            this.classWritingFile = classWritingFile;
            this.pageFilmsSerials = pageFilmsSerials;
            TextBoxFilmsSerial.Focus();
        }

        private void ButtonFilmsSerialAddOK_Click(object sender, RoutedEventArgs e)
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
            string nameFilmsSerial = TextBoxFilmsSerial.Text;
            if (nameFilmsSerial.Length != 0)
            {
                classWritingFile.WritingFileFilmsSerials(nameFilmsSerial);
                pageFilmsSerials.FillListFilmsSerials();
                Close();
            }
        }
    }
}
