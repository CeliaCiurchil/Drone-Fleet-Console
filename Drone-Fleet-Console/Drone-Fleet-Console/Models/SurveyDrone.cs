using Drone_Fleet_Console.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Fleet_Console.Models
{
    public class SurveyDrone : Drone, IPhotoCapture, INavigable
    {
        public int PhotoCount { get; private set; }
        public Coordinates? CurrentWaypoint { get; private set; }

        public SurveyDrone() : base()
        {
            PhotoCount = 0;
            Name = "Survey Drone " + DroneId;
        }

        public void SetWaypoint(Coordinates coordinates)
        {
            CurrentWaypoint = coordinates;
        }

        public void TakePhoto()
        {
            if (!isAirborne)
            {
                Console.WriteLine("Cannot take photo: Drone is not airborne. Please take off!");
                return;
            }
            PhotoCount++;
            Console.WriteLine($"Photo taken. Total photos: {PhotoCount}");
            BatteryPercentage -= 5;
        }

        public override void GetActions()
        {
            Console.WriteLine($"Actions for {Name}:");
            Console.WriteLine("1. Take Photo");
        }
        public override void PerformAction(int? option = null)
        {
            switch (option)
            {
                case 1:
                    TakePhoto();
                    break;
                default:
                    Console.WriteLine("Invalid action for Survey Drone.");
                    break;
            }
        }
    }
}
