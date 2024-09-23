using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Hotel.model;

namespace Management_Hotel.service
{
    public class ServicePerson
    {
        private List<Person> _services;
        private ServiceRoom _roomService;

        public ServicePerson()
        {
            _services = new List<Person>();
            _roomService = new ServiceRoom();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetFilePath()))
                {
                    string line = " ";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string type = line.Split(',')[0];

                        switch (type)
                        {
                            case "Staff": _services.Add(new Staff(line)); break;

                            case "Customer": _services.Add(new Customer(line)); break;

                            default: break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDirectory, "data");

            string file = Path.Combine(folder, "Person");

            return file;
        }

        public string ToSaveAll()
        {
            string save = "";

            for (int i = 0; i < _services.Count; i++)
            {
                save += _services[i].ToSave();

                if (i < _services.Count - 1)
                {
                    save += "\n";
                }
            }

            return save;
        }

        public void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetFilePath()))
                {
                    sw.WriteLine(ToSaveAll());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //CRUD

        public void AfisareEmployers()
        {
            foreach (Staff person in _services)
            {
                Console.WriteLine(person.PersonInfo());
            }
        }

        public void AfisareCustomers()
        {
            foreach (Customer person in _services)
            {
                Console.WriteLine(person.PersonInfo());
            }
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 10000000);

            while (FindPersonById(id) != -1)
            {
                id = rand.Next(1, 10000000);
            }


            return id;
        }

        public int FindPersonById(int idWanted)
        {
            for (int i = 0; i < _services.Count; i++)
            {
                if (_services[i].Id == idWanted)
                {
                    return _services[i].Id;
                }
            }
            return -1;
        }

        public int FindPersonByIdWithObject(Person person)
        {
            for (int i = 0; i < _services.Count; i++)
            {
                if (_services[i].Id == person.Id)
                {
                    return _services[i].Id;
                }
            }
            return -1;
        }

        public bool AddPerson(Person newPerson)
        {
            if (FindPersonById(newPerson.Id) == -1)
            {
                _services.Add(newPerson);
                return true;
            }
            return false;
        }



    }
}
