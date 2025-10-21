using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drone_Fleet_Console.Models.Interfaces;

namespace Drone_Fleet_Console.Models
{
    internal class DeliveryDrone : Drone, ICargoCarrier, INavigable
    {
        [SetsRequiredMembers]
        public DeliveryDrone(double capacityKg) : base()
        {
            Name = "Delivery Drone";
            CapacityKg = capacityKg;
        }

        public required double CapacityKg { get; init; }
        public double CurrentLoadKg { get; private set; }

        public Coordinates? CurrentWaypoint { get; private set; }


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

        public void SetWaypoint(Coordinates coordinates)
        {
            CurrentWaypoint = coordinates;
        }

        public void UnloadAll()
        {
            CurrentLoadKg = 0;
            Console.WriteLine("All cargo unloaded. Current load: 0 kg.");
        }

        internal override void GetActions()
        {
            Console.WriteLine("Actions for Delivery Drone:");
            Console.WriteLine("1. Load Cargo");
            Console.WriteLine("2. Unload Cargo");
        }
        internal override void PerformAction(int? option = null)
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
