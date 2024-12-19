using observatory.observatoryDataSetTableAdapters;
using System;
using System.Data;
using System.Windows;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for TaskNotesWindow.xaml
    /// </summary>
    public partial class TaskNotesWindow : Window
    {
        noteTableAdapter noteAdapter = new noteTableAdapter();
        public TaskNotesWindow(int noteId)
        {
            InitializeComponent();
            LoadNoteDetails(noteId);
        }
        private void LoadNoteDetails(int noteId)
        {
            try
            {
                DataTable noteTable = noteAdapter.GetDataById(noteId);
                if (noteTable.Rows.Count > 0)
                {
                    DataRow note = noteTable.Rows[0];
                    noteIdText.Text = note["id_note"].ToString();
                    attachmentText.Text = note["attachment"].ToString();
                    uploadedText.Text = note["uploaded"].ToString();
                    descriptionText.Text = note["description"].ToString();
                    fioText.Text = note["fio"].ToString();
                }
                else
                {
                    MessageBox.Show("Заметка не найдена.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заметки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }
    }
}
