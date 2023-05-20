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
    /// Interaction logic for AdminCategoriesPage.xaml
    /// </summary>
    public partial class AdminCategoriesPage : Page
    {
        public AdminCategoriesPage()
        {
            InitializeComponent();
        }

        private void EployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditWaiters());
        }

        private void TableBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditTables());
        }

        private void PositionBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPosition());
        }
    }
}
