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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void PincodeBtn_Click(object sender, RoutedEventArgs e)
        {
            // sender - это объект
            // Хранит внутри себя объект, который откликнулся на событие
            // Чтобы работать с sender'ом его нужно привести к конкретному типу (тип объекта который откликнулся на событие)

            // Приводим тип Object к типу Button
            // Складываем значение из свойства Password с Content'ом из кнопки
            //Присваиваем обновленное значение
            PincodePb.Password += (sender as Button).Content.ToString();

            if (PincodePb.Password.Length==4)
            {
                Employee employee = App.GetContext().Employee.FirstOrDefault(w => PincodePb.Password == w.Pincode);

                if (employee != null)
                {
                    if(employee.RoleId == 0)
                    {
                        App.enteredEmployee = employee;
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Close();
                    }
                    else
                    {
                        App.enteredEmployee = employee;
                        AdminMainWindow adminMainWindow = new AdminMainWindow();
                        adminMainWindow.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный PIN-код!");
                    PincodePb.Clear();
                }
            }
        }

        private void DeletePincodeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PincodePb.Password.Length > 0)
            {
                // Удаление символов с конца
                PincodePb.Password = PincodePb.Password.Remove(PincodePb.Password.Length - 1);
            }
        }
    }
}
