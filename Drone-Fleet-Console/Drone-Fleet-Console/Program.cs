using Drone_Fleet_Console.Models;
using Drone_Fleet_Console.Models.Interfaces;
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
    try
    {
        switch (option)
        {
            case 1:
                {
                    fleetManager.DisplayDrones();
                    break;
                }
            case 2:
                {
                    Console.Write("Type (Survey/Delivery/Racing): ");
                    string? type = Console.ReadLine();
                    if (!Enum.TryParse(type, true, out DroneType droneType))
                    {
                        throw new ArgumentException($"Invalid drone type: '{type}'. Please enter Survey, Delivery, or Racing.");
                    }
                    fleetManager.AddDrone(droneType);
                    break;
                }
            case 3:
                {
                    fleetManager.TestDrones();
                    break;
                }
            case 4:
                {
                    // take off/land a selected drone
                    Console.Write("Enter drone id: ");
                    if(!int.TryParse(Console.ReadLine(), out int droneId))
                    {
                        throw new ArgumentException($"Invalid type. Please enter a valid ID.");
                    }

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
                    Console.Write("Enter drone id: ");
                    int droneId = int.Parse(Console.ReadLine());

                    Drone? drone = fleetManager.GetDroneById(droneId);

                    if (drone != null)
                    {
                        if (drone is INavigable navigableDrone)
                        {
                            Console.Write("Enter latitude: ");
                            double latitude = double.Parse(Console.ReadLine());
                            Console.Write("Enter longitude: ");
                            double longitude = double.Parse(Console.ReadLine());
                            Coordinates coordinates = new Coordinates(latitude, longitude);
                            navigableDrone.SetWaypoint(coordinates);
                            Console.WriteLine($"Waypoint set to ({latitude}, {longitude}) for Drone ID {drone.DroneId}");
                        }
                        else
                        {
                            Console.WriteLine("This drone type does not support navigation.");
                        }
                    }
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
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

