using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Hotel.model
{
    public class Customer : Person
    {
        public Customer(string type, int id, string fullName, string mail, string password) : base(type, id, fullName, mail, password)
        {

        }

        public Customer(string proprietati) : base(proprietati)
        {

        }

        public override string PersonInfo()
        {
            string text = base.PersonInfo();
            return text;
        }

        public override string ToSave()
        {
            return base.ToSave();
        }
    }
}
