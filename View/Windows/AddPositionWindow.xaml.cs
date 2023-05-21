using RestoApp_Afonichev.Model;
using RestoApp_Afonichev.View.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace RestoApp_Afonichev.View.Windows
{
    /// <summary>
    /// Interaction logic for AddPositionWindow.xaml
    /// </summary>
    public partial class AddPositionWindow : Window
    {
        private bool isEdit = false;
        List<Category> categories = new List<Category>();
        public AddPositionWindow()
        {
            InitializeComponent();
            categories = App.GetContext().Category.ToList();
            PositionTypeCmb.ItemsSource = categories;
        }

        public AddPositionWindow(object selectedItem)
        {
            InitializeComponent();
            categories = App.GetContext().Category.ToList();
            PositionTypeCmb.ItemsSource = categories;
            DataContext = selectedItem;
            isEdit = true;
        }

        private void NewPositionBtn_Click(object sender, RoutedEventArgs e)
        {
            if(isEdit)
            {
                App.GetContext().SaveChanges();
                MessageBox.Show("Позиция изменена!");
                Close();
            }
            else
            {
            Position newPosition = new Position
            {
                Title = PositionNameTb.Text,
                Cost = Convert.ToDecimal(PositionCostTb.Text),
                CategoryId = PositionTypeCmb.SelectedIndex
            };
            App.GetContext().Position.Add(newPosition);
            App.GetContext().SaveChanges();
            MessageBox.Show("Позиция создана");
            DialogResult = true;
            Close();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
