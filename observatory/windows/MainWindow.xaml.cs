using observatory.code;
using observatory.observatoryDataSetTableAdapters;
using observatory.windows;
using System.Windows;
namespace observatory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        employeeTableAdapter employee = new employeeTableAdapter();
        bool account=false;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void authBtn_Click(object sender, RoutedEventArgs e)
        {
            var data = employee.GetData().Rows;
            for (int r = 0; r < data.Count; r++)
            {
                if (data[r][2].ToString() == authLogin.Text)
                {
                    account = true;
                    if (PasswordWork.CheckPassword(authPassword.Password, data[r][4].ToString(), data[r][3].ToString())
                        && authPassword.Password.Length >= 7)
                    {
                        
                        CurrentUser currentUser = new CurrentUser
                        {
                            Name = data[r][1].ToString(),
                            Department = data[r][6].ToString()
                        };
                        string role = data[r][5].ToString();
                        switch (role)
                        {
                            case "Старший научный сотрудник":
                                var senior_window = new SeniorScientistPanel();
                                senior_window.Show();
                                break;
                            case "Руководитель отдела":
                                var cheif_window = new CheifDepartmentPanel(currentUser);
                                cheif_window.Show();
                                break;
                            case "Научный сотрудник":
                                var science_window = new SciencePersonnelPanel(currentUser);
                                science_window.Show();
                                break;
                            case "Администратор БД":
                                var manager_window = new ManagerDB();
                                manager_window.Show();
                                break;
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно введён пароль.");
                    }
                }
            }
            if (!account)
            {
                MessageBox.Show("Аккаунта не существует.");
            }
        }
        
    }
}
