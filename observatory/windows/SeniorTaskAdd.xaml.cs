using observatory.code;
using observatory.observatoryDataSetTableAdapters;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for SeniorTaskAdd.xaml
    /// </summary>
    public partial class SeniorTaskAdd : Page
    {
        taskTableAdapter task = new taskTableAdapter();
        logsTableAdapter log = new logsTableAdapter();
        CurrentUser currentUser = new CurrentUser();
        departmentTableAdapter department = new departmentTableAdapter();
        DateTime currentDateTime = DateTime.Now;
        public DateTime TodayDate { get; set; }
        public SeniorTaskAdd()
        {
            InitializeComponent();
            for (int r = 1; r < 6; r++)
            {
                priorityBox.Items.Add(r);
            }
            var departmentData = department.GetData().Rows;

            for (int r = 0; r < departmentData.Count - 1; r++)
            {
                departmentBox.Items.Add(departmentData[r][1]);
            }
            TodayDate = DateTime.Today;
            DataContext = this;
            //issue.SelectedDate = DateTime.Today;
        }

        private void taskAddBtn_Click(object sender, RoutedEventArgs e)
        {

            string formattedDateTime = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            if (taskNameInput.Text != null && descriptionInput.Text != null &&
                departmentBox.SelectedItem != null && priorityBox.SelectedItem != null &&
                issue.SelectedDate != null && deadline.SelectedDate != null)
            {
                task.addTask(taskNameInput.Text, departmentBox.SelectedItem.ToString(),
                    descriptionInput.Text, issue.Text, deadline.Text,
                    priorityBox.SelectedIndex + 1, attachment.Text, 0, null);
                MessageBox.Show("Задача успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                log.createLog(formattedDateTime.ToString(), currentUser.Name,
                    "добавил(а)", "Задача", taskNameInput.Text);
            } else {
                MessageBox.Show("Вы не выбрали значение или не заполнили одну из строк.");
            }

        }

        private void issue_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (issue.SelectedDate != null)
            {
                deadline.DisplayDateStart = issue.SelectedDate.Value.AddDays(1);
            }
            else
            {
                deadline.DisplayDateStart = null;
            }
        }

        private void deadline_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (deadline.SelectedDate != null)
            {
                issue.DisplayDateEnd = deadline.SelectedDate.Value.AddDays(-1);
            }
            else
            {
                issue.DisplayDateEnd = null;
            }
        }
    }
}
