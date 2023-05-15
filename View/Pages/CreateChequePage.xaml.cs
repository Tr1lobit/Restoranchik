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
    /// Логика взаимодействия для CreateChequePage.xaml
    /// </summary>
    public partial class CreateChequePage : Page
    {
        decimal TotalCost;
        List<Category> categories = new List<Category>();
        public CreateChequePage()
        {
            InitializeComponent();
            PositionLb.ItemsSource = App.GetContext().Position.ToList();
            categories = App.GetContext().Category.ToList();
            categories.Insert(0, new Category() { Title = "Все категории " });
            FilterCmb.ItemsSource = categories;

            TableTbl.DataContext = App.selectedTable;

            DateTbl.Text ="Открыт: "+ DateTime.Now.ToString();
        }

        private void PositionLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedPosition = PositionLb.SelectedItem as Position;
            if(App.selectedPosition != null)
            {
                PositionsLv.Items.Add(App.selectedPosition);

                TotalCostLb.Text = GetTotalCost();
            }
            //Сбрасывает выделение с элемента
            PositionLb.SelectedIndex = -1;

        }

        private void PositionsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PositionsLv.Items.Remove(PositionsLv.SelectedItem as Position);
            TotalCostLb.Text = GetTotalCost();

        }

        private void CreateChequeBtn_Click(object sender, RoutedEventArgs e)
        {
            //Создаем объект
            Cheque newCheque = new Cheque
            //С помощью инициализаторов заполняем свойство
            {
                Title = GenerateChequeNumber(),
                TotalCost = TotalCost,
                IsClosed = false,
                OpeningDate = DateTime.Now,
                EmployeeId = App.enteredEmployee.EmployeeId,
                TableId = App.selectedTable.TableId
            };

            foreach (Table table in App.GetContext().Table.ToList())
                if (table.Equals(App.selectedTable))
                {
                    table.IsFree = false;
                }
            //Добавить объект в контекстную таблицу
            App.GetContext().Cheque.Add(newCheque);
            //Сохранить изменения в контексте (запись добавляется в БД)
            App.GetContext().SaveChanges();
            MessageBox.Show("Чек успешно создан!");
            NavigationService.Navigate(new ChequePage());



            foreach (Position position in PositionsLv.Items)
            {
                ChequePosition chequePosition = new ChequePosition
                {
                    ChequeId = newCheque.ChequeId,
                    PositionId = position.PositionId,
                };
                App.GetContext().ChequePosition.Add(chequePosition);
                App.GetContext().SaveChanges();
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SearchTb.Text != string.Empty)
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
            if(FilterCmb.SelectedIndex!=0)
            {
                PositionLb.ItemsSource = App.GetContext().Position.Where(p => p.Category.CategoryId == FilterCmb.SelectedIndex).ToList();
            }
            else
            {
                PositionLb.ItemsSource = App.GetContext().Position.ToList();
            }
        }

        private string GetTotalCost()
        {
            TotalCost = 0;
            foreach (Position position in PositionsLv.Items)
            {
                TotalCost += position.Cost;
            }

            return "К оплате: " + TotalCost + " ₽";
        }

        private void NewPositionBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPositionWindow addPositionWindow = new AddPositionWindow();
            addPositionWindow.ShowDialog();
        }

        private string GenerateChequeNumber()
        {
            DateTime current = DateTime.Now;
            return $"Чек №{current.Day}{current.Month}{current.Year}-{current.Hour}{current.Minute}";
        }
    }
}
