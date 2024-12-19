using System;
using System.Data;
using System.Windows;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow(DataRow reportData)
        {
            InitializeComponent();

            ReportDescription.Text = reportData["description"].ToString();
            ReportAttachment.Text = reportData["attachment"] != DBNull.Value
                ? reportData["attachment"].ToString()
                : "Нет вложения";
            UploadedDate.Text = reportData["uploaded"].ToString();
        }
    }
}
