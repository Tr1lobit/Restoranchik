using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RestoApp_Afonichev.Model;

namespace RestoApp_Afonichev
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static RestoDb_AfonichevEntities _context;

        public static RestoDb_AfonichevEntities GetContext()
        {
            if (_context == null)
            {
                _context = new RestoDb_AfonichevEntities();
            }
            return _context;
        }
    }
}
