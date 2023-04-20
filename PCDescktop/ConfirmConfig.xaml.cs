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

namespace PCDescktop
{
    /// <summary>
    /// Логика взаимодействия для ConfirmConfig.xaml
    /// </summary>
    public partial class ConfirmConfig : Window
    {
        public Config conf { get; set; }
        bool who1 { get; set; }
        public ConfirmConfig(Config c, bool who)
        {
            InitializeComponent();
            who1 = who;
            conf = c;
            NameConfig.Text = conf.ConfigName;
            
        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            if (who1)
            {


                if (NameConfig.Text != string.Empty)
                {
                    conf.ConfigName = NameConfig.Text;
                    var contex = new ConfigContext();
                    contex.Attach(conf.BDMotherBoards);
                    contex.Attach(conf.DBCPUs);
                    contex.Attach(conf.DBGPUs);
                    contex.Attach(conf.DBHDDs);
                    contex.Attach(conf.DBRAMs);
                    contex.Attach(conf.DBPowerUnits);
                    contex.Configs.Add(conf);
                    try
                    {
                        contex.SaveChanges();
                        MessageBox.Show("Сохраненно");
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Не сохраненно");
                    }
                }
                else { MessageBox.Show("Добавте название"); }
            }
            else
            {
                if (NameConfig.Text != string.Empty)
                {
                    conf.ConfigName = NameConfig.Text;
                    var contex = new ConfigContext();
                    /*contex.Attach(conf.BDMotherBoards);
                    contex.Attach(conf.DBCPUs);
                    contex.Attach(conf.DBGPUs);
                    contex.Attach(conf.DBHDDs);
                    contex.Attach(conf.DBRAMs);
                    contex.Attach(conf.DBPowerUnits);*/
                    contex.Configs.Update(conf);
                    try
                    {
                        contex.SaveChanges();
                        MessageBox.Show("Сохраненно");
                        Close();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Не сохраненно");
                    }
                }
            }
        }

        private void NameConfig_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
