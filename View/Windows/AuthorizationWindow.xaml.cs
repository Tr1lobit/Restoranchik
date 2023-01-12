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
            (sender as Button).Content;
        }
    }
}
