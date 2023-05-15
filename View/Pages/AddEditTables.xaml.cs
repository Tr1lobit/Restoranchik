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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestoApp_Afonichev.View.Pages
{
    /// <summary>
    /// Interaction logic for AddEditTables.xaml
    /// </summary>
    public partial class AddEditTables : Page
    {
        public AddEditTables()
        {
            InitializeComponent();
            TableLv.ItemsSource = App.GetContext().Table.ToList();
        }
        private void AddTableBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTableWindow addTableWindow = new AddTableWindow();
            addTableWindow.ShowDialog();
            TableLv.ItemsSource = App.GetContext().Table.ToList();
        }
        private void EditTableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TableLv.SelectedItem == null)
            {
                MessageBox.Show("Выберите стол!");
            }
            else
            {
                AddTableWindow addTableWindow = new AddTableWindow(TableLv.SelectedItem as Table);
                addTableWindow.ShowDialog();
                TableLv.ItemsSource = App.GetContext().Table.ToList();
            }
        }

        private void DeleteTableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TableLv.SelectedItem == null)
            {
                MessageBox.Show("Выберите стол!");
            }
            else
            {
                if (MessageBox.Show("Вы точно хотите удалить этот стол?", "Запрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    App.GetContext().Table.Remove(TableLv.SelectedItem as Table);
                    App.GetContext().SaveChanges();
                    TableLv.ItemsSource = App.GetContext().Table.ToList();
                    MessageBox.Show("Стол удален!");
                    TableLv.SelectedItem = null;
                }
            }
        }

    }
}
