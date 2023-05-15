using RestoApp_Afonichev.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestoApp_Afonichev.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChequePage.xaml
    /// </summary>
    public partial class ChequePage : Page
    {
        public ChequePage()
        {
            InitializeComponent();

            //Передача таблицы со столами в список
            TablesLb.ItemsSource = App.GetContext().Table.ToList();
            OpenChequesLb.ItemsSource = App.GetContext().Cheque.Where(c=> c.IsClosed == false).ToList();
        }

        private void TablesLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedTable = TablesLb.SelectedItem as Table;

            if(App.selectedTable.IsFree == true)
            {
                NavigationService.Navigate(new CreateChequePage());
            }
            else
            {
                MessageBox.Show("Стол уже занят!");
            }

            
        }

        private void OpenChequesLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedCheque = OpenChequesLb.SelectedItem as Cheque;

            if(App.enteredEmployee.EmployeeId == App.selectedCheque.Employee.EmployeeId)
            {
                NavigationService.Navigate(new EditChequePage());
            }
            else
            {
                MessageBox.Show("Вы можете редактировать только свои чеки!");
            }

            
        }
    }
}
