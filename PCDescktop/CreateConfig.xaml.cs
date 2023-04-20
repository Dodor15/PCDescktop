using Microsoft.EntityFrameworkCore;
using PCDescktop.Spravki;
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
    /// Логика взаимодействия для CreateConfig.xaml
    /// </summary>
    public partial class CreateConfig : Window
    {
        string CPU = string.Empty;
        string RAM = string.Empty;
        string GPU = string.Empty;
        public Config _C = new Config();
        int ind = 0;
        bool pw = true;

        public CreateConfig(Config config)
        {
            InitializeComponent();
            // Application.Current.MainWindow.Visibility = Visibility.Collapsed;
            //Выключаем при инициализации когда пустые комбобоксы
            _C = config;
            using (var context = new ConfigContext())
            {
                MBComboBox.ItemsSource = context.BDMotherBoards
                    .ToList();
                HDDComboBox.ItemsSource = context.DBHDDs
                    .ToList();

                pw = false;
                //Заполнение комюбобоксов при изменении

                MBComboBox.SelectedItem = context.BDMotherBoards.FirstOrDefault(c => c.BDMotherBoardId == _C.BDMotherBoards.BDMotherBoardId);

                CPU = context.BDMotherBoards.Where(n => n.MDName == _C.BDMotherBoards.MDName).Select(p => p.CPUsocket).First();
                CPUComboBox.ItemsSource = context.DBCPUs.Where(s => s.CPUsocket == CPU).ToList();
                GPU = context.BDMotherBoards.Where(n => n.MDName == _C.BDMotherBoards.MDName).Select(p => p.GPUsocket).First();
                GPUComboBox.ItemsSource = context.DBGPUs.Where(s => s.GPUsocket == GPU).ToList();
                RAM = context.BDMotherBoards.Where(n => n.MDName == _C.BDMotherBoards.MDName).Select(p => p.RAMsocket).First();
                RAMComboBox.ItemsSource = context.DBRAMs.Where(s => s.RAMsocket == RAM).ToList();


                CPUComboBox.SelectedItem = context.DBCPUs.FirstOrDefault(c => c.DBCPUId == _C.DBCPUs.DBCPUId);
                RAMComboBox.SelectedItem = context.DBRAMs.FirstOrDefault(c => c.DBRAMId == _C.DBRAMs.DBRAMId);
                GPUComboBox.SelectedItem = context.DBGPUs.FirstOrDefault(c => c.DBGPUId == _C.DBGPUs.DBGPUId);
                HDDComboBox.SelectedItem = context.DBHDDs.FirstOrDefault(c => c.DBHDDId == _C.DBHDDs.DBHDDId);
                CheckPW(pw);

                int count = 0;
                count += context.DBGPUs.Where(p => p.GPUName == _C.DBGPUs.GPUName).Select(p => p.PowerEat).First();
                count += context.DBCPUs.Where(p => p.CPUName == _C.DBCPUs.CPUName).Select(p => p.PowerEat).First();
                count += context.DBHDDs.Where(p => p.HDDName == _C.DBHDDs.HDDName).Select(p => p.HDDPowerEat).First();
                PWComboBox.ItemsSource = context.DBPowerUnits
                            .Where(p => p.Power > count).ToList();
                PWComboBox.SelectedItem = context.DBPowerUnits.FirstOrDefault(c => c.DBPowerUnitId == _C.DBPowerUnits.DBPowerUnitId);
                Save.Content = "Изменить";
               // MessageBox.Show(A.PowerUnitName);

            }
            DataContext = _C;

        }
        public CreateConfig()
        {
            InitializeComponent();
            Application.Current.MainWindow.Visibility = Visibility.Collapsed;
            //Выключаем при инициализации когда пустые комбобоксы
            CPUComboBox.IsEnabled = false;
            GPUComboBox.IsEnabled = false;
            RAMComboBox.IsEnabled = false;
            PWComboBox.IsEnabled = false;
            Save.IsEnabled = false;
            ShowMB.IsEnabled = false;
            ShowCPU.IsEnabled = false;
            ShowGPU.IsEnabled = false;
            ShowRAM.IsEnabled = false;
            ShowHDD.IsEnabled = false;
            ShowPW.IsEnabled = false;
            using (var context = new ConfigContext())
            {
                MBComboBox.ItemsSource = context.BDMotherBoards
                    .ToList();
                HDDComboBox.ItemsSource = context.DBHDDs
                    .ToList();
            }
            DataContext = _C;
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Config c = new Config();

            ConfirmConfig cc = new ConfirmConfig(_C, pw);
            cc.ShowDialog();
        }

        private void MBComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CheckShow();
            CheckPW(pw);
            CheckSave();
            CPUComboBox.IsEnabled = true;
            GPUComboBox.IsEnabled = true;
            RAMComboBox.IsEnabled = true;

/*                using (var context = new ConfigContext())
                {
                    CPU = context.BDMotherBoards.Where(n => n.MDName == _C.BDMotherBoards.MDName).Select(p => p.CPUsocket).First();
                    CPUComboBox.ItemsSource = context.DBCPUs.Where(s => s.CPUsocket == CPU).ToList();
                    GPU = context.BDMotherBoards.Where(n => n.MDName == _C.BDMotherBoards.MDName).Select(p => p.GPUsocket).First();
                    GPUComboBox.ItemsSource = context.DBGPUs.Where(s => s.GPUsocket == GPU).ToList();
                    RAM = context.BDMotherBoards.Where(n => n.MDName == _C.BDMotherBoards.MDName).Select(p => p.RAMsocket).First();
                    RAMComboBox.ItemsSource = context.DBRAMs.Where(s => s.RAMsocket == RAM).ToList();
                }*/
            

        }
        //чтоб сохранить нельзя нормально было
        public void CheckSave()
        {
            if (CPUComboBox.SelectedIndex != -1 && GPUComboBox.SelectedIndex != -1 && RAMComboBox.SelectedIndex != -1 && HDDComboBox.SelectedIndex != -1 && PWComboBox.SelectedIndex != -1)
            {
                Save.IsEnabled = true;
            }
            else { Save.IsEnabled = false; }
        }
        public void CheckPW(bool pw)
        {
            if (pw)
            {
                if (CPUComboBox.SelectedIndex != -1 && GPUComboBox.SelectedIndex != -1 && RAMComboBox.SelectedIndex != -1 && HDDComboBox.SelectedIndex != -1)
                {
                    PWComboBox.IsEnabled = true;
                    using (var context = new ConfigContext())
                    {
                        int count = 0;
                        count += context.DBGPUs.Where(p => p.GPUName == _C.DBGPUs.GPUName).Select(p => p.PowerEat).First();
                        count += context.DBCPUs.Where(p => p.CPUName == _C.DBCPUs.CPUName).Select(p => p.PowerEat).First();
                        count += context.DBHDDs.Where(p => p.HDDName == _C.DBHDDs.HDDName).Select(p => p.HDDPowerEat).First();


                        //калькулятор
                        PWComboBox.ItemsSource = context.DBPowerUnits
                            .Where(p => p.Power > count).ToList();
                    }
                }
                else { PWComboBox.IsEnabled = false; }
            }
            
        }
        public void CheckShow()
        {
            if (MBComboBox.SelectedIndex != -1)
            {
                ShowMB.IsEnabled = true;
            }
            else { ShowMB.IsEnabled = false; }

            if (CPUComboBox.SelectedIndex != -1)
            {
                ShowCPU.IsEnabled = true;
            }
            else { ShowCPU.IsEnabled = false; }

            if (GPUComboBox.SelectedIndex != -1)
            {
                ShowGPU.IsEnabled = true;
            }
            else { ShowGPU.IsEnabled = false; }

            if (RAMComboBox.SelectedIndex != -1)
            {
                ShowRAM.IsEnabled = true;
            }
            else { ShowRAM.IsEnabled = false; }

            if (HDDComboBox.SelectedIndex != -1)
            {
                ShowHDD.IsEnabled = true;
            }
            else { ShowHDD.IsEnabled = false; }

            if (PWComboBox.SelectedIndex != -1)
            {
                ShowPW.IsEnabled = true;
            }
            else { ShowPW.IsEnabled = false; }
        }

        private void CPUComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckShow();
            CheckPW(pw);
            CheckSave();
        }

        private void GPUComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckShow();
            CheckPW(pw);
            CheckSave();
        }

        private void RAMComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckShow();
            CheckPW(pw);
            CheckSave();
        }

        private void HDDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckShow();
            CheckPW(pw);
            CheckSave();
        }

        private void PWComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckShow();
            CheckSave();
        }

        private void ShowMB_Click(object sender, RoutedEventArgs e)
        {
            MBSpravka s = new MBSpravka(_C.BDMotherBoards.MDName);
            s.ShowDialog();
        }

        private void ShowCPU_Click(object sender, RoutedEventArgs e)
        {
            CPUSpravka s = new CPUSpravka(_C.DBCPUs.CPUName);
            s.ShowDialog();
        }

        private void ShowGPU_Click(object sender, RoutedEventArgs e)
        {
            GPUSpravka s = new GPUSpravka(_C.DBGPUs.GPUName);
            s.ShowDialog();
        }

        private void ShowRAM_Click(object sender, RoutedEventArgs e)
        {
            RAMSpravka s = new RAMSpravka(_C.DBRAMs.RAMName);
            s.ShowDialog();
        }

        private void ShowHDD_Click(object sender, RoutedEventArgs e)
        {
            HDDSpravka s = new HDDSpravka(_C.DBHDDs.HDDName);
            s.ShowDialog();
        }

        private void ShowPW_Click(object sender, RoutedEventArgs e)
        {
            PWSpravka s = new PWSpravka(_C.DBPowerUnits.PowerUnitName);
            s.ShowDialog();
        }
    }
}
