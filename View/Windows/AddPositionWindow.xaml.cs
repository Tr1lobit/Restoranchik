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
        List<Category> categories = new List<Category>();
        public AddPositionWindow()
        {
            InitializeComponent();
            categories = App.GetContext().Category.ToList();
            PositionTypeCmb.ItemsSource = categories;
        }

        private void NewPositionBtn_Click(object sender, RoutedEventArgs e)
        {
            Position newPosition = new Position
            {
                Title = PositionNameTb.Text,
                Cost = Convert.ToDecimal(PositionCostTb.Text),
                CategoryId = PositionTypeCmb.SelectedIndex+1
            };
            App.GetContext().Position.Add(newPosition);
            App.GetContext().SaveChanges();
            MessageBox.Show("Позиция создана");
            DialogResult = true;
            Close();
        }

        private void PositionNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
