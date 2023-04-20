using Microsoft.EntityFrameworkCore;
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
using System.Xml.Linq;

namespace PCDescktop
{
    /// <summary>
    /// Логика взаимодействия для SavedConfigs.xaml
    /// </summary>
    public partial class SavedConfigs : Window
    {
        public List<Config> _C = new List<Config>();
        public SavedConfigs()
        {
            var context = new ConfigContext();
            _C = context.Configs
                .Include(c=>c.DBCPUs)
                .Include(c=>c.DBGPUs)
                .Include(c=>c.DBHDDs)
                .Include(c=>c.DBPowerUnits)
                .Include(c=>c.DBRAMs)
                .Include(c=>c.BDMotherBoards)
                .ToList();
            InitializeComponent();
            DataContext = this;
            listbox.ItemsSource = _C;
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* var objec = (Config)listbox.SelectedItem;
             var goToEdit = new CreateConfig(objec);
             goToEdit.ShowDialog();*/
            CreateConfig cc = new CreateConfig((Config)listbox.SelectedItem);
            cc.ShowDialog();
        }
    }
}
