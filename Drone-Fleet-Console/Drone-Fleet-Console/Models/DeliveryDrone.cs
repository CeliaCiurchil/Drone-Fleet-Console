using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drone_Fleet_Console.Models.Interfaces;
namespace Drone_Fleet_Console.Models
{
    internal class DeliveryDrone : Drone, ICargoCarrier, INavigable
    {
        public DeliveryDrone() : base()
        {
            Name = "Delivery Drone";
            BatteryPercentage = 100;
            CapacityKg = 5.0;
        }
        public DeliveryDrone(double capacityKg) : base()
        {
            Name = "Delivery Drone";
            BatteryPercentage = 100;
            CapacityKg = capacityKg;
        }

        public double CapacityKg { get; init; }
        public double CurrentLoadKg { get; set; }

        public Coordinates? CurrentWaypoint { get; set; }


        public bool Load(double kg)
        {
            if (kg <= 0 || kg + CurrentLoadKg > CapacityKg)
            {
                return false;
            }
            CurrentLoadKg += kg;
            return true;
        }

        public void SetWaypoint(Coordinates coordinates)
        {
            CurrentWaypoint = coordinates;
        }

        public void UnloadAll()
        {
            CurrentLoadKg = 0;
        }
    }
}
