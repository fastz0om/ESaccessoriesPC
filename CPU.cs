using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESaccessoriesPC
{
    public class CPU : Complementary
    {
        //Частота 
        private double _frequance;

        public double Frequance
        {
            get { return _frequance; }
            set { _frequance = value; }
        }


        public CPU(string name, string description, int cost, string manufacturer = "") : base(name, description, cost, manufacturer)
        {
        }
    }
}
