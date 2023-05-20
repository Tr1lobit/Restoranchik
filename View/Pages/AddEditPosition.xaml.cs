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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestoApp_Afonichev.View.Pages
{
    /// <summary>
    /// Interaction logic for AddEditPosition.xaml
    /// </summary>
    public partial class AddEditPosition : Page
    {
        List<Category> categories = new List<Category>();
        public AddEditPosition()
        {
            InitializeComponent();
            PositionLb.ItemsSource = App.GetContext().Position.ToList();
            categories = App.GetContext().Category.ToList();
            categories.Insert(0, new Category() { Title = "Все категории " });
            FilterCmb.ItemsSource = categories;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != string.Empty)
            {
                PositionLb.ItemsSource = App.GetContext().Position.Where(p => p.Title.Contains(SearchTb.Text)).ToList();
            }
            else
            {
                PositionLb.ItemsSource = App.GetContext().Position.ToList();
            }
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterCmb.SelectedIndex != 0)
            {
                PositionLb.ItemsSource = App.GetContext().Position.Where(p => p.Category.CategoryId == FilterCmb.SelectedIndex).ToList();
            }
            else
            {
                PositionLb.ItemsSource = App.GetContext().Position.ToList();
            }
        }
    }
}
