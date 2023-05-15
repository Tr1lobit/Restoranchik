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
using System.Windows.Shapes;

namespace RestoApp_Afonichev.View.Windows
{
    /// <summary>
    /// Interaction logic for AddTableWindow.xaml
    /// </summary>
    public partial class AddTableWindow : Window
    {
        bool IsChange = false;
        public AddTableWindow()
        {
            InitializeComponent();
        }

        public AddTableWindow(Table selectedTable)
        {
            InitializeComponent();
            DataContext = selectedTable;
            IsChange = true;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsChange == false)
            {
                Table newTable = new Table
                {
                    Title = TableTitleTb.Text,
                    NumberOfVisitors = Convert.ToInt32(TableNumberOfVisitorsTb.Text),
                    Description = TableDescriptionTb.Text
                };
                App.GetContext().Table.Add(newTable);
                App.GetContext().SaveChanges();
                MessageBox.Show("Стол добавлен!");
                Close();
            }
            else
            {
                App.GetContext().SaveChanges();
                MessageBox.Show("Стол изменен!");
                Close();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
