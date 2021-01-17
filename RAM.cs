﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESaccessoriesPC
{
    public class RAM : Complementary
    {
        //Частота 
        private int _memory;

        public int Memory
        {
            get { return _memory; }
            set { _memory = value; }
        }

        public RAM(string name, string description, int cost, string manufacturer = "") : base(name, description, cost, manufacturer)
        {
        }

        public RAM(string name, string description, int memory, int cost)
        {
            base.Name = name;
            base.Description = description;
            base.Cost = cost;
            Memory = memory;
        }


    }
}
