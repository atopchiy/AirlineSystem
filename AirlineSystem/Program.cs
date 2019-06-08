using System;

namespace AirlineSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            while (!exit)
            {
                Console.WriteLine("Type operation number and press Enter");
                Console.WriteLine("1.Manage flights\n 2.Manage passengers");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    FlightMenu flightMenu = new FlightMenu();
                    flightMenu.StartMenu();
                }
                else if(input == "2")
                {
                    PassengerMenu passengerMenu = new PassengerMenu();
                    passengerMenu.StartMenu();
                }
                else
                {
                    Console.WriteLine("You've entered incorrect symbol!");
                    continue;
                }


            }
        }
    }
}
