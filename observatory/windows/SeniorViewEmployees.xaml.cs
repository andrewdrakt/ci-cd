using observatory.code;
using observatory.observatoryDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace observatory.windows
{
    /// <summary>
    /// Interaction logic for SeniorViewEmployees.xaml
    /// </summary>
    public partial class SeniorViewEmployees : Page
    {
        employeeTableAdapter employee = new employeeTableAdapter();
        logsTableAdapter log = new logsTableAdapter();
        departmentTableAdapter department = new departmentTableAdapter();
        roleTableAdapter role = new roleTableAdapter();
        EmployeeData employeeData = new EmployeeData();
        CurrentUser currentUser = new CurrentUser();
        DateTime utcNow = DateTime.UtcNow;
        private class EmployeeData
        {
            private object[] _array;
            public object[] Array
            {
                get { return _array; }
                set { _array = value; }
            }
        }
        public SeniorViewEmployees()
        {
            InitializeComponent();
            employeesDG.ItemsSource = employee.GetData();
            var roleData = role.GetData().Rows;
            var departmentData = department.GetData().Rows;
            for (int r = 0; r < roleData.Count - 1; r++)
            {
                roleBox.Items.Add(roleData[r][1]);
            }
            for (int r = 0; r < departmentData.Count; r++)
            {
                departmentBox.Items.Add(departmentData[r][1]);
            }
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            object[] oldEmployeeData = employeeData.Array;
            
            TimeZoneInfo moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
            DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, moscowTimeZone);
            
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

            if (employeesDG.SelectedItem != null)
            {
                if (departmentBox.SelectedItem != null || roleBox.SelectedItem != null || fio.Text != null || login.Text != null)
                {
                    if (IsValidEmail(login.Text))
                    {
                        if (fio.Text.Length >= 11 && fio.Text.Length < 60 && login.Text.Length > 5 && login.Text.Length < 35)
                        {

                            if (MessageBox.Show("Вы точно хотите изменить пользователя?",
                    "Изменить",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                            {
                                object id = (employeesDG.SelectedItem as DataRowView).Row[0];
                                List<string> arguments = PasswordWork.CreateHash(password.Password);
                                if (passwordAllowed.IsChecked == false)
                                {
                                    employee.nonPassUpdateUser(fio.Text, login.Text, roleBox.SelectedItem.ToString(), departmentBox.SelectedItem.ToString(), Convert.ToInt32(id));
                                }
                                else if (password.Password.Length < 20 && password.Password.Length >= 7 && passwordAllowed.IsChecked == true)
                                {

                                    employee.updateUser(fio.Text, login.Text, arguments[0], arguments[1], roleBox.SelectedItem.ToString(), departmentBox.SelectedItem.ToString(), Convert.ToInt32(id));
                                }
                                else
                                {
                                    goto Next;
                                }

                                object[] newEmployeeData;

                                if (passwordAllowed.IsChecked == false)
                                {
                                    newEmployeeData = new object[] { fio.Text, login.Text, (employeesDG.SelectedItem as DataRowView).Row[3], (employeesDG.SelectedItem as DataRowView).Row[4], roleBox.SelectedItem.ToString(), departmentBox.SelectedItem.ToString() };
                                }
                                else
                                {
                                    newEmployeeData = new object[] { fio.Text, login.Text, arguments[0], arguments[1], roleBox.SelectedItem.ToString(), departmentBox.SelectedItem.ToString() };
                                }
                                employeesDG.ItemsSource = employee.GetData();

                                for (int i = 0; i < oldEmployeeData.Length; i++)
                                {
                                    if (!Equals(oldEmployeeData[i], newEmployeeData[i]))
                                    {

                                        log.createLog(moscowTime.ToString(), currentUser.Name,
                                            "изменил(а)", "Сотрудник",
                                            $"{oldEmployeeData[i]} => {newEmployeeData[i]}");
                                    }
                                }
                                MessageBox.Show("Пользователь успешно обновлён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            Next:
                                employeesDG.ItemsSource = employee.GetData();
                            }
                            else
                            {
                                MessageBox.Show("Изменение отменено.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверный размер строки.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введена неверная почта.");
                    }
                }
                else
                {
                    MessageBox.Show("В одной из строк не введены данные.");
                }
            }
            else
            {
                MessageBox.Show("Не выбрано поле для изменения.");
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            TimeZoneInfo moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
            DateTime moscowTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, moscowTimeZone);
            if (employeesDG.SelectedItem != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить пользователя?",
                    "Изменить",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    object id = (employeesDG.SelectedItem as DataRowView).Row[0];
                    employee.deleteUser(Convert.ToInt32(id));
                    MessageBox.Show("Пользователь успешно удалён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    log.createLog(moscowTime.ToString(),currentUser.Name,
                        "удалил(а)","Сотрудники",$"{id} {(employeesDG.SelectedItem as DataRowView).Row[1]}");
                }
                else
                {
                    MessageBox.Show("Изменение отменено.");
                }
            }
            else
            {
                MessageBox.Show("Не выбрано поле для изменения.");
            }
        }

        private void employeesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (employeesDG.SelectedItem != null)
            {
                object[] array = { Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[1]),
                Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[2]),
                Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[3]),
                Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[4]),
                Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[5]),
                Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[6])};
                employeeData.Array = array;
                fio.Text = Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[1]);
                login.Text = Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[2]);
                roleBox.SelectedItem = Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[5]);
                departmentBox.SelectedItem = Convert.ToString((employeesDG.SelectedItem as DataRowView).Row[6]);
            }
        }

        private void passwordAllowed_Checked(object sender, RoutedEventArgs e)
        {
            password.IsEnabled = true;
        }

        private void passwordAllowed_Unchecked(object sender, RoutedEventArgs e)
        {
            password.IsEnabled = false;
        }
    }
}
