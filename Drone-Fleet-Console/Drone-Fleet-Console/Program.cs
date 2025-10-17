using Drone_Fleet_Console.Models;
using Drone_Fleet_Console.Services;

//to move to a drone fleet manager class later
FleetManager fleetManager = new FleetManager();

Console.WriteLine("== Drone Fleet ==");

void PrintMenu()
{
    Console.WriteLine("""
        1. List drones
        2. Add drone
        3. Pre-flight check
        4. Take off / Land
        5. Set waypoint
        6. Capability actions
        7. Charge battery
        8. Exit
    """);
    Console.Write("Enter an option: ");
}

PrintMenu();

int option = int.Parse(Console.ReadLine());

while(option!=8)
{
    switch (option)
    {
        case 1:
            {
                //this si where the drones will be listed
                fleetManager.DisplayDrones();
                break;
            }
        case 2:
            {
                Console.Write("Type (Survey/Delivery/Racing): ");
                string type = Console.ReadLine();
                Enum.TryParse(type, out DroneType droneType);

                fleetManager.AddDrone(droneType);
                break;
            }
        case 3:
            {
                // this is where the pre-flight check happens battery should be <20% done in the Class, the asbtract classs should have battery
                fleetManager.TestDrones();
                break;
            }
        case 4:
            {
                // take off/land a selected drone
                Console.Write("Enter drone id: ");
                int droneId = int.Parse(Console.ReadLine());

                Drone? drone = fleetManager.GetDroneById(droneId);
                if (drone != null)
                {
                    if (drone.isAirborne)
                    {
                        drone.Land();
                    }
                    else
                    {
                        drone.TakeOff();
                    }
                }
                break;
            }
        case 5:
            {
                // set waypoint for a selected drone (lat , lon)

                break;
            }
        case 6:
            {
                // capability actions based on type of drones
                Console.Write("Enter drone id: ");
                int droneId = int.Parse(Console.ReadLine());

                Drone? drone = fleetManager.GetDroneById(droneId);
                if (drone != null)
                {
                    drone.GetActions();
                    int droneOption = int.Parse(Console.ReadLine());
                    drone.PerformAction(droneOption);
                }
                break;
            }
        case 7:
            {
                // charge battery of a selected drone in the fleet
                break;
            }
        default:
            {
                Console.WriteLine("Invalid option");
                break;
            }
    }
    PrintMenu();
    option = int.Parse(Console.ReadLine());

}

