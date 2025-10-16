Console.WriteLine("== Drone Fleet ==");

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
int option = int.Parse(Console.ReadLine());

while(option!=8)
{
    switch (option)
    {
        case 1:
            {
                //this si where the drones will be listed
                break;
            }
        case 2:
            {
                Console.Write("Type (Survey/Delivery/Racing): ");
                string type = Console.ReadLine();
                //this is where we will call the factory i guess
                break;
            }
        case 3:
            {
                // this is where the pre-flight check happens battery should be <20% done in the Class, the asbtract classs should have battery

                break;
            }
        case 4:
            {
                // take off/land a selected drone
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
    Console.Write("Enter an option: ");
    option = int.Parse(Console.ReadLine());

}

