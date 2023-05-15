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
    /// Interaction logic for EditChequePage.xaml
    /// </summary>
    public partial class EditChequePage : Page
    {
        //Итоговая цена
        private decimal totalCost;


        private List<Category> categories;
        private List<Position> positions;
        public EditChequePage()
        {
            InitializeComponent();

            totalCost = App.selectedCheque.TotalCost;

            TotalCostTbl.Text = GetTotalCost(PositionsLv);

            //Добавление информации о столе и времени
            TableTbl.Text = App.selectedCheque.Table.Title;
            DateTbl.Text = "Открыт: " + App.selectedCheque.OpeningDate;

            //Добавление позиций в ListBox
            EarlierPositionsLv.ItemsSource = App.GetContext().ChequePosition.Where(cp => cp.ChequeId == App.selectedCheque.ChequeId).ToList();

            //Добавление категорий в Combobox
            categories = App.GetContext().Category.ToList();
            categories.Insert(0, new Category { Title = "Все категории" });
            CategoryCmb.ItemsSource = categories;
            CategoryCmb.SelectedValuePath = "CategoryId";
            CategoryCmb.DisplayMemberPath = "Title";
            CategoryCmb.SelectedIndex = 0;
        }


        private void CategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            positions = App.GetContext().Position.ToList();

            if(CategoryCmb.SelectedIndex != 0)
            {
                positions = positions.Where(p => p.Category.CategoryId == CategoryCmb.SelectedIndex).ToList();
                PositionLb.ItemsSource = positions;
            }
            else
            {
                PositionLb.ItemsSource = positions;
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            positions = App.GetContext().Position.ToList();

            if(SearchTb.Text != String.Empty)
            {
                if(SearchTb.Text != "Поиск по названию")
                {
                    positions = positions.Where(p => p.Title.ToLower().Contains(SearchTb.Text.ToLower())).ToList();
                    PositionLb.ItemsSource = positions;
                }
                else
                {
                    PositionLb.ItemsSource = positions;
                }
            }
        }

        private void PositionLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedPosition = PositionLb.SelectedItem as Position;
            if (App.selectedPosition != null)
            {
                PositionsLv.Items.Add(App.selectedPosition);
                TotalCostTbl.Text = GetTotalCost(PositionsLv);
            }
            PositionLb.SelectedIndex = -1;
        }

        private void PositionsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PositionsLv.Items.Remove((sender as ListView).SelectedItem as Position);
            TotalCostTbl.Text = GetTotalCost(PositionsLv);
        }

        private void EditChequeBtn_Click(object sender, RoutedEventArgs e)
        {
            App.selectedCheque.TotalCost = totalCost;

            foreach (Position position in PositionsLv.Items)
            {
                ChequePosition chequePosition = new ChequePosition()
                {
                    ChequeId = App.selectedCheque.ChequeId,
                    PositionId = position.PositionId
                };

                App.GetContext().ChequePosition.Add(chequePosition);
                App.GetContext().SaveChanges();

            }
            MessageBox.Show("Новые позиции добавлены в чек");
            NavigationService.GoBack();
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            PaymentWindow paymentWindow = new PaymentWindow();
            paymentWindow.ShowDialog();

            if (paymentWindow.DialogResult == true)
            {
                NavigationService.Navigate(new ChequePage());
            }
        }

        private string GetTotalCost(ListView positionsLv)
        {
            totalCost = App.selectedCheque.TotalCost;

            foreach (Position position in PositionsLv.Items)
            {
                totalCost += position.Cost;
            }

            return "К оплате: " + totalCost.ToString() + " ₽";
        }
    }
}
