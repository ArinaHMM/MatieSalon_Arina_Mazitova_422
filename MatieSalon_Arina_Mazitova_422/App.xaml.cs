using MatieSalon_Arina_Mazitova_422.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MatieSalon_Arina_Mazitova_422
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MatieSalonEntities1 db = new MatieSalonEntities1();
        public static Users CurrentUser { get; set; }
    }
}
