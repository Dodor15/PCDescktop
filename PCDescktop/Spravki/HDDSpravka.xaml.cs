using PSConstruct.DBClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PCDescktop.Spravki
{
    /// <summary>
    /// Логика взаимодействия для HDDSpravka.xaml
    /// </summary>
    public partial class HDDSpravka : Window
    {
        public DBHDD _CHDD = new DBHDD();
        public HDDSpravka(string HDD)
        {
            ConfigContext config = new ConfigContext();
            InitializeComponent();
            _CHDD = config.DBHDDs.Where(p => p.HDDName == HDD).First();
            DataContext = _CHDD;
        }
    }
}
