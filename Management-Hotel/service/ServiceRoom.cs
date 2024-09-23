using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Management_Hotel.model;

namespace Management_Hotel.service
{
    public class ServiceRoom
    {
        private List<Room> _rooms;
        private ServicePerson _person;

        public ServiceRoom()
        {
            _rooms = new List<Room>();
            _person = new ServicePerson();
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

            string file = Path.Combine(folder, "Room");

            return file;
        }

        public string ToSaveAll()
        {
            string save = "";

            for (int i = 0; i < _rooms.Count; i++)
            {
                save += _rooms[i].ToSave();

                if (i < _rooms.Count - 1)
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
        public void AfisareRooms()
        {
            foreach (Room x in _rooms)
            {
                Console.WriteLine(x.RoomInfo());
            }
        }

        public void AfisareAllRoomsWithYourPrice(int price)
        {
            foreach (Room x in _rooms)
            {
                if (x.Price == price)
                {
                    Console.WriteLine(x.RoomInfo());
                }
            }
        }

        public int whichIsAvailable()
        {
            int roomAvailable = ' ';

            foreach (Room x in _rooms)
            {
                if (x.Available)
                {
                    roomAvailable += ',' + x.Id;
                }
            }
            if (roomAvailable > 0)
            {
                Console.WriteLine("Nu sunt camere goale!");
            }

            return roomAvailable;
        }

        public int whichIsNotAvailable()
        {
            int roomAvailable = ' ';

            foreach (Room x in _rooms)
            {
                if (!x.Available)
                {
                    roomAvailable += ',' + x.Id;
                }
            }
            if (roomAvailable > 0)
            {
                Console.WriteLine("Nu sunt camere ocupate!");
            }

            return roomAvailable;
        }

        public bool ifRoomAvailable(int idRoom)
        {
            foreach (Room x in _rooms)
            {
                if (x.Available && x.Id == idRoom)
                {
                    return true;
                }
            }
            return false;
        }

        public void RentRoom(int roomId, int idUser, string rentTime)
        {
            foreach (Room x in _rooms)
            {
                if (x.Id == roomId)
                {
                    x.Available = false;
                    x.ReservedTo = idUser;
                    x.ReservedDuring = rentTime;
                }
                else
                {
                    Console.WriteLine("Camera nu a fost gasita sau nu este available");
                }
            }
        }

        public int FindRoomById(int id)
        {
            for (int i = 0; i < _rooms.Count; i++)
            {
                if (_rooms[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public Room FindRoomById2(int id)
        {
            foreach (Room x in _rooms)
            {
                if (x.Id == id)
                {
                    return x;
                }
            }
            return null; ;
        }

        public bool AddRoom(Room newROom)
        {
            if (FindRoomById(newROom.Id) == -1)
            {
                _rooms.Add(newROom);
                return true;
            }
            return false;
        }

        public void ReleaseRoom(int roomId)
        {
            foreach (Room x in _rooms)
            {
                if (x.Id == roomId)
                {
                    x.Available = true;
                }
                else
                {
                    Console.WriteLine("Camera nu a putut fi gasita");
                }
            }
        }

        public void ChangeRentTime(string newTime, int idRoom)
        {
            foreach (Room x in _rooms)
            {
                if (x.Id == idRoom)
                {
                    x.ReservedDuring = newTime;
                }
                else
                {
                    Console.WriteLine("Camera nu a fost gasita");
                }
            }
        }

        public void RemoveRoom(int roomId)
        {
            Room room = FindRoomById2(roomId);

            if (room != null)
            {
                _rooms.Remove(room);
            }
            else
            {
                Console.WriteLine("Camera nu fost gasita");
            }
        }



    }
}
