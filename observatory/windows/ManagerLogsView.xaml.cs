using observatory.observatoryDataSetTableAdapters;
using System.Windows.Controls;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for ManagerLogsView.xaml
    /// </summary>
    public partial class ManagerLogsView : Page
    {
        logsTableAdapter logs = new logsTableAdapter();
        public ManagerLogsView()
        {
            InitializeComponent();
            logsDG.ItemsSource = logs.GetData();
        }
    }
}