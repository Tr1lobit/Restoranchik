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
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public PaymentWindow()
        {
            InitializeComponent();
            ToPayTbl.Text = "К оплате: " + App.selectedCheque.TotalCost.ToString() + " ₽";
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            App.selectedCheque.IsClosed = true;
            App.selectedCheque.Table.IsFree = true;

            App.GetContext().SaveChanges();
            DialogResult = true;
            MessageBox.Show("Заказ успешно оплачен!");
            Close();
        }

        private void CreditTb_GotFocus(object sender, RoutedEventArgs e)
        {
            CreditTb.Text = App.selectedCheque.TotalCost.ToString();
        }

        private void CashTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeTbl.Text = GetChange();
        }

        private void CreditTb_LostFocus(object sender, RoutedEventArgs e)
        {
            CreditTb.Text = string.Empty;
        }

        private string GetChange()
        {
            if(CashTb.Text!=string.Empty)
            {
                decimal chequeCash = App.selectedCheque.TotalCost;
                decimal cash = decimal.Parse(CashTb.Text);
                return "Сдача: " + (cash - chequeCash).ToString() + " ₽";
            }
            return "0";
        }
    }
}
