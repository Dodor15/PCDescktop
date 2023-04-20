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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCDescktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoMainWindow_Click(object sender, RoutedEventArgs e)
        {
            CreateConfig cc = new CreateConfig();
            cc.ShowDialog();
        }

        private void GoCheckConfig_Click(object sender, RoutedEventArgs e)
        {
            SavedConfigs sc = new SavedConfigs();
            sc.ShowDialog();
        }

        private void Developer_Click(object sender, RoutedEventArgs e)
        {
            Pars p = new Pars();
            p.ShowDialog();
        }
    }
}
