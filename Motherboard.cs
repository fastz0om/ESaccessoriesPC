using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESaccessoriesPC
{
    public class Motherboard : Complementary
    {
        public Motherboard(string name, string description, int cost, string manufacturer = "") : base(name, description, cost, manufacturer)
        {
        }
    }
}
