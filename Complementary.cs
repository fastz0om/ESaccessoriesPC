using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESaccessoriesPC
{
    public abstract class Complementary
    {
        //Производитель 
        private string _manufacturer;

        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }


        //Название 
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Описание 
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        //Стоимость
        private int _cost;
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public Complementary(string name, string description, int cost, string manufacturer = "")
        {
            _name = name;
            _description = description;
            _cost = cost;
        }


        public Complementary()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Complementary complementary))
                return false;

            return Name.Equals(complementary.Name) && Description.Equals(complementary.Description)
                    && Cost.Equals(complementary.Cost);
        }


        public bool Equals(Complementary obj)
        {
            return Name.Equals(obj.Name) && Description.Equals(obj.Description)
                    && Cost.Equals(obj.Cost);
        }
    }
}
