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
    /// Логика взаимодействия для CPUSpravka.xaml
    /// </summary>
    public partial class CPUSpravka : Window
    {
        public DBCPU _CCPU = new DBCPU();
        public CPUSpravka(string CPU)
        {
            ConfigContext config = new ConfigContext();
            InitializeComponent();
            _CCPU = config.DBCPUs.Where(p => p.CPUName == CPU).First();
            DataContext = _CCPU;
        }
    }
}
