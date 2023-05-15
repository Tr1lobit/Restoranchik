using RestoApp_Afonichev.Model;
using System;
using System.Collections.Generic;
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

namespace RestoApp_Afonichev.View.Windows
{
    /// <summary>
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        bool IsChange = false;
        public AddEmployeeWindow()
        {
            InitializeComponent();
            EmployeeRoleCmb.ItemsSource = App.GetContext().Role.ToList();
        }

        public AddEmployeeWindow(Employee selectedEmployee)
        {
            InitializeComponent();
            EmployeeRoleCmb.ItemsSource = App.GetContext().Role.ToList();
            DataContext = selectedEmployee;
            IsChange = true;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(IsChange==false)
            {
                Employee newEmployee = new Employee
                {
                    Name = EmpoyeeNameTb.Text,
                    Pincode = EmpoyeePincodeTb.Text,
                    RoleId = EmployeeRoleCmb.SelectedIndex
                };
                App.GetContext().Employee.Add(newEmployee);
                App.GetContext().SaveChanges();
                MessageBox.Show("Сотрудник добавлен!");
                Close();
            }
            else
            {
                App.GetContext().SaveChanges();
                MessageBox.Show("Сотрудник изменен!");
                Close();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
