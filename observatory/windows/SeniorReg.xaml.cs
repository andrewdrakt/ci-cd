using observatory.code;
using observatory.observatoryDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace observatory.windows
{
    public partial class SeniorReg : Page
    {
        employeeTableAdapter employee = new employeeTableAdapter();
        departmentTableAdapter department = new departmentTableAdapter();
        roleTableAdapter role = new roleTableAdapter();
        logsTableAdapter log = new logsTableAdapter();
        DateTime currentDateTime = DateTime.Now;
        CurrentUser currentUser = new CurrentUser();
        public SeniorReg()
        {
            InitializeComponent();
            var roleData = role.GetData().Rows;
            var departmentData = department.GetData().Rows;
            
            for(int r = 0; r < roleData.Count-1; r++)
            {
                roleBox.Items.Add(roleData[r][1]);
            }
            for (int r = 0; r < departmentData.Count; r++)
            {
                departmentBox.Items.Add(departmentData[r][1]);
            }
        }

        private void registrationBtn_Click(object sender, RoutedEventArgs e)
        {
            
            string formattedDateTime = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            List<string> arguments = PasswordWork.CreateHash(passwordInput.Password);
            bool IsValidEmail(string email)
            {
                var trimmedEmail = email.Trim();

                if (trimmedEmail.EndsWith("."))
                {
                    return false;
                }
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == trimmedEmail;
                }
                catch
                {
                    return false;
                }
            }
            if (roleBox.SelectedItem != null && departmentBox.SelectedItem != null 
                && nameInput.Text != null && loginInput.Text!=null 
                && passwordInput.Password!=null)
            {
                if (IsValidEmail(loginInput.Text)){
                    if (passwordInput.Password.Length >= 7 && nameInput.Text.Length >= 11) {
                        employee.addNewUser(nameInput.Text, loginInput.Text, arguments[0], arguments[1], 
                            roleBox.SelectedItem.ToString(), departmentBox.SelectedItem.ToString());
                        MessageBox.Show("Пользователь успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        log.createLog(formattedDateTime.ToString(), currentUser.Name,
                            "добавил(а)", "Сотрудник",nameInput.Text);
                    }else {
                        MessageBox.Show("Пароль должен быть больше 6 символов.");
                    }
                }else{
                    MessageBox.Show("Неверно введена почта или имя.");
                }
            }else {
                MessageBox.Show("Вы не выбрали значение.");
            }
        }
    }
}
