using Drone_Fleet_Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Fleet_Console.Services
{
    public class DroneFactory
    {
        internal static Drone GetDrone(DroneType droneType)
        {
            switch (droneType)
            {
                case DroneType.Survey:
                    //return new SurveyDrone();
                    break;
                case DroneType.Delivery:
                    {
                        Console.Write("Enter capacity in kg for Delivery Drone: ");
                        double capacityKg = double.Parse(Console.ReadLine());
                        return new DeliveryDrone(capacityKg);
                    }
                case DroneType.Racing:
                    //return new RacingDrone();
                    break;
                default:
                    throw new ArgumentException("Invalid drone type");
            }
            return null;
        }
    }
}
