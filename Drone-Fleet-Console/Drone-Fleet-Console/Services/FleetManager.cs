using Drone_Fleet_Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Fleet_Console.Services
{
    internal class FleetManager
    {
        List<Drone> droneFleet;

        public FleetManager()
        {
            droneFleet = new List<Drone>();
        }
        public void AddDrone(DroneType droneType)
        {
            Drone drone = DroneFactory.GetDrone(droneType);
            droneFleet.Add(drone);
            Console.WriteLine($"Added {drone.Name} with ID {drone.DroneId}");
        }
        public Drone? GetDroneById(int droneId)
        {
            foreach (var drone in droneFleet)
            {
                if (drone.DroneId == droneId)
                {
                    return drone;
                }
            }
            throw new ArgumentException($"Drone with ID {droneId} not found.");
        }
        public void DisplayDrones()
        {
            foreach (var drone in droneFleet)
            {
                drone.DisplayDrone();
            }

            if (droneFleet.Count == 0)
            {
                Console.WriteLine("No drones in your fleet");
            }

        }

        public void TestDrones()
        {
            foreach (var drone in droneFleet)
            {
                bool ok = drone.RunSelfTest();
                string message = ok ? "Pass" : "Fail";
                Console.WriteLine($"Drone ID {drone.DroneId} Pre-flight check: {message}");
            }
        }

    }
}
