using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Hotel.model;
using Management_Hotel.service;

namespace Management_Hotel
{
    public class OwnerView
    {
        private ServicePerson servicePerson;
        private ServiceRoom serviceRoom;

        public OwnerView(ServicePerson servicePerson, ServiceRoom serviceRoom)
        {
            this.servicePerson = servicePerson;
            this.serviceRoom = serviceRoom;
        }

        public void Meniu()
        {
            Console.WriteLine("Apasa tasta 1 pentru a vedea toti angajatii tai");
            Console.WriteLine("Apasa tasta 2 pentru a vedea toti clientii tai");
            Console.WriteLine("Apasa tasta 3 pentru a adauga un angajat");
        }

        public void play()
        {
            bool running = true;
            while (running)
            {
                Meniu();
                string alegere = Console.ReadLine();

                switch (alegere)
                {
                    case "1":
                        AfisareAllEmployers();
                        break;

                    case "2":
                        AfisareAllCustomers();
                        break;

                    case "3":
                        AddStaff();
                        break;

                    case "4":
                        
                        break;

                }
            }

        }

        public void AfisareAllEmployers()
        {
           Console.WriteLine($"Acestia sunt toti angajatii tai: {servicePerson.AfisareEmployers}");
        }

        public void AfisareAllCustomers()
        {
            Console.WriteLine($"Acestia sunt toti clientii tai: {servicePerson.AfisareCustomers}");
        }

        public void AddStaff()
        {
            string type = "Staff";

            int id = servicePerson.GenerateId();

            Console.WriteLine("Care este numele full al angajatului?");
            string staffName = Console.ReadLine();

            Console.WriteLine("Care o sa fie mail?");
            string mailStaff = Console.ReadLine();

            Console.WriteLine("Care o sa fie parola?");
            string passwordStaff = Console.ReadLine();

            int moneyCollected = ' ';


            Staff newStaff = new Staff(type, id, staffName, mailStaff, passwordStaff, moneyCollected);

            servicePerson.AddPerson(newStaff);
            servicePerson.SaveData();

        }

        
    }
}
