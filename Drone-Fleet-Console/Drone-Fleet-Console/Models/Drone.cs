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
        public static readonly int MinBatteryForTakeOff = 20;
        public Drone()
        {
            DroneId = s_nextDroneId++;
            BatteryPercentage = 100;
            isAirborne = false;
        }
        static Drone()
        {
            Random rand = new Random();
            s_nextDroneId = rand.Next(1000, 9999);
        }
        public int DroneId { get; }
        public string? Name { get; set; }
        public int BatteryPercentage { get; set; }
        public bool isAirborne { get; private set; }
        static int s_nextDroneId = 1;

        public void TakeOff()
        {
            if (isAirborne)
            {
                Console.WriteLine("Drone is already airborne.");
                return;
            }
            if (RunSelfTest() == false)
            {
                Console.WriteLine("Pre-flight check failed. Cannot take off.");
                return;
            }
            isAirborne = true;
            Console.WriteLine($"Drone {Name} is flying.");
        }

        public void Land()
        {
            if(!isAirborne)
            {
                Console.WriteLine("Drone is already on the ground.");
                return;
            }
            isAirborne = false;
            Console.WriteLine($"Drone {Name} has landed successfully.");
        }

        public bool RunSelfTest()
        {
            return BatteryPercentage >= MinBatteryForTakeOff;
        }
        public void DisplayDrone()
        {
            Console.WriteLine($"Drone ID: {DroneId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Battery: {BatteryPercentage}%");
            Console.WriteLine($"Status: {(isAirborne ? "In Air" : "On Ground")}");
        }

        public bool Charge(int addPercent)
        {
            if (addPercent < 0 || addPercent > 100)
            {
                Console.WriteLine("Charge amount must be between 0 and 100.");
                return false;
            }

            // Safety: don’t allow charging while airborne
            if (isAirborne)
            {
                Console.WriteLine("Cannot charge while airborne. Please land first.");
                return false;
            }

            if (BatteryPercentage >= 100)
            {
                Console.WriteLine($"{Name} is already at 100%.");
                return false;
            }

            int before = BatteryPercentage;
            // Clamp to 100
            BatteryPercentage = Math.Min(100, BatteryPercentage + addPercent);

            Console.WriteLine($"{Name} charged from {before}% to {BatteryPercentage}%.");
            return true;
        }


        internal abstract void GetActions();
        internal virtual void PerformAction(int? option = null)
        {
            Console.WriteLine("No actions available for this drone type.");
        }
    }
}
