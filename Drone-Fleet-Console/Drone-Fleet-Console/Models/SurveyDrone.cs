using Drone_Fleet_Console.Models.Interfaces;

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

        public void TakePhoto(out string? message)
        {
            message = null;
            if (!isAirborne)
            {
                message = "Cannot take photo: Drone is not airborne. Please take off!";
                return;
            }
            PhotoCount++;
            message = $"Photo taken. Total photos: {PhotoCount}";
            BatteryPercentage -= 5;
        }

        public override void GetActions()
        {
            Console.WriteLine($"Actions for {Name}:");
            Console.WriteLine("1. Take Photo");
        }
        public override void PerformAction(int? option = null)
        {
            string? message = null;
            switch (option)
            {
                case 1:
                    TakePhoto(out message);
                    break;
                default:
                    message = "Invalid action for Survey Drone.";
                    break;
            }
            Console.WriteLine(message);
        }
    }
}
