using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drone_Fleet_Console.Models.Interfaces;

namespace Drone_Fleet_Console.Models
{
    public class DeliveryDrone : Drone, ICargoCarrier, INavigable
    {
        public required double CapacityKg { get; init; }
        public double CurrentLoadKg { get; private set; }
        public Coordinates? CurrentWaypoint { get; private set; }

        [SetsRequiredMembers]
        public DeliveryDrone(double capacityKg) : base()
        {
            Name = "Delivery Drone" + DroneId;
            CapacityKg = capacityKg;
        }

        public bool Load(double kg)
        {
            if (kg <= 0 || kg + CurrentLoadKg > CapacityKg)
            {
                Console.WriteLine("Cannot load cargo: exceeds capacity or invalid weight.");
                return false;
            }
            CurrentLoadKg += kg;
            Console.WriteLine($"Loaded {kg} kg. Current load: {CurrentLoadKg} kg.");
            return true;
        }
        public void UnloadAll()
        {
            CurrentLoadKg = 0;
            Console.WriteLine("All cargo unloaded. Current load: 0 kg.");
        }
        public void SetWaypoint(Coordinates coordinates)
        {
            CurrentWaypoint = coordinates;
        }

        public override void GetActions()
        {
            Console.WriteLine("Actions for Delivery Drone:");
            Console.WriteLine("1. Load Cargo");
            Console.WriteLine("2. Unload Cargo");
        }
        public override void PerformAction(int? option = null)
        {
            switch (option)
            {
                case 1:
                    Console.Write("Enter weight to load (kg): ");
                    if (double.TryParse(Console.ReadLine(), out double loadWeight))
                    {
                        Load(loadWeight);
                    }
                    else
                    {
                        Console.WriteLine("Invalid weight input.");
                    }
                    break;
                case 2:
                    UnloadAll();
                    break;
                default:
                    Console.WriteLine("Invalid action for Delivery Drone.");
                    break;
            }
        }
    }
}
