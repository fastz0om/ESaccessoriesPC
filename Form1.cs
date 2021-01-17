using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESaccessoriesPC
{
    public partial class Form1 : Form
    {
        private Dictionary<string, List<Motherboard>> _motherboard = new Dictionary<string, List<Motherboard>>();
        private Dictionary<string, List<GraphicsCard>> _graphicscards = new Dictionary<string, List<GraphicsCard>>();
        private Dictionary<string, List<CPU>> _cpu = new Dictionary<string, List<CPU>>();
        private Dictionary<string, List<RAM>> _ram = new Dictionary<string, List<RAM>>();
        private Dictionary<string, List<HDD>> _hdd = new Dictionary<string, List<HDD>>();
        private Dictionary<string, List<SSD>> _ssd = new Dictionary<string, List<SSD>>();
        private Dictionary<string, List<Cooling>> _cooling = new Dictionary<string, List<Cooling>>();
        private Dictionary<string, List<PowerSupply>> _powersupply = new Dictionary<string, List<PowerSupply>>();

        private int _maxAmount = 0;
        private int _currentAmount = 0;

        private List<string> _configuration = new List<string>();
        private Dictionary<string, int> _currentAmountDic = new Dictionary<string, int>();


        public Form1()
        {
            InitializeComponent();
            initCombobox();
            initMotherboard();
            initCPU();
            initGraphicsCard();
            initRAM();
            initHDD();
            initSSD();
            initCooling();
            initPowerSupply();
        }

        private void initCombobox()
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            comboBox11.SelectedIndex = 0;
            comboBox12.SelectedIndex = 0;
            comboBox13.SelectedIndex = 0;
            comboBox14.SelectedIndex = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox9.Enabled = false;
                comboBox11.Enabled = false;
                comboBox14.Enabled = false;

                comboBox6.Items.Remove("16");
            }
            else
            {
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox14.Enabled = true;

                if (!comboBox6.Items.Contains("16"))
                    comboBox6.Items.Add("16");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _currentAmountDic.Clear();
            _configuration.Clear();
            textBox2.Clear();
            _maxAmount = Int32.Parse(textBox1.Text);
            _currentAmount = _maxAmount;
            CalculateConfiguration();
        }

        private void CalculateConfiguration()
        {
            if (comboBox14.Enabled && comboBox14.SelectedIndex == 0)
            {
                _currentAmount -= 2299;
                _configuration.Add("Корпус:\nКорпус AeroCool Streak [ACCM-PV19012.11] черный\n[Mid-Tower, Micro-ATX, Mini-ITX, Standard-ATX, боковое окно, 1x USB 3.0, 2x USB 2.0]");
            }
            else if ((comboBox14.Enabled && comboBox14.SelectedIndex == 0) || !comboBox14.Enabled)
            {
                _currentAmount -= 1399;
                _configuration.Add("Корпус:\n Корпус DEXP DC-101B черный\n [Mid-Tower, Micro-ATX, Mini-ITX, Standard-ATX, 2x USB 2.0]");
            }


            if (comboBox11.Enabled && comboBox11.SelectedIndex == 0)
            {
                _currentAmount -= 950;
                _configuration.Add("Охлаждение для корпуса:\n Вентилятор Gelid Silent 9 TC [FN-TX09-20] x2\n [92 x 92 мм, 3-pin, 900 об/мин - 2000 об/мин, 11 дБ - 23.5 дБ, в комплекте - 1]");
            }


            if (comboBox13.SelectedIndex == 0)
            {
                _currentAmount -= 1299;
                _configuration.Add("WiFi модуль:\n Wi-Fi адаптер TP-LINK Archer T2U Plus\n [USB, PCMCIA, 5 (802.11ac), 4 (802.11n), 600 Мбит, 2.4 ГГц, 5 ГГц, антенна - внешняя, передатчик - 18 dBm]");
            }


            foreach (Motherboard motherboard in _motherboard[comboBox2.SelectedItem.ToString()])
            {
                if (motherboard.Cost >= 0.10 * _maxAmount && motherboard.Cost <= 0.25 * _maxAmount)
                {
                    _currentAmount -= motherboard.Cost;
                    _configuration.Add("Материнская плата:\n " + motherboard.Name + "\n " + motherboard.Description);
                    _currentAmountDic.Add("motherboard", motherboard.Cost);
                    break;
                }
            }

            foreach (CPU cpu in _cpu[comboBox3.SelectedItem.ToString()])
            {
                if (cpu.Cost >= 0.10 * _maxAmount && cpu.Cost <= 0.25 * _maxAmount)
                {
                    _currentAmount -= cpu.Cost;
                    _configuration.Add("Процессор:\n " + cpu.Name + "\n " + cpu.Description);
                    _currentAmountDic.Add("cpu", cpu.Cost);
                    break;
                }
            }

            foreach (GraphicsCard graphics in _graphicscards[comboBox4.SelectedItem.ToString()])
            {
                if (graphics.Cost >= 0.15 * _maxAmount && graphics.Cost <= 0.35 * _maxAmount)
                {
                    _currentAmount -= graphics.Cost;
                    _configuration.Add("Видеокарта:\n" + graphics.Name + "\n" + graphics.Description);
                    _currentAmountDic.Add("graphicscard", graphics.Cost);

                    break;
                }
            }


            foreach (RAM ram in _ram[comboBox5.SelectedItem.ToString()])
            {
                if (ram.Memory >= Int32.Parse(comboBox6.SelectedItem.ToString()))
                {
                    _currentAmount -= ram.Cost;
                    _configuration.Add("ОЗУ:\n " + ram.Name + "\n " + ram.Description);
                    _currentAmountDic.Add("ram", ram.Cost);
                    break;
                }
            }

            foreach (HDD hdd in _hdd["All"])
            {
                if (hdd.Memory >= Int32.Parse(comboBox7.SelectedItem.ToString()))
                {
                    _currentAmount -= hdd.Cost;
                    _configuration.Add("HDD:\n " + hdd.Name + "\n " + hdd.Description);
                    _currentAmountDic.Add("hdd", hdd.Cost);
                    break;
                }
            }

            if (comboBox9.Enabled)
                foreach (SSD ssd in _ssd["All"])
                {
                    if (ssd.Memory >= Int32.Parse(comboBox9.SelectedItem.ToString()))
                    {
                        _currentAmount -= ssd.Cost;
                        _configuration.Add("SSD:\n " + ssd.Name + "\n " + ssd.Description);
                        _currentAmountDic.Add("ssd", ssd.Cost);
                        break;
                    }
                }

            foreach (Cooling cooling in _cooling[comboBox10.SelectedItem.ToString()])
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (cooling.Cost >= 400 && cooling.Cost <= 800)
                        _currentAmount -= cooling.Cost;
                    _configuration.Add("Система охлаждения:\n" + cooling.Name + "\n" + cooling.Description);
                    _currentAmountDic.Add("cooling", cooling.Cost);

                    break;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (cooling.Cost >= 600 && cooling.Cost <= 1500)
                    {
                        _currentAmount -= cooling.Cost;
                        _configuration.Add("Система охлаждения:\n" + cooling.Name + "\n" + cooling.Description);
                        _currentAmountDic.Add("cooling", cooling.Cost);
                        break;
                    }
                }
                else
                {
                    if (cooling.Cost >= 800)
                    {
                        _currentAmount -= cooling.Cost;
                        _configuration.Add("Система охлаждения:\n" + cooling.Name + "\n" + cooling.Description);
                        _currentAmountDic.Add("cooling", cooling.Cost);
                        break;
                    }
                }
            }

            foreach (PowerSupply powerSupply in _powersupply[comboBox12.SelectedItem.ToString()])
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (powerSupply.Power >= 200 && powerSupply.Power <= 400)
                    {
                        _currentAmount -= powerSupply.Cost;
                        _configuration.Add("Блок питания:\n" + powerSupply.Name + "\n" + powerSupply.Description);
                        _currentAmountDic.Add("powersupply", powerSupply.Cost);
                        break;
                    }
                }
                else
                {
                    if (powerSupply.Power >= 400)
                    {
                        _currentAmount -= powerSupply.Cost;
                        _configuration.Add("Блок питания:\n" + powerSupply.Name + "\n" + powerSupply.Description);
                        _currentAmountDic.Add("powersupply", powerSupply.Cost);
                        break;
                    }
                }
            }

            upgradeConfiguration();

            foreach (string s in _configuration)
            {
                textBox2.Text += s + Environment.NewLine;
            }
            textBox2.Text += "Итоговая сумма: " + (_maxAmount-_currentAmount).ToString();

        }


        private void upgradeConfiguration()
        {
            if (_currentAmount > 5000)
            {
                foreach (Motherboard mb in _motherboard[comboBox2.SelectedItem.ToString()])
                    if (mb.Cost > _currentAmountDic["motherboard"])
                    {
                        _currentAmount += _currentAmountDic["motherboard"];
                        _currentAmountDic["motherboard"] = mb.Cost;
                        _currentAmount -= mb.Cost;
                        if (_currentAmount >= 0)
                        {
                            foreach (string s in _configuration)
                                if (s.Contains("Материнская плата"))
                                {
                                    _configuration[_configuration.IndexOf(s)] = "Материнская плата:\n " + mb.Name + "\n " + mb.Description;
                                    break;
                                }
                        }
                        break;
                    }
            }

            if (_currentAmount > 6000)
            {
                foreach (GraphicsCard gc in _graphicscards[comboBox2.SelectedItem.ToString()])
                    if (gc.Cost > _currentAmountDic["graphicscard"])
                    {
                        int tempCost = 0;
                        tempCost = _currentAmountDic["graphicscard"];
                        _currentAmount += _currentAmountDic["graphicscard"];
                        _currentAmountDic["graphicscard"] = gc.Cost;
                        _currentAmount -= gc.Cost;
                        if (_currentAmount >= 0)
                        {
                            foreach (string s in _configuration)
                                if (s.Contains("Видеокарта"))
                                {
                                    _configuration[_configuration.IndexOf(s)] = "Видеокарта:\n " + gc.Name + "\n " + gc.Description;
                                    break;
                                }
                        }
                        else
                        {
                            _currentAmount += gc.Cost;
                            _currentAmount -= tempCost;
                            _currentAmountDic["graphicscard"] = tempCost;
                            _configuration.Add("Есть возможность улучшить видеокарту(" + gc.Name + "), но необходимо доплатить: " + (gc.Cost-tempCost));
                        }
                        break;
                    }
            }
        }

        private void initMotherboard()
        {
            List<Motherboard> mbAsusList = new List<Motherboard>
            {
                new Motherboard("ASUS M5A78L-M LX3", "AM3+, AMD 760G, 2xDDR3-1866 МГц, 1xPCI-Ex16, аудио 7.1, Micro-ATX", 4199),
                new Motherboard("ASUS PRIME B365-PLUS", "LGA 1151-v2, Intel B365, 4xDDR4-2666 МГц, 2xPCI-Ex16, аудио 7.1, Standard-ATX", 7950),
                new Motherboard("ASUS TUF B365M-PLUS GAMING", "LGA 1151-v2, Intel B365, 4xDDR4-2666 МГц, 2xPCI-Ex16, аудио 7.1, Micro-ATX", 8299),
                new Motherboard("ASUS PRIME X570-P", "AM4, AMD X570, 4xDDR4-4400 МГц, 2xPCI-Ex16, аудио 7.1, Standard-ATX", 13799),
                new Motherboard("ASUS PRIME Z390-A", "LGA 1151-v2, Intel Z390, 4xDDR4-4266 МГц, 3xPCI-Ex16, аудио 7.1, Standard-ATX", 15399),
                new Motherboard("ASUS ROG STRIX Z490-F GAMING ", "LGA 1200, Intel Z490, 4xDDR4-4800 МГц, 3xPCI-Ex16, аудио 7.1, Standard-ATX", 23499)
            };

            List<Motherboard> mbGigabyteList = new List<Motherboard>
            {
                new Motherboard("GIGABYTE H310M DS2 2.0","LGA 1151-v2, Intel H310, 2xDDR4-2666 МГц, 1xPCI-Ex16, аудио 7.1, Micro-ATX", 4999),
                new Motherboard("GIGABYTE H310M H 2.0","LGA 1151-v2, Intel H310, 2xDDR4-2666 МГц, 1xPCI-Ex16, аудио 7.1, Micro-ATX", 4599),
                new Motherboard("GIGABYTE H470M DS3H","LGA 1200, Intel H470, 4xDDR4-2933 МГц, 2xPCI-Ex16, аудио 7.1, Micro-ATX", 8499),
                new Motherboard("GIGABYTE B550 AORUS ELITE","AM4, AMD B550, 4xDDR4-4733 МГц, 3xPCI-Ex16, аудио 7.1, Standard-ATX", 12499),
                new Motherboard("GIGABYTE Z490 GAMING X AX","LGA 1200, Intel Z490, 4xDDR4-4600 МГц, 2xPCI-Ex16, аудио 7.1, Standard-ATX", 15999),
                new Motherboard("GIGABYTE X570 AORUS ULTRA","AM4, AMD X570, 4xDDR4-4400 МГц, 3xPCI-Ex16, аудио 7.1, Standard-ATX", 24999)
            };

            List<Motherboard> mbMSIList = new List<Motherboard>
            {
                new Motherboard("MSI B450-A PRO MAX","AM4, AMD B450, 4xDDR4-4133 МГц, 2xPCI-Ex16, аудио 7.1, Standard-ATX", 7799),
                new Motherboard("MSI H310M PRO-VDH PLUS","LGA 1151-v2, Intel H310, 2xDDR4-2666 МГц, 1xPCI-Ex16, аудио 7.1, Micro-ATX", 4599),
                new Motherboard("MSI Z390 MAG TOMAHAWK","LGA 1151-v2, Intel Z390, 4xDDR4-4400 МГц, 3xPCI-Ex16, аудио 7.1, Standard-ATX", 11999),
                new Motherboard("MSI Z390 MPG GAMING EDGE AC","LGA 1151-v2, Intel Z390, 4xDDR4-4400 МГц, 3xPCI-Ex16, аудио 7.1, Standard-ATX",14999),
                new Motherboard("MSI Z490M MPG GAMING EDGE WIFI","LGA 1200, Intel Z490, 4xDDR4-4800 МГц, 2xPCI-Ex16, аудио 7.1, Micro-ATX", 18499),
                new Motherboard("MSI MPG Z490 GAMING CARBON WIFI","LGA 1200, Intel Z490, 4xDDR4-4800 МГц, 3xPCI-Ex16, аудио 7.1, Standard-ATX", 22499)
            };

            _motherboard.Add("Asus", mbAsusList);
            _motherboard.Add("Gigabyte", mbGigabyteList);
            _motherboard.Add("MSI", mbMSIList);
        }

        private void initRAM()
        {
            List<RAM> ramGoodramList = new List<RAM>
            {
                new RAM("Goodram [GR1333D364L9/4G]","DDR3, 4 ГБx1 шт, 1333 МГц, PC10600, 9-9-9-24", 4, 1750),
                new RAM("Goodram CL11 [GR1600D3V64L11/8G]","DDR3, 8 ГБx1 шт, 1600 МГц, PC12800, 11-11-11-28", 8, 2599),
                new RAM("Goodram IRDM X [IR-XR2666D464L16/16G","DDR4, 16 ГБx1 шт, 2666 МГц, PC21300, 16-18-18",16,4999 ),
                new RAM("Goodram Iridium [IR-R1600D364L10/16GDC]","DDR3, 8 ГБx2 шт, 1600 МГц, PC12800, 10-10-10", 16, 5499),
                new RAM("Goodram [GR2666D464L19/32G]","DDR4, 32 ГБx1 шт, 2666 МГц, PC21300, 19-19-19", 32, 9499),
                new RAM("Goodram [GR2400D464L17S/16GDC]","DDR4, 8 ГБx2 шт, 2400 МГц, PC19200, 17", 16, 5199)
            };

            List<RAM> ramHyperXList = new List<RAM>
            {
                new RAM("HyperX FURY Black Series [HX316C10FB/4]","DDR3, 4 ГБx1 шт, 1600 МГц, PC12800, 10-10-10-38", 4, 1899),
                new RAM("HyperX FURY Black [HX432C16FB3/4]","DDR4, 4 ГБx1 шт, 3200 МГц, PC25600, 16-18-18-32", 4, 2099),
                new RAM("HyperX FURY White Series [HX318C10FW/8]","DDR3, 8 ГБx1 шт, 1866 МГц, PC14900, 10-11-10-32", 8, 3599),
                new RAM("HyperX FURY Black [HX426C16FB4/16]","DDR4, 16 ГБx1 шт, 2666 МГц, PC21300, 16-18-18", 16, 5499),
                new RAM("HyperX FURY Black [HX432C16FB3/16]","DDR4, 16 ГБx1 шт, 3200 МГц, PC25600, 16-18-18-32", 16, 6499),
                new RAM("HyperX Predator [HX426C13PB3K2/16]","DDR4, 8 ГБx2 шт, 2666 МГц, PC21300, 13-15-15-32", 16, 6799)
            };

            List<RAM> ramKingstonList = new List<RAM>
            {
                new RAM("Kingston [KVR24N17S6/4]","DDR4, 4 ГБx1 шт, 2400 МГц, PC19200, 17-17-17-32", 4, 1699),
                new RAM("Kingston ValueRAM [KVR29N21S6/8]","DDR4, 8 ГБx1 шт, 2933 МГц, PC23466, 21-21-21", 8, 2750),
                new RAM("Kingston ValueRAM [KVR32N22S8/8]","DDR4, 8 ГБx1 шт, 3200 МГц, PC25600, 22-22-22-32", 8, 2999),
                new RAM("Kingston ValueRAM [KVR26N19S8/16]","DDR4, 16 ГБx1 шт, 2666 МГц, PC21300, 19-19-19-32", 16, 4999),
                new RAM("Kingston ValueRAM [KVR24N17D8/16]","DDR4, 16 ГБx1 шт, 2400 МГц, PC19200, 17-17-17-32", 16, 5499),
                new RAM("Kingston ValueRAM [KVR16N11K2/16]","", 16, 6899)
            };

            _ram.Add("Goodram", ramGoodramList);
            _ram.Add("HyperX", ramHyperXList);
            _ram.Add("Kingston", ramKingstonList);
        }

        private void initGraphicsCard()
        {
            List<GraphicsCard> gcMSIList = new List<GraphicsCard>
            {
                new GraphicsCard("MSI GeForce GT 1030 AERO ITX OC", "PCI-E 3.0, 2 ГБ GDDR4, 64 бит, 1189 МГц - 1430 МГц, HDMI, DVI-D", 5699),
                new GraphicsCard("MSI GeForce GTX 1650 D6 VENTUS XS OC V1", "PCI-E 3.0, 4 ГБ GDDR6, 128 бит, 1485 МГц - 1620 МГц, DVI-D, DisplayPort, HDMI", 15799),
                new GraphicsCard("MSI AMD Radeon RX 580 ARMOR OC", "PCI-E 3.0, 8 ГБ GDDR5, 256 бит, 1257 МГц - 1366 МГц, DisplayPort (2 шт), HDMI (2 шт), DVI-D", 24999),
                new GraphicsCard("MSI GeForce GTX 1660 SUPER VENTUS OC", "PCI-E 3.0, 6 ГБ GDDR6, 192 бит, 1530 МГц - 1815 МГц, DisplayPort (3 шт), HDMI", 30999)
            };

            List<GraphicsCard> gcGigabyteList = new List<GraphicsCard>
            {
                new GraphicsCard("GigaByte GeForce GT 730 LP [GV-N730D5-2GL]","PCI-E 2.0, 2 ГБ GDDR5, 64 бит, 902 МГц, HDMI, DVI-I", 5250),
                new GraphicsCard("GIGABYTE GeForce GT 1030 OC","PCI-E 3.0, 2 ГБ GDDR5, 64 бит, 1265 МГц - 1544 МГц, HDMI, DVI-D", 6850),
                new GraphicsCard("GIGABYTE GeForce GTX 1650 D6 OC (rev. 2.0)","PCI-E 3.0, 4 ГБ GDDR6, 128 бит, 1410 МГц - 1635 МГц, DVI-D, DisplayPort, HDMI", 15499),
                new GraphicsCard("GIGABYTE GeForce GTX 1660 SUPER OC","PCI-E 3.0, 6 ГБ GDDR6, 192 бит, 1530 МГц - 1830 МГц, HDMI, DisplayPort (3 шт)", 30999)
            };

            _graphicscards.Add("MSI", gcMSIList);
            _graphicscards.Add("Gigabyte", gcGigabyteList);
        }

        private void initCPU()
        {
            List<CPU> cpuAmdList = new List<CPU>
            {
                new CPU("AMD Athlon 200GE OEM","AM4, 2 x 3200 МГц, L2 - 1 МБ, L3 - 4 МБ, 2хDDR4-2667 МГц, Radeon Vega 3, TDP 35 Вт",3299),
                new CPU("AMD Ryzen 3 3100 OEM","AM4, 4 x 3600 МГц, L2 - 2 МБ, L3 - 16 Мб, 2хDDR4-3200 МГц, TDP 65 Вт", 8499),
                new CPU("AMD A6-7480 OEM","FM2+, 2 x 3500 МГц, L2 - 1 МБ, 2хDDR3-1600 МГц, Radeon R5, TDP 65 Вт", 2299),
                new CPU("AMD Ryzen 3 PRO 3200G OEM","AM4, 4 x 3600 МГц, L2 - 2 МБ, L3 - 4 МБ, 2хDDR4-2933 МГц, Radeon Vega 8, TDP 65 Вт", 10199)
            };

            List<CPU> cpuIntelList = new List<CPU>
            {
                new CPU("Intel Celeron G5905 BOX","LGA 1200, 2 x 3500 МГц, L2 - 512 КБ, L3 - 4 МБ, 2хDDR4-2666 МГц, Intel UHD Graphics 610, TDP 58 Вт, кулер", 3399),
                new CPU("Intel Pentium G4560 OEM","LGA 1151, 2 x 3500 МГц, L2 - 512 КБ, L3 - 3 МБ, 2хDDR4, DDR3L-2400 МГц, Intel HD Graphics 610, TDP 54 Вт", 5499),
                new CPU("Intel Pentium Gold G6500 OEM","LGA 1200, 2 x 4100 МГц, L2 - 512 КБ, L3 - 4 МБ, 2хDDR4-2666 МГц, Intel UHD Graphics 630, TDP 58 Вт", 6899 ),
                new CPU("Intel Core i3-9100F OEM","LGA 1151-v2, 4 x 3600 МГц, L2 - 1 МБ, L3 - 6 МБ, 2хDDR4-2400 МГц, TDP 65 Вт", 8599)
            };

            _cpu.Add("AMD", cpuAmdList);
            _cpu.Add("INTEL", cpuIntelList);
        }

        private void initHDD()
        {
            List<HDD> hddList = new List<HDD>
            {
                new HDD("500 ГБ Жесткий диск WD Blue [WD5000AZLX]","SATA III, 6 Гбит/с, 7200 об/мин, кэш память - 32 МБ",500, 2899),
                new HDD("500 ГБ Жесткий диск Seagate BarraCuda [ST500DM009]","SATA III, 6 Гбит/с, 7200 об/мин, кэш память - 32 МБ", 500, 3099),
                new HDD("500 ГБ Жесткий диск WD Black [WD5003AZEX]","SATA III, 6 Гбит/с, 7200 об/мин, кэш память - 64 МБ", 500, 5499),
                new HDD("ТБ Жесткий диск Toshiba Enterprise HDD [MG04ACA100N]","SATA III, 6 Гбит/с, 7200 об/мин, кэш память - 128 МБ", 1000, 6499)
            };

            _hdd.Add("All", hddList);
        }

        private void initSSD()
        {
            List<SSD> ssdList = new List<SSD>
            {
                new SSD("240 ГБ SSD M.2 накопитель Kingston A400 [SA400M8/240G]", "SATA 3, чтение - 500 Мбайт/сек, запись - 350 Мбайт/сек, Phison PS3111-S11, 2D NAND 3 бит TLC", 240, 2599),
                new SSD("240 ГБ SSD M.2 накопитель Transcend MTS420 [TS240GMTS420S]", "SATA 3, чтение - 560 Мбайт/сек, запись - 500 Мбайт/сек, Silicon Motion SM2258H AB, 3D NAND 3 бит TLC", 240, 3199),
                new SSD("256 ГБ SSD M.2 накопитель Neo Forza Zion NFP03 [NFP035PCI56-3400200]", "PCI-E 3.0 x4, чтение - 1300 Мбайт/сек, запись - 800 Мбайт/сек, Silicon Motion SM2263XT, 3D NAND 3 бит TLC, NVM Express", 256, 4250),
                new SSD("240 ГБ SSD M.2 накопитель Kingston DC1000B [SEDC1000BM8/240G]", "PCI-E 3.0 x4, чтение - 2200 Мбайт/сек, запись - 290 Мбайт/сек, 3D NAND 3 бит TLC, NVM Express", 240, 6999)
            };

            _ssd.Add("All", ssdList);
        }

        private void initCooling()
        {
            List<Cooling> coolingsDeepList = new List<Cooling>
            {
                new Cooling("DEEPCOOL Theta 20 [DP-ICAS-T20]", "основание - алюминий, 2200 об/мин, 30.2 дБ, 3-pin, 95 Вт", 450),
                new Cooling("DEEPCOOL Gamma Archer [DP-MCAL-GA]", "основание - алюминий, 1600 об/мин, 26.1 дБ, 3-pin, 95 Вт", 599),
                new Cooling("DEEPCOOL Ice Blade 100 [DP-MCH1D8-IB100]", "основание - алюминий-медь, 2200 об/мин, 31.6 дБ, 3-pin, 100 Вт", 899),
            };

            List<Cooling> coolingsOtherList = new List<Cooling>
            {
                new Cooling("Xilence Performance C M403.TBL", "основание - алюминий-медь, 2000 об/мин, 23.8 дБ, 4-pin, подсветка, 150 Вт", 1799)
            };

            _cooling.Add("Deepcool", coolingsDeepList);
            _cooling.Add("Other", coolingsOtherList);
        }

        private void initPowerSupply()
        {
            List<PowerSupply> powerSuppliesDeepList = new List<PowerSupply>
            {
                new PowerSupply("DEEPCOOL DE500 v2 [DE500]","500 Вт, EPS12V, 20+4 pin, 1x 4+4 pin CPU, 4 шт SATA, 1x 6+2 pin PCI-E", 500, 2450),
                new PowerSupply("Блок питания Deepcool DN350","350 Вт, EPS12V, APFC, 20+4 pin, 1x 4+4 pin CPU, 5 шт SATA, 1x 6+2 pin PCI-E", 350 ,2650),
                new PowerSupply("Deepcool DN650","650 Вт, EPS12V, APFC, 20+4 pin, 1x 4+4 pin CPU, 5 шт SATA, 2x 6+2 pin PCI-E", 650, 4050)
            };

            List<PowerSupply> powerSuppliesOtherList = new List<PowerSupply>
            {
                new PowerSupply("Corsair CV450 [CP-9020209-EU]","450 Вт, 80+ Bronze, EPS12V, APFC, 24 pin, 1x 4+4 pin CPU, 7 шт SATA, 2x 6+2 pin PCI-E", 450, 3899),
                new PowerSupply("be quiet! SYSTEM POWER 9 400W","400 Вт, 80+ Bronze, EPS12V, APFC, 20+4 pin, 1x 4+4 pin CPU, 5 шт SATA, 2x 6+2 pin PCI-E", 400, 4250),
                new PowerSupply("be quiet! Pure Power 11 300W","300 Вт, 80+ Bronze, EPS12V, APFC, 20+4 pin, 1x 4+4 pin CPU, 4 шт SATA, 1x 6+2 pin PCI-E", 300, 4699)
            };

            _powersupply.Add("Deepcool", powerSuppliesDeepList);
            _powersupply.Add("Other", powerSuppliesOtherList);
        }
    }
}
