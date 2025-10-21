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


int option=0; 

while(option!=8)
{
    try
    {
        PrintMenu();
        if(!int.TryParse(Console.ReadLine(), out option))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            continue;
        }   

        if(option == 8)
        {
            break;
        }

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
                        Console.WriteLine($"Invalid drone type: '{type}'. Please enter Survey, Delivery, or Racing.");
                        continue;
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
                        Console.WriteLine($"Invalid type. Please enter a valid ID.");
                        continue;
                    }

                    Drone? drone = fleetManager.GetDroneById(droneId);
                    if (drone.isAirborne) drone.Land();
                    else drone.TakeOff();
                    
                    break;
                }
            case 5:
                {
                    // set waypoint for a selected drone (lat , lon)
                    Console.Write("Enter drone id: ");
                    if (!int.TryParse(Console.ReadLine(), out int droneId))
                    {
                        Console.WriteLine($"Invalid type. Please enter a valid ID.");
                        continue;
                    }
                    Drone? drone = fleetManager.GetDroneById(droneId);

                    if (drone is INavigable navigableDrone)
                    {
                        Console.Write("Enter latitude: ");
                        string? latInput = Console.ReadLine();
                        if (!double.TryParse(latInput, out double latitude))
                        {
                            Console.WriteLine("Invalid latitude. Please enter a valid number.");
                            break;
                        }

                        Console.Write("Enter longitude: ");
                        string? lonInput = Console.ReadLine();
                        if (!double.TryParse(lonInput, out double longitude))
                        {
                            Console.WriteLine("Invalid longitude. Please enter a valid number.");
                            break;
                        }

                        Coordinates coordinates = new Coordinates(latitude, longitude);
                        navigableDrone.SetWaypoint(coordinates);
                        Console.WriteLine($"Waypoint set to ({latitude}, {longitude}) for Drone ID {drone.DroneId}");
                    }
                    else
                    {
                        Console.WriteLine("This drone type does not support navigation.");
                    }

                    break;
                }
            case 6:
                {
                    // capability actions based on type of drones
                    Console.Write("Enter drone id: ");
                    if(!int.TryParse(Console.ReadLine(),out int droneId))
                    {
                        Console.WriteLine("Invalid drone ID. Please enter a valid number.");
                        continue;
                    }

                    Drone? drone = fleetManager.GetDroneById(droneId);
                    drone.GetActions();
                    if(!int.TryParse(Console.ReadLine(), out int droneOption))
                    {
                        Console.WriteLine("Invalid option. Please enter a valid number.");
                    }
                    drone.PerformAction(droneOption);
                    break;
                }
            case 7:
                {
                    Console.Write("Enter drone id: ");
                    if (!int.TryParse(Console.ReadLine(), out int droneId))
                    {
                        Console.WriteLine("Invalid drone ID. Please enter a valid number.");
                        continue;
                    }
                    Drone? drone = fleetManager.GetDroneById(droneId);
                    Console.Write("Chraging drone...(Enter Percent): ");
                    if (!int.TryParse(Console.ReadLine(), out int batteryPercent))
                    {
                        Console.WriteLine("Invalid batteryPercent. Please enter a valid number.");
                        continue;
                    }
                    drone!.Charge(batteryPercent);
                    break;
                }
            default:
                {
                    Console.WriteLine("Invalid option");
                    break;
                }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Press to continue");
        Console.ReadLine();
        Console.Clear();
    }
}

