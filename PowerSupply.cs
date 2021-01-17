using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESaccessoriesPC
{
    public class PowerSupply : Complementary
    {

        private int _power;

        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }

        public PowerSupply(string name, string description, int cost, string manufacturer = "") : base(name, description, cost, manufacturer)
        {
        }

        public PowerSupply(string name, string description, int power, int cost)
        {
            base.Name = name;
            base.Description = description;
            base.Cost = cost;
            Power = power;
        }
    }
}
