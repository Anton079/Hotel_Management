using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Hotel.model
{
    public class Room
    {
        private string _type;
        private int _id;
        private bool _available;
        private string _reservedDuring;
        private int _reservedTo;
        private int _price;
        private string _description;

        public Room(string type, int id, bool available, string reservedDuring, int reservedTo, int price, string description)
        {
            _type = type;
            _id = id;
            _available = available;
            _reservedDuring = reservedDuring;
            _reservedTo = reservedTo;
            _price = price;
            _description = description;
        }

        public Room(string properties)
        {
            string[] token = properties.Split(',');

            _type = token[0];
            _id = int.Parse(token[1]);
            _available = bool.Parse(token[2]);
            _reservedDuring = token[3];
            _reservedTo = int.Parse(token[4]);
            _price = int.Parse(token[5]);
            _description = token[6];
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool Available
        {
            get { return _available; }
            set { _available = value; }
        }

        public string ReservedDuring
        {
            get { return _reservedDuring; }
            set { _reservedDuring = value; }
        }

        public int ReservedTo
        {
            get { return _reservedTo; }
            set { _reservedTo = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string RoomInfo()
        {
            string text = " ";

            text += "Type: " + Type + '\n';
            text += "Id: " + Id + "\n";
            text += "Available: " + Available + "\n";
            text += "Reserved During " + ReservedDuring + "\n";
            text += "Reserved To: " + ReservedTo + "\n";
            text += "Price " + Price + "\n";
            text += "Description: " + Description + "\n";
            return text;
        }

        public string ToSave()
        {
            return Type + "," + Id + "," + Available + "," + ReservedDuring + "," + ReservedTo + "," + Price + "," + Description;
        }

    }
}
