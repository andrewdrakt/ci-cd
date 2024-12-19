using observatory.code;
using observatory.observatoryDataSetTableAdapters;
using System;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for SciencePersonnelPanel.xaml
    /// </summary>
    public partial class SciencePersonnelPanel : Window
    {
        taskTableAdapter task = new taskTableAdapter();
        noteTableAdapter note = new noteTableAdapter();
        logsTableAdapter log = new logsTableAdapter();
        private CurrentUser currentUser;
        public SciencePersonnelPanel(CurrentUser user)
        {
            InitializeComponent();
            currentUser = user;
            /*DataTable tasks = task.GetTasksByDepartment(currentUser.Department);
            taskDG.ItemsSource = tasks.DefaultView;*/
            if (currentUser == null || string.IsNullOrEmpty(currentUser.Department))
            {
                MessageBox.Show("Ошибка: текущий пользователь или его отдел не определены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }
            LoadTasks();
        }
        private void LoadTasks()
        {
            try
            {
                DataTable tasks = task.GetPendingTasksByDepartment(currentUser.Department);
                if (tasks.Rows.Count > 0)
                {
                    taskDG.ItemsSource = tasks.DefaultView;
                }
                else
                {
                    MessageBox.Show("Нет невыполненных задач для вашего отдела.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке задач: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void taskDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (taskDG.SelectedItem != null)
            {
                DataRowView selectedTask = taskDG.SelectedItem as DataRowView;
                if (selectedTask != null)
                {
                    int taskId = Convert.ToInt32(selectedTask["id_task"]);
                    LoadNotes(taskId);
                }
            }
        }
        private void LoadNotes(int taskId)
        {
            try
            {
                DataTable notes = note.GetNotesByTaskId(taskId);
                if (notes.Rows.Count > 0)
                {
                    notesDG.ItemsSource = notes.DefaultView;
                }
                else
                {
                    notesDG.ItemsSource = null;
                    MessageBox.Show("Нет заметок для выбранной задачи.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заметок: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void taskDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (taskDG.SelectedItem != null)
            {
                DataRowView selectedTask = taskDG.SelectedItem as DataRowView;
                if (selectedTask != null)
                {
                    int taskId = Convert.ToInt32(selectedTask["id_task"]);
                    TaskNotesWindow notesWindow = new TaskNotesWindow(taskId);
                    notesWindow.ShowDialog();
                }
            }
        }
        private void addNote_Click(object sender, RoutedEventArgs e)
        {
            if (taskDG.SelectedItem != null)
            {
                DataRowView selectedTask = taskDG.SelectedItem as DataRowView;
                if (selectedTask != null)
                {
                    string formattedDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                    if (!string.IsNullOrEmpty(description.Text.Trim()))
                    {
                        try
                        {
                            int taskId = Convert.ToInt32(selectedTask["id_task"]);

                            int newNoteId = note.addNote(
                                description.Text.Trim(),
                                attachmentUrl.Text.Trim(),
                                formattedDateTime,
                                currentUser.Name,
                                taskId
                            );

                            MessageBox.Show("Заметка успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                            log.createLog(formattedDateTime, currentUser.Name, "добавил(а)", "Заметку", $"{newNoteId}");

                            LoadNotes(taskId);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при добавлении заметки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Описание заметки не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка выбора задачи. Попробуйте ещё раз.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для добавления заметки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void notesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewNoteButton.IsEnabled = notesDG.SelectedItem != null;
        }

        private void viewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            if (notesDG.SelectedItem != null)
            {
                DataRowView selectedNote = notesDG.SelectedItem as DataRowView;
                if (selectedNote != null)
                {
                    int noteId = Convert.ToInt32(selectedNote["id_note"]);
                    TaskNotesWindow notesWindow = new TaskNotesWindow(noteId);
                    notesWindow.Owner = this;
                    notesWindow.ShowDialog();
                }
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