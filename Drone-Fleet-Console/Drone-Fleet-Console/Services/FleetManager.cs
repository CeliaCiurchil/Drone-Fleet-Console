using DroneFleetConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetConsole.Services
{
    public class FleetManager
    {
        private List<Drone> droneFleet;

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
            if (droneFleet.Count == 0)
            {
                Console.WriteLine("No drones in your fleet");
                return;
            }

            foreach (var drone in droneFleet)
            {
                drone.DisplayDrone();
            }
        }

        public void TestDrones()
        {
            if (droneFleet.Count == 0)
            {
                Console.WriteLine("No drones to test.");
                return;
            }

            foreach (var drone in droneFleet)
            {
                bool ok = drone.RunSelfTest();
                string message = ok ? "Pass" : "Fail";
                Console.WriteLine($"Drone ID {drone.DroneId} Pre-flight check: {message}");
            }
        }
    }
}
