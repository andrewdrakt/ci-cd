using Mysqlx.Notice;
using observatory.code;
using observatory.observatoryDataSetTableAdapters;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for SeniorTaskWatch.xaml
    /// </summary>
    public partial class SeniorTaskWatch : Page
    {
        taskTableAdapter task = new taskTableAdapter();
        logsTableAdapter log = new logsTableAdapter();
        TaskData taskData = new TaskData();
        DateTime currentDateTime = DateTime.Now;
        CurrentUser currentUser = new CurrentUser();
        private class TaskData
        {
            object[] _array;
            public object[] Array
            {
                get { return _array; }
                set { _array = value; }
            }
            byte check;
            public byte Check
            {
                get { return check; }
                set { check = value; }
            }
            public object[] getArray()
            {
                return _array;
            }
        }
        public SeniorTaskWatch()
        {
            InitializeComponent();
            for (int r = 1; r < 6; r++)
            {
                priorityBox.Items.Add(r);
            }
            try
            {
                if (task == null)
                {
                    throw new NullReferenceException("Объект task не инициализирован.");
                }
                tasksDG.ItemsSource = task.GetData();
            }
            catch (Exception ex)
            {
                if (NavigationService?.CanGoBack == true)
                {
                    NavigationService.GoBack();
                    MessageBox.Show("У вас нет ни одной задачи.");
                }
                else
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }



        private void editTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            object[] oldTaskData = taskData.getArray();
            string formattedDateTime = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            if (tasksDG.SelectedItem != null)
            {
                if (Convert.ToByte((tasksDG.SelectedItem as DataRowView).Row[8]) == 1 && isCompleted.IsChecked != true)
                {
                    MessageBox.Show("Вы не можете отменить выполненную задачу.");
                }
                else
                {
                    if (endDatePicker.SelectedDate != null &&
                            priorityBox.SelectedItem != null)
                    {
                        if (MessageBox.Show("Вы точно хотите изменить задачу?",
                "Изменить",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {

                            object id = (tasksDG.SelectedItem as DataRowView).Row[0];
                            object[] newTaskData;
                            newTaskData = new object[] { endDatePicker.SelectedDate, priorityBox.SelectedItem, attachmentUrl.Text, Convert.ToByte(isCompleted.IsChecked) };

                            task.updateTask(endDatePicker.SelectedDate.ToString(), priorityBox.SelectedIndex + 1, attachmentUrl.Text, taskData.Check, Convert.ToInt32(id));
                            tasksDG.ItemsSource = task.GetData();

                            for (int i = 0; i < oldTaskData.Length; i++)
                            {
                                if (!Equals(oldTaskData[i], newTaskData[i]))
                                {

                                    log.createLog(formattedDateTime.ToString(), currentUser.Name,
                                        "изменил(а)", "Сотрудник",
                                        $"{oldTaskData[i]} => {newTaskData[i]}");
                                }
                            }
                            MessageBox.Show("Задача успешно обновлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Изменение отменено.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Одно из полей является пустым");
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбрано поле для изменения.");
            }
        }
        private void tasksDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tasksDG.SelectedItem != null)
            {
                object[] array = { 
                //Convert.ToDateTime((tasksDG.SelectedItem as DataRowView).Row[4]),
                Convert.ToDateTime((tasksDG.SelectedItem as DataRowView).Row[5]),
                Convert.ToByte((tasksDG.SelectedItem as DataRowView).Row[6]),
                Convert.ToString((tasksDG.SelectedItem as DataRowView).Row[7]),
                Convert.ToByte((tasksDG.SelectedItem as DataRowView).Row[8])};
                taskData.Array = array;
                //startDatePicker.SelectedDate = Convert.ToDateTime((tasksDG.SelectedItem as DataRowView).Row[4]);

                priorityBox.SelectedItem = Convert.ToInt32((tasksDG.SelectedItem as DataRowView).Row[6]);
                attachmentUrl.Text = Convert.ToString((tasksDG.SelectedItem as DataRowView).Row[7]);
                endDatePicker.SelectedDate = Convert.ToDateTime((tasksDG.SelectedItem as DataRowView).Row[5]);
                if (Convert.ToInt16((tasksDG.SelectedItem as DataRowView).Row[8]) == 0)
                {
                    isCompleted.IsChecked = false;
                }
                else
                {
                    isCompleted.IsChecked = true;
                }
            }
        }
        private void isCompleted_Checked(object sender, RoutedEventArgs e)
        {
            taskData.Check = 1;
        }

        private void isCompleted_Unchecked(object sender, RoutedEventArgs e)
        {
            taskData.Check = 0;
        }
        /* private void startDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
         {
             if (startDatePicker.SelectedDate != null)
             {
                 endDatePicker.DisplayDateStart = startDatePicker.SelectedDate.Value.AddDays(1);
             }
             else
             {
                 endDatePicker.DisplayDateStart = null;
             }
         }*/
        private void endDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tasksDG.SelectedItem != null)
            {
                if (endDatePicker.SelectedDate != null)
                {
                    if (tasksDG.SelectedItem is DataRowView selectedRow)
                    {
                        DateTime? minDate = Convert.ToDateTime((tasksDG.SelectedItem as DataRowView).Row[4]) as DateTime?;

                        if (minDate.HasValue)
                        {
                            endDatePicker.DisplayDateStart = minDate.Value;

                            if (endDatePicker.SelectedDate < minDate.Value)
                            {
                                MessageBox.Show($"Дата не может быть раньше {minDate.Value:dd.MM.yyyy}");
                                endDatePicker.SelectedDate = minDate.Value;
                            }
                        }
                    }
                }
                else
                {
                    endDatePicker.DisplayDateStart = null;
                }
            }
        }

        private void viewAllNotes_Click(object sender, RoutedEventArgs e)
        {
            if (tasksDG.SelectedItem is DataRowView selectedTask)
            {
                int taskId = Convert.ToInt32(selectedTask["id_task"]);

                var notes = GetNotesByTaskId(taskId);

                if (notes.Rows.Count > 0)
                {
                    var notesWindow = new NotesWindow(notes);
                    notesWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Для этой задачи отсутствуют заметки.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для просмотра заметок.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private DataTable GetNotesByTaskId(int taskId)
        {
            using (var connection = new SqlConnection("Server=LEGION;Database=observatory;Integrated Security=True;"))
            {
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
        private void viewReport_Click(object sender, RoutedEventArgs e)
        {
            if (tasksDG.SelectedItem is DataRowView selectedTask)
            {
                if (selectedTask["report_id"] != DBNull.Value)
                {
                    int reportId = Convert.ToInt32(selectedTask["report_id"]);
                    if (reportId > 0)
                    {
                        var reportData = GetReportById(reportId);

                        if (reportData != null)
                        {
                            var reportWindow = new ReportWindow(reportData);
                            reportWindow.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Отчет для этой задачи отсутствует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Для этой задачи не привязан отчет.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Для этой задачи отсутствует информация об отчете.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private DataRow GetReportById(int reportId)
        {
            using (var connection = new SqlConnection("YourConnectionString"))
            {
                string query = "SELECT * FROM report WHERE id_report = @ReportId";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReportId", reportId);

                var adapter = new SqlDataAdapter(command);
                var reportTable = new DataTable();
                adapter.Fill(reportTable);

                if (reportTable.Rows.Count > 0)
                {
                    return reportTable.Rows[0];
                }
                return null;
            }
        }
    }
}
