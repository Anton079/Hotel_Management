using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Hotel.model
{
    public class Owner : Person
    {
        private string _feedback;

        public Owner(string type, int id, string fullName, string mail, string password, string feedback) : base(type, id, fullName, mail, password)
        {
            _feedback = feedback;
        }

        public Owner(string proprietati) : base(proprietati)
        {
            string[] token = proprietati.Split(',');

            _feedback = token[0];
        }

        public string FeedBack
        {
            get { return _feedback; }
            set { _feedback = value; }
        }

        public override string PersonInfo()
        {
            string text = base.PersonInfo();

            text += "FeedBack " + FeedBack + "\n";
            return text;
        }

        public override string ToSave()
        {
            return base.ToSave() + "," + FeedBack;
        }
    }
}
