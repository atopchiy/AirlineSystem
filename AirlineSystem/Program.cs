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
                Console.WriteLine(" 1.Manage flights\n 2.Manage passengers\n 3.Exit from programm");
                var input = Console.ReadLine();
                var airline = new Airline().CreateTestDataAirline();
                if (input == "1")
                {
                    IMenuCreate flightMenu = new FlightMenu(airline);
                    airline = flightMenu.StartMenu();
                }
                else if(input == "2")
                {
                    IMenuCreate passengerMenu = new PassengerMenu(airline);
                    airline = passengerMenu.StartMenu();
                }
                else if(input == "3")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("You've entered incorrect symbol!");
                }


            }
        }

    }
}
