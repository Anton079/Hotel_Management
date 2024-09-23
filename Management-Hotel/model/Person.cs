using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Hotel.model
{
    public class Person
    {
        private string _type;
        private int _id;
        private string _fullName;
        private string _mail;
        private string _password;

        public Person(string type, int id, string fullName, string mail, string password)
        {
            _type = type;
            _id = id;
            _fullName = fullName;
            _mail = mail;
            _password = password;
        }

        public Person(string proprietati)
        {
            string[] token = proprietati.Split(',');

            _type = token[0];
            _id = int.Parse(token[1]);
            _fullName = token[2];
            _mail = token[3];
            _password = token[4];
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

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public virtual string PersonInfo()
        {
            string text = " ";

            text += "Type " + Type + '\n';
            text += "Id " + Id + "\n";
            text += "Full Name " + FullName + "\n";
            text += "Mail " + Mail + "\n";
            text += "Password " + Password + "\n";
            return text;
        }

        public virtual string ToSave()
        {
            return Type + "," + Id + "," + FullName + "," + Mail + "," + Password;
        }
    }
}
