using PSConstruct.DBClasses;
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

namespace PCDescktop.Spravki
{
    /// <summary>
    /// Логика взаимодействия для PWSpravka.xaml
    /// </summary>
    public partial class PWSpravka : Window
    {
        public DBPowerUnit _CPW = new DBPowerUnit();
        public PWSpravka( string PW)
        {
            ConfigContext context = new ConfigContext();
            InitializeComponent();
            _CPW = context.DBPowerUnits.Where(p => p.PowerUnitName == PW).First();
            DataContext = _CPW;
        }
    }
}
