using RestoApp_Afonichev.Model;
using RestoApp_Afonichev.View.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestoApp_Afonichev.View.Pages
{
    /// <summary>
    /// Interaction logic for AddEditWaiters.xaml
    /// </summary>
    public partial class AddEditWaiters : Page
    {
        public AddEditWaiters()
        {
            InitializeComponent();
            EmployeeLv.ItemsSource = App.GetContext().Employee.ToList();
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.ShowDialog();
            EmployeeLv.ItemsSource = App.GetContext().Employee.ToList();
        }

        private void EditEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeeLv.SelectedItem == null)
            {
                MessageBox.Show("Выберите работника!");
            }
            else
            {
                AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(EmployeeLv.SelectedItem as Employee);
                addEmployeeWindow.ShowDialog();
                EmployeeLv.ItemsSource = App.GetContext().Employee.ToList();
                EmployeeLv.SelectedItem = null;
            }
        }

        private void DeleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeLv.SelectedItem == null)
            {
                MessageBox.Show("Выберите работника!");
            }
            else
            {
                if (MessageBox.Show("Вы точно хотите удалить этого пользователя?", "Запрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    App.GetContext().Employee.Remove(EmployeeLv.SelectedItem as Employee);
                    App.GetContext().SaveChanges();
                    EmployeeLv.ItemsSource = App.GetContext().Employee.ToList();
                    MessageBox.Show("Пользователь удален!");
                    EmployeeLv.SelectedItem = null;
                }
            }
        }
    }
}
