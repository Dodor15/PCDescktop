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
    /// Логика взаимодействия для MBSpravka.xaml
    /// </summary>
    public partial class MBSpravka : Window
    {
        public BDMotherBoard _CMB = new BDMotherBoard();
        public MBSpravka(string MB)
        {
            
            ConfigContext config = new ConfigContext();
            InitializeComponent();
            _CMB = config.BDMotherBoards.Where(p => p.MDName == MB).First();
            //mot.Content = _MB.MDName.ToString();
            DataContext = _CMB;
        }
    }
}
