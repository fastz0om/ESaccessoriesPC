using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESaccessoriesPC
{
    public class Cooling : Complementary
    {
        public Cooling(string name, string description, int cost, string manufacturer = "") : base(name, description, cost, manufacturer)
        {
        }
    }
}
