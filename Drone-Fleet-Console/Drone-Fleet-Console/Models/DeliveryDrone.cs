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

        public bool Load(double kg, out string? message)
        {
            message = null;
            if (kg <= 0 || kg + CurrentLoadKg > CapacityKg)
            {
                message = "Cannot load cargo: exceeds capacity or invalid weight.";
                return false;
            }
            CurrentLoadKg += kg;
            message = $"Loaded {kg} kg. Current load: {CurrentLoadKg} kg.";
            BatteryPercentage -= 15; 
            return true;
        }
        public void UnloadAll(out string? message)
        {
            message = null;
            CurrentLoadKg = 0;
            message="All cargo unloaded. Current load: 0 kg.";
            BatteryPercentage -= 15;
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
            string? message = null;
            switch (option)
            {
                case 1:
                    Console.Write("Enter weight to load (kg): ");
                    if (double.TryParse(Console.ReadLine(), out double loadWeight))
                    {
                        Load(loadWeight, out message);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("Invalid weight input.");
                    }
                    break;
                case 2:
                    UnloadAll(out message);
                    Console.WriteLine(message);
                    break;
                default:
                    Console.WriteLine("Invalid action for Delivery Drone.");
                    break;
            }
        }
    }
}
