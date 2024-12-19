using Microsoft.Win32;
using observatory.code;
using System;
using System.IO;
using System.Windows;
namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for ManagerDB.xaml
    /// </summary>
    public partial class ManagerDB : Window
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        private readonly string connectionString = "Server=LEGION;Database=observatory;Integrated Security=True;";
        public ManagerDB()
        {
            InitializeComponent();
            pageFrame.Content = new ManagerLogsView();
        }
        private void fileSavePathBtn_Click(object sender, RoutedEventArgs e)
        {
            /* using (var folderDialog = new FolderBrowserDialog())
             {
                 folderDialog.Description = "Выберите папку для сохранения CSV файлов";

                 if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 {
                     string folderPath = folderDialog.SelectedPath;

                     dbHelper.ExportTablesToCsvFiles(connectionString, folderPath);

                     System.Windows.MessageBox.Show("Экспорт завершен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                 }
             }*/
            var dialog = new OpenFileDialog
            {
                Title = "Выберите любой файл в папке, куда хотите экспортировать данные",
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Select Folder"
            };

            if (dialog.ShowDialog() == true)
            {
                string folderPath = Path.GetDirectoryName(dialog.FileName);
                dbHelper.ExportTablesToCsvFiles(connectionString, folderPath);

                MessageBox.Show("Экспорт завершен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void restoreDBBtn_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "SQL Backup Files (*.bak)|*.bak|All Files (*.*)|*.*",
                Title = "Выберите файл резервной копии"
            };

            if (openDialog.ShowDialog() == true)
            {
                string restoreFilePath = openDialog.FileName;

                dbHelper.RestoreDatabase(restoreFilePath);

                MessageBox.Show("База данных восстановлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void fileCopyPathBtn_Click(object sender, RoutedEventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "SQL Backup Files (*.bak)|*.bak|All Files (*.*)|*.*",
                Title = "Выберите файл для сохранения резервной копии",
                FileName = "observatory_backup.bak"
            };
            if (saveDialog.ShowDialog() == true)
            {
                try
                {
                    string backupFilePath = saveDialog.FileName;
                    dbHelper.BackupDatabase(backupFilePath);
                    MessageBox.Show(
                        "Резервная копия успешно создана по адресу:\n" + backupFilePath,
                        "Успех",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Произошла ошибка при создании резервной копии:\n" + ex.Message,
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
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
