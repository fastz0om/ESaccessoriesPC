using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESaccessoriesPC
{
    public class GraphicsCard : Complementary
    {
        public GraphicsCard(string name, string description, int cost, string manufacturer = "") : base(name, description, cost, manufacturer)
        {
        }
    }
}
