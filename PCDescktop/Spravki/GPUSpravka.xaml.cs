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
    /// Логика взаимодействия для GPUSpravka.xaml
    /// </summary>
    public partial class GPUSpravka : Window
    {
        public DBGPU _CGPU = new DBGPU();
        public GPUSpravka(string GPU)
        {
            ConfigContext config = new ConfigContext();
            InitializeComponent();
            _CGPU = config.DBGPUs.Where(p => p.GPUName == GPU).First();
            DataContext = _CGPU;
        }
    }
}
