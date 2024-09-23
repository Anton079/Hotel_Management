using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Hotel.model
{
    public class Staff : Person
    {
        private int _moneyCollected;


        public Staff(string type, int id, string fullName, string mail, string password, int moneyCollected) : base(type, id, fullName, mail, password)
        {
            _moneyCollected = moneyCollected;
        }

        public Staff(string proprietati) : base(proprietati)
        {
            string[] token = proprietati.Split(',');

            _moneyCollected = int.Parse(token[5]);
        }

        public int MoneyCollected
        {
            get { return _moneyCollected; }
            set { _moneyCollected = value; }
        }


        public override string PersonInfo()
        {
            string text = base.PersonInfo();

            text += "Money Collected " + MoneyCollected + "\n";
            return text;
        }

        public override string ToSave()
        {
            return base.ToSave() + "," + MoneyCollected;
        }
    }
}
