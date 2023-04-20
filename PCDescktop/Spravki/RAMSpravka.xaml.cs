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
    /// Логика взаимодействия для RAMSpravka.xaml
    /// </summary>
    public partial class RAMSpravka : Window
    {
        public DBRAM _CRAM = new DBRAM();
        public RAMSpravka(string RAM)
        {
            ConfigContext config = new ConfigContext();
            InitializeComponent();
            _CRAM = config.DBRAMs.Where(p => p.RAMName == RAM).First();
            DataContext = _CRAM;
        }
    }
}
