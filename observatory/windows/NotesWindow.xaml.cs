using System;
using System.Data;
using System.Linq;
using System.Windows;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow(DataTable notes)
        {
            InitializeComponent();
            NotesList.ItemsSource = notes.AsEnumerable().Select(row => new
            {
                description = row["description"].ToString(),
                attachment = row["attachment"] != DBNull.Value ? row["attachment"].ToString() : "Нет вложения",
                uploaded = row["uploaded"].ToString(),
                fio = row["fio"].ToString()
            });
        }
    }
}
