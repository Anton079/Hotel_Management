using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Hotel.service;

namespace Management_Hotel
{
    public class ViewCustomer
    {
        private ServicePerson servicePerson;
        private ServiceRoom serviceRoom;

        public ViewCustomer(ServicePerson servicePerson, ServiceRoom serviceRoom)
        {
            this.servicePerson = servicePerson;
            this.serviceRoom = serviceRoom;
        }

        public void Meniu()
        {
            Console.WriteLine("Apasa tasta 1 pentru a vedea toate camere disponibile!");
            Console.WriteLine("Apasa tasta 2 pentru a vedea toate camerele in pretul dorit de tine");
            Console.WriteLine("Apasa tasta 3 pentru a inchiria o camera");
            Console.WriteLine("Apasa tasta 4 pentru a prelungi perioada de inchiriere");
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
                        AfisareRoomsAvailable();
                        break;

                    case "2":
                        AfisareRoomsInYourPrice();
                        break;

                    case "3":
                        RentARoom();
                        break;

                    case "4":
                        RentExtension();
                        break;



                }
            }

        }

        public void AfisareRoomsAvailable()
        {
            Console.WriteLine($"Toate camerele disponibile sunt: {serviceRoom.whichIsAvailable()}");
        }

        public void AfisareRoomsInYourPrice()
        {
            Console.WriteLine("Ce pret doresti?");
            int priceWanted = Int32.Parse(Console.ReadLine());

            serviceRoom.AfisareAllRoomsWithYourPrice(priceWanted);

            
        }

        public void RentARoom()
        {
            Console.WriteLine("Ce camera doresti?");
            int idRoom = Int32.Parse(Console.ReadLine());

            Console.WriteLine("In ce perioada doresti sa inchiriezi?");
            string timeToRent = Console.ReadLine();

            if (serviceRoom.ifRoomAvailable(idRoom))
            {
                serviceRoom.RentRoom(idRoom, 2, timeToRent);
                Console.WriteLine("Camera a fost inchiriata");
            }
            
        }

        public void RentExtension()
        {
            Console.WriteLine("Cand sa fie noua data de inchiriere");
            string newTimeRent = Console.ReadLine();

            serviceRoom.ChangeRentTime(newTimeRent, 1);
        }



    }
}
