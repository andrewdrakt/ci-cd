using System.Windows;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for SeniorScientistPanel.xaml
    /// </summary>
    public partial class SeniorScientistPanel : Window
    {
        public SeniorScientistPanel()
        {
            InitializeComponent();
            pageFrame.Content = new SeniorReg();
        }

        private void employeeAddBtn_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = new SeniorReg();
        }


        private void programmExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void taskAddBtn_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = new SeniorTaskAdd();
        }

        private void tasksBtn_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = new SeniorTaskWatch();
        }

        private void employeeViewingBtn_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = new SeniorViewEmployees();
        }
    }
}
