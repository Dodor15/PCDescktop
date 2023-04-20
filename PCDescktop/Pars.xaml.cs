using HtmlAgilityPack;
using PSConstruct.DBClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
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



    public partial class Pars : Window
    {

        //глобальные переменные для базы--------

        //для мамы
        string MBName;
        string MBCPUsocket;
        string MBGPUsocket;
        string MBRAMsocket= string.Empty;
        int CountRAM=0;

        //Для проца
        string CPUName= string.Empty;
        string CPUsocket= string.Empty;
        int CoreCount=0;
        int StreamCount=0;
        double CoreHz;
        bool GraphCore=false;
        int CPUPowerEat=0;

        //Для Видюхи
        string GPUName= string.Empty;
        string GPUsocket=string.Empty;
        int GPUMemoryCount=0;
        string GPUMemoryType= string.Empty;
        int GPUSpeed=0;
        int GPUPowerEat=0;

        //Для диска
        string HDDName= string.Empty;
        int HDDMemorySpeed=0;
        int HDDMemoryCount=0;
        int HDDPowerEat=0;

        //Для Оперативы
        string RAMName= string.Empty;
        int RAMMemorySpeed=0;
        int RAMMemoryCount=0;
        string RAMsocket= string.Empty;

        //Для Блока
        string PowerUnitName = string.Empty;
        int Power=0;

        //глобальные переменные для базы--------
        
        public Pars()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();
        }

        private void AddDataBase_Click(object sender, RoutedEventArgs e)
        {
            switch (whoIs.SelectedIndex)
            {
                case 0:
                    using (var context = new ConfigContext())
                    {
                        BDMotherBoard MB = new BDMotherBoard
                        {
                            MDName = this.MBName,
                            CountRAM = this.CountRAM,
                            CPUsocket = this.MBCPUsocket,
                            GPUsocket = this.MBGPUsocket,
                            RAMsocket = this.MBRAMsocket
                        };
                        context.BDMotherBoards.Add(MB);
                        context.SaveChanges();
                        MessageBox.Show("Сохраненно");
                        ResultLabel.Content = "";
                        URL.Text = "";
                    }
                    break;
                case 1:
                    using (var context = new ConfigContext())
                    {
                        DBCPU cpu = new DBCPU
                        {
                            CoreCount = this.CoreCount,
                            CoreHz = this.CoreHz,
                            CPUName = this.CPUName,
                            CPUsocket = this.CPUsocket,
                            GraphicsCore = this.GraphCore,
                            StreamsCount = this.StreamCount,
                            PowerEat = this.CPUPowerEat
                        };
                        context.DBCPUs.Add(cpu);
                        context.SaveChanges();
                        MessageBox.Show("Сохраненно");
                        ResultLabel.Content = "";
                        URL.Text = "";
                    }
                    break;
                case 2:
                    using (var context = new ConfigContext())
                    {
                        DBGPU gpu = new DBGPU
                        {
                            bandwidth = GPUSpeed,
                            GPUMemoryCount = this.GPUMemoryCount,
                            GPUName = this.GPUName,
                            GPUsocket = this.GPUsocket,
                            MemoryType = this.GPUMemoryType,
                            PowerEat = this.GPUPowerEat
                        };
                        context.DBGPUs.Add(gpu);
                        context.SaveChanges();
                        MessageBox.Show("Сохраненно");
                        ResultLabel.Content = "";
                        URL.Text = "";
                    }
                    break;
                case 3:
                    using (var context = new ConfigContext())
                    {
                        DBRAM ram = new DBRAM
                        {
                            RamMemoryCount = this.RAMMemoryCount,
                            RamMemorySpeed = this.RAMMemorySpeed,
                            RAMName = this.RAMName,
                            RAMsocket = this.RAMsocket
                        };
                        context.DBRAMs.Add(ram);
                        context.SaveChanges();
                        MessageBox.Show("Сохраненно");
                        ResultLabel.Content = "";
                        URL.Text = "";
                    }
                    break;
                case 4:
                    using (var context = new ConfigContext())
                    {
                        DBHDD hdd = new DBHDD
                        {
                            HDDMemoryCount = this.HDDMemoryCount,
                            HDDName = this.HDDName,
                            HDDPowerEat = this.HDDPowerEat,
                            MemorySpeed = this.HDDMemorySpeed
                        };
                        context.DBHDDs.Add(hdd);
                        context.SaveChanges();
                        MessageBox.Show("Сохраненно");
                        ResultLabel.Content = "";
                        URL.Text = "";
                    }
                    break;
                case 5:
                    using (var context = new ConfigContext())
                    {
                        DBPowerUnit pu = new DBPowerUnit
                        {
                            PowerUnitName = this.PowerUnitName,
                            Power = this.Power
                        };
                        context.DBPowerUnits.Add(pu);
                        context.SaveChanges();
                        MessageBox.Show("Сохраненно");
                        ResultLabel.Content = "";
                        URL.Text = "";
                    }
                    break;

            }
        }

        private void ToParceButton_Click(object sender, RoutedEventArgs e)
        {
            //Парс никса (https://www.nix.ru/) Жалко на эту работу потраченно 5 дней
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(URL.Text);
            HtmlNode htmlNode = doc.DocumentNode.SelectSingleNode("//table[@id='PriceTable']");
            List<HtmlNode> rows = htmlNode.Descendants("tr").ToList();
            string[,] tableData = new string[rows.Count, 2];
            for (int i = 1; i < rows.Count; i++)
            {
                var cells = rows[i].Descendants("td");

                if (cells.Count() >= 2)
                {
                    tableData[i, 0] = cells.ElementAt(0).InnerText.Trim();
                    tableData[i, 1] = cells.ElementAt(1).InnerText.Trim();
                }
                else
                {
                    tableData[i, 0] = cells.ElementAt(0).InnerText.Trim();
                }
            }
            switch (whoIs.SelectedIndex)
            {
                case 0:

                    //парс для матери

                    //Очистка лейбла, чтоб не дублировалось
                    ResultLabel.Content = "";
                    //Основной цикл перебора всей таблицы по первому элементу двумерного массива строк
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (tableData[i, 0] == "Модель")
                        {
                            if (tableData[i, 1].Length > 22)
                            {
                                //странь господня, чтоб убрать "Подобрать рохожее"
                                string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 23);
                                ResultLabel.Content += socket + "\n";
                                MBName = socket;
                            }
                            else
                            {
                                string socket = tableData[i, 1];
                                ResultLabel.Content += socket + "\n";
                                MBName = socket;
                            }
                        }
                        if (tableData[i, 0] == "Гнездо процессора")
                        {

                            if (tableData[i, 1].Length > 22)
                            {
                                string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 16);
                                ResultLabel.Content += socket + "\n";
                                MBCPUsocket = socket;
                            }
                            else
                            {
                                string socket = tableData[i, 1];
                                ResultLabel.Content += socket + "\n";
                                MBCPUsocket = socket;
                            }
                        }
                        if (tableData[i, 0] == "Тип поддерживаемой памяти")
                        {
                            //это если вместо DDR4 будет "Мультиприкольный DDR4 с первым приколом серверного типа и т.д"
                            if (tableData[i, 1].Length > 3)
                            {
                                string socket = tableData[i, 1].Remove(tableData[i, 1].Length - (tableData[i, 1].Length - 4));
                                ResultLabel.Content += socket + "\n";
                                MBRAMsocket = socket;
                            }
                            else
                            {
                                string socket = tableData[i, 1];
                                ResultLabel.Content += socket + "\n";
                                MBRAMsocket = socket;
                            }
                        }
                        if (tableData[i, 0] == "Количество слотов памяти")
                        {
                            ResultLabel.Content += tableData[i, 1] + "\n";
                            CountRAM = Convert.ToInt32(tableData[i, 1]);
                        }
                    }
                   MBGPUsocket = "PCI Express 16x";
                    //Хитрый алексей будет добавлять в таблицу видеокарты только под этот PCI так как на большенстве теблиц эту ифу достать сложно
                    ResultLabel.Content += $"{MBName} {MBCPUsocket} {MBGPUsocket} {MBRAMsocket} {CountRAM}";
                    break;
                case 1:

                    //парс для прцессора

                    ResultLabel.Content = "";
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (tableData[i, 0] == "Модель")
                        {
                            if (tableData[i, 1].Length > 22)
                            {
                                string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 23);
                                ResultLabel.Content += socket + "\n";
                                CPUName = socket;
                            }
                            else
                            {
                                string socket = tableData[i, 1];
                                ResultLabel.Content += socket + "\n";
                                CPUName = socket;
                            }
                        }
                        if (tableData[i, 0] == "Гнездо процессора")
                        {
                            if (tableData[i, 1].Length > 22)
                            {
                                string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 21);
                                ResultLabel.Content += socket + "\n";
                                CPUsocket = socket;
                            }
                            else
                            {
                                string socket = tableData[i, 1];
                                ResultLabel.Content += socket + "\n";
                                CPUsocket = socket;
                            }
                        }
                        if (tableData[i, 0] == "Количество ядер")
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Content += socket + "\n";
                            CoreCount = Convert.ToInt32(socket);

                        }
                        if (tableData[i, 0] == "Количество потоков")
                        {
                            ResultLabel.Content += tableData[i, 1] + "\n";
                            StreamCount = Convert.ToInt32(tableData[i, 1]);
                        }
                        if (tableData[i, 0] == "Частота работы процессора")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += word[0]+"\n";
                            try
                            {
                                CoreHz = Convert.ToDouble(word[0]);
                            }
                            catch
                            {
                                IFormatProvider fotmater = new NumberFormatInfo { NumberDecimalSeparator = "." };
                                CoreHz = double.Parse(word[0], fotmater);
                            }
                        }
                        
                        if (tableData[i, 0] == "Видеоядро процессора")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            if (word[0] == "Нет")
                            {
                                ResultLabel.Content += "false\n";
                                GraphCore = false;
                            }
                            else { ResultLabel.Content += "true\n"; GraphCore = true; }
                        }

                        if (tableData[i, 0] == "Рассеиваемая мощность")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += word[0];
                            CPUPowerEat = Convert.ToInt32(word[0]);
                        }


                    }
                    ResultLabel.Content += "PCI Express 16x";
                    break;
                case 2:
                    //Парс видюхи
                    ResultLabel.Content = "";
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (tableData[i, 0] == "GPU")
                        {
                            if (tableData[i, 1].Length > 22)
                            {
                                string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 27);
                                ResultLabel.Content += socket + "\n";
                                GPUName = socket;
                            }
                            else
                            {
                                string socket = tableData[i, 1];
                                ResultLabel.Content += socket + "\n";
                                GPUName = socket;
                            }
                        }

                        if (tableData[i, 0] == "Видеопамять")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "памяти" + word[0] + "\n";
                            GPUMemoryCount = Convert.ToInt32(word[0]);
                        }
                        if (tableData[i, 0] == "Тип видеопамяти")
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Content += "Тип " + socket + "\n";
                            GPUMemoryType = socket;

                        }
                        if (tableData[i, 0] == "Частота видеопамяти")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "Частота " + word[0] + "\n";
                            GPUSpeed = Convert.ToInt32(word[0]);
                        }
                        string power = "";
                        if (tableData[i, 0] == "Питание:Максимальное энергопотребление")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "Питание " + word[0] + "\n";
                            GPUPowerEat = Convert.ToInt32(word[0]);
                            power = word[0];
                        }
                        else if (tableData[i, 0] == "Рекомендуемая мощность блока питания" && power == "")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "Питание " + $"{Convert.ToInt32(word[0]) - Convert.ToInt32(word[0]) / 2}\n";
                            GPUPowerEat = Convert.ToInt32(word[0]) - Convert.ToInt32(word[0]) / 2;
                        }







                    }
                    GPUsocket = "PCI Express 16x";
                    ResultLabel.Content += "PCI Express 16x";
                    break;
                case 4:
                    //Парс внутренних дисков
                    ResultLabel.Content = "";
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (tableData[i, 0] == "Модель")
                        {
                            if (tableData[i, 1].Length > 22)
                            {
                                string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 17);
                                ResultLabel.Content += socket + "\n";
                                HDDName = socket;
                            }
                            else
                            {
                                string socket = tableData[i, 1];
                                ResultLabel.Content += socket + "\n";
                                HDDName = socket;
                            }
                        }

                        if (tableData[i, 0] == "Емкость накопителя")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            //В базу суём только гиги (Не за шаги)
                            if (word[1][0] == 'Т')
                            {
                                ResultLabel.Content += "памяти" + Convert.ToInt32(word[0]) * 1024 + "\n";
                                HDDMemoryCount = Convert.ToInt32(word[0]) * 1024;
                            }
                            else { ResultLabel.Content += "памяти" + word[0] + "\n"; HDDMemoryCount = Convert.ToInt32(word[0]); }

                        }
                        if (tableData[i, 0] == "Установившаяся скорость передачи данных")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "Частота " + word[1] + "\n";
                            HDDMemorySpeed = Convert.ToInt32(word[1]);
                        }
                        else if (tableData[i,0] == "Скорость чтения" && HDDMemorySpeed<1)
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "Частота " + word[1] + "\n";
                            HDDMemorySpeed = Convert.ToInt32(word[1]);
                        }

                        
                        
                        if (tableData[i, 0] == "Потребление энергии")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "Питание " + word[0] + "\n";
                            try
                            {
                                HDDPowerEat = Convert.ToInt32(word[0]);
                            }
                            catch
                            {
                                HDDPowerEat = 5;
                            }
                            

                        }

                    }
                    if (HDDPowerEat < 1)
                    {
                        HDDPowerEat = 50;
                        ResultLabel.Content += $"потребление {HDDPowerEat}\n";
                    }
                    if (HDDMemorySpeed < 1)
                    {
                        HDDMemorySpeed = 140;
                        ResultLabel.Content += $"Скорость {HDDMemorySpeed}\n";
                    }
                    break;
                case 5:
                    //Парс для Блока Питания
                    ResultLabel.Content = "";
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (tableData[i, 0] == "Модель")
                        {
                            if (tableData[i, 1].Length > 22)
                            {
                                string socket = tableData[i, 1].Remove(tableData[i, 1].Length - 26);
                                ResultLabel.Content += socket + "\n";
                                PowerUnitName = socket;
                            }
                            else
                            {
                                string socket = tableData[i, 1];
                                ResultLabel.Content += socket + "\n";
                                PowerUnitName = socket;
                            }
                        }
                        if (tableData[i, 0] == "Мощность блока питания")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "всего " + word[0] + "\n";
                            Power = Convert.ToInt32(word[0]);
                        }
                    }
                    break;
                case 3:
                    //Парс для Оперативы
                    ResultLabel.Content = "";
                    for (int i = 0; i < rows.Count; i++)
                    {
                        if (tableData[i, 0] == "Серия")
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Content += socket + " ";
                            RAMName = socket;
                        }
                        if (tableData[i, 0] == "Модель")
                        {
                            string socket = tableData[i, 1];
                            ResultLabel.Content += socket + "\n";
                            RAMName += " " + socket;

                        }
                        if (tableData[i, 0] == "Тип оборудования")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "всего " + word[2] + "\n";
                            RAMsocket = word[2];
                        }
                        if (tableData[i, 0] == "Объем модуля памяти")
                        {
                            string[] word = tableData[i, 1].Split(' ');

                            ResultLabel.Content += "speed " + word[0] + "\n";
                            RAMMemoryCount = Convert.ToInt32(word[0]);
                        }
                        if (tableData[i, 0] == "Пропускная способность памяти")
                        {
                            string[] word = tableData[i, 1].Split(' ');
                            ResultLabel.Content += "speed " + word[0] + "\n";
                            RAMMemorySpeed = Convert.ToInt32(word[0]);
                        }
                    }
                    break;

            }

        }

        private void AddDataBase_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
