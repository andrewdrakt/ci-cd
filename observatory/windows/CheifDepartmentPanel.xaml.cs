using observatory.code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using observatory.observatoryDataSetTableAdapters;
using System.Globalization;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for CheifDepartmentPanel.xaml
    /// </summary>
    public partial class CheifDepartmentPanel : Window
    {
        logsTableAdapter log = new logsTableAdapter();
        private string connectionString = "Server=LEGION;Database=observatory;Integrated Security=True;";
        private CurrentUser currentUser;
        public CheifDepartmentPanel(CurrentUser user)
        {
            InitializeComponent();
            currentUser = user;
            LoadTasks();
        }
        private class ReportData
        {
            public object[] Array { get; set; }
        }
        private ReportData reportData = new ReportData();
        private void LoadTasks()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT * 
                        FROM task
                        WHERE department_id = @DepartmentName";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepartmentName", currentUser.Department);

                    var adapter = new SqlDataAdapter(command);
                    var tasksTable = new DataTable();
                    adapter.Fill(tasksTable);

                    taskDG.ItemsSource = tasksTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки задач: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void taskDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (taskDG.SelectedItem is DataRowView selectedTask)
            {
                int taskId = Convert.ToInt32(selectedTask["id_task"]);
                bool hasReport = selectedTask["report_id"] != DBNull.Value;
                if (Convert.ToByte((taskDG.SelectedItem as DataRowView).Row[8]) == 1)
                {
                    editReport.IsEnabled=false;
                }
                else
                {
                    editReport.IsEnabled = true;
                }
                if (hasReport)
                {
                    int reportId = Convert.ToInt32(selectedTask["report_id"]);
                    LoadReport(reportId);
                }
                else
                {
                    ClearReportFields();
                }
            }
        }
        private void LoadReport(int reportId)
        {
            try
            {
                reportTableAdapter reportAdapter = new reportTableAdapter();
                DataTable reportDataTable = reportAdapter.GetDataById(reportId);

                if (reportDataTable.Rows.Count > 0)
                {
                    DataRow report = reportDataTable.Rows[0];
                    reportData.Array = new object[]
                    {
                report["attachment"], report["uploaded"], report["description"]
                    };

                    attachment.Text = report["attachment"].ToString();
                    
                    description.Text = report["description"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отчёта: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearReportFields()
        {
            reportData.Array = null;
            attachment.Clear();
            description.Clear();
        }

        private void ViewNotes_Click(object sender, RoutedEventArgs e)
        {
            if (taskDG.SelectedItem is DataRowView selectedTask)
            {
                int taskId = Convert.ToInt32(selectedTask["id_task"]);

                try
                {
                    DataTable notes = GetNotesByTaskId(taskId);

                    if (notes.Rows.Count > 0)
                    {
                        
                        NotesWindow notesWindow = new NotesWindow(notes);
                        notesWindow.Owner = Window.GetWindow(this);
                        notesWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Для этой задачи отсутствуют заметки.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки заметок: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для просмотра заметок.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private DataTable GetNotesByTaskId(int taskId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT description, attachment, uploaded, fio
                FROM note
                WHERE task_id = @TaskId";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TaskId", taskId);

                    var adapter = new SqlDataAdapter(command);
                    var notesTable = new DataTable();
                    adapter.Fill(notesTable);

                    return notesTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения заметок: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return new DataTable();
            }
        }

        private void AttachReport_Click(object sender, RoutedEventArgs e)
        {
            if (taskDG.SelectedItem is DataRowView selectedTask)
            {
                bool isCompleted = Convert.ToBoolean(selectedTask["check_task"]);
                if (isCompleted)
                {
                    MessageBox.Show("Невозможно прикрепить отчет к выполненной задаче.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                /*var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Выберите отчет"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;*/
                    string formattedDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                    try
                    {
                        reportTableAdapter reportAdapter = new reportTableAdapter();
                        int newReportId = reportAdapter.createReport(
                            //Path.GetFileName(filePath),
                            attachment.Text,
                            formattedDateTime,
                            description.Text
                        );

                        taskTableAdapter taskAdapter = new taskTableAdapter();
                        int taskId = Convert.ToInt32(selectedTask["id_task"]);
                        taskAdapter.updateTaskReport(newReportId, taskId);

                        log.createLog(formattedDateTime, currentUser.Name, "прикрепил(а)", "Отчет", $"ID задачи: {taskId}");

                        MessageBox.Show("Отчет успешно прикреплен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка прикрепления отчета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                //}
            }
        }

        private void EditReport_Click(object sender, RoutedEventArgs e)
        {
            if (taskDG.SelectedItem is DataRowView selectedTask)
            {
                bool isCompleted = Convert.ToBoolean(selectedTask["check_task"]);
                if (isCompleted)
                {
                    MessageBox.Show("Невозможно редактировать отчет для выполненной задачи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int reportId = selectedTask["report_id"] != DBNull.Value ? Convert.ToInt32(selectedTask["report_id"]) : -1;
                if (reportId == -1)
                {
                    MessageBox.Show("К этой задаче не прикреплен отчет.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                /*var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Выберите новый отчет"
                };

                if (openFileDialog.ShowDialog() == true)
                {*/
                    //string filePath = openFileDialog.FileName;
                    string formattedDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                    try
                    {
                        reportTableAdapter reportAdapter = new reportTableAdapter();
                        reportAdapter.updateReport(
                            attachment.Text,
                            formattedDateTime,
                            description.Text,
                            reportId
                        );

                        MessageBox.Show("Отчет успешно обновлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка обновления отчета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                //}
            }
            else
            {
                MessageBox.Show("Выберите задачу для редактирования отчета.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void programmExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
