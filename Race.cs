using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public List<Car> ParticipantsCars { get; set; } = new List<Car>();

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count(List<Car> participants)
        {
            int count = participants.Count;
            return count;
        }

        public void Add(Car car)
        {
            if (ParticipantsCars.Count < Capacity   
                && ParticipantsCars.All(x => x.LicensePlate != car.LicensePlate   
                && car.HorsePower <= MaxHorsePower))
            {
                ParticipantsCars.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {

            foreach (var item in ParticipantsCars)
            {
                if (ParticipantsCars.Exists(X => X.LicensePlate == licensePlate))
                {
                    ParticipantsCars.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            foreach (var item in ParticipantsCars.Where(X => X.LicensePlate == licensePlate))
            {
                return item;
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (ParticipantsCars.Count == 0)
            {
                return null;
            }
            var result = ParticipantsCars.OrderByDescending(x => x.HorsePower).First();

            return result;
        }

        public override string ToString()
        {
            string a = $"Race: {Name} - Type: {Type} (Laps: {Laps})";
            string v = $"{Environment.NewLine}";
            string b = $"{string.Join($"{Environment.NewLine}", ParticipantsCars)}";
            string c = a + v + b;
            return c;
        }
        public string Report()
        {
            return ToString();
        }
    }
}
