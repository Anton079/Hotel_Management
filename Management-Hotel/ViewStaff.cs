using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Hotel.model;
using Management_Hotel.service;

namespace Management_Hotel
{
    public class ViewStaff
    {
        private ServicePerson servicePerson;
        private ServiceRoom serviceRoom;

        public ViewStaff(ServicePerson servicePerson, ServiceRoom serviceRoom)
        {
            this.servicePerson = servicePerson;
            this.serviceRoom = serviceRoom;
        }

        public void Meniu()
        {
            Console.WriteLine("Apasa tasta 1 pentru a vedea toate camerele inchiriate");
            Console.WriteLine("Apasa tasta 2 pentru a vedea toate camerele libere");
            Console.WriteLine("Apasa tasta 3 pentru a elibera o camera");
            Console.WriteLine("Apasa tasta 4 pentru a adauga o camera");
            Console.WriteLine("Apasa tasta 5 pentru a scoate o camera");
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
                        serviceRoom.whichIsNotAvailable();
                        break;

                    case "2":
                        AfisareRoomsAvailable();
                        break;

                    case "3":
                        ReleaseARoom();
                        break;

                    case "4":
                        AddRoom();
                        break;

                    case "5":
                        RemoveRoom();
                        break;
                }
            }

        }

        public void AfisareRoomsAvailable()
        {
            Console.WriteLine($"Toate camerele disponibile sunt: {serviceRoom.whichIsAvailable()}");
        }

        public void ReleaseARoom()
        {
            Console.WriteLine("Ce camera vrei sa eliberezi");
            int idRoom = Int32.Parse(Console.ReadLine());

            serviceRoom.ReleaseRoom(idRoom);

            Console.WriteLine("camera a fost eliberata");
        }

        public void AddRoom()
        {
            Console.WriteLine("Introdu tipul camerei");
            string type = Console.ReadLine();

            Console.WriteLine("Introdu id camerei");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Este camera disponibilă? (true/false)");
            bool available = bool.Parse(Console.ReadLine());

            Console.WriteLine("Este rezerata in perioada");
            string reservedDuring = Console.ReadLine();

            Console.WriteLine("Camera este rezervată oamenilor");
            int reservedTo = int.Parse(Console.ReadLine());

            Console.WriteLine("Introdu prețul camerei:");
            int price = int.Parse(Console.ReadLine());

            Console.WriteLine("Introdu descrierea camerei:");
            string description = Console.ReadLine();

            Room newRoom = new Room(type, id, available, reservedDuring, reservedTo, price, description);

            serviceRoom.AddRoom(newRoom);
            serviceRoom.SaveData();

        }

        public void RemoveRoom()
        {
            Console.WriteLine("Ce camera vrei sa stergi?");
            int idRoom = int.Parse(Console.ReadLine());

            serviceRoom.RemoveRoom(idRoom);
        }
    }
}
