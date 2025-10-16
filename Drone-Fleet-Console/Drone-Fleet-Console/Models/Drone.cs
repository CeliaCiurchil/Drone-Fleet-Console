using Drone_Fleet_Console.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Fleet_Console.Models
{
    abstract class Drone : IFlightControl, ISelfTest
    {
        public Drone()
        {
            DroneId = s_nextDroneId++;
        }
        static Drone()
        {
            Random rand = new Random();
            s_nextDroneId = rand.Next(1000, 9999);
        }
        public int DroneId { get; }
        public string? Name { get; set; }
        public int BatteryPercentage { get; set; }
        public bool isAirborne { get; set; }
        static int s_nextDroneId = 1;

        public void TakeOff()
        {
            throw new NotImplementedException();
        }

        public void Land()
        {
            throw new NotImplementedException();
        }

        public bool RunSelfTest()
        {
            throw new NotImplementedException();
        }
    }
}
