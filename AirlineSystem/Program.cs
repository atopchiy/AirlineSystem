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
              
                Passenger[] passengers = {new Passenger("Frank", "Blakc", "brazilian", "AAdsafsdgsg", DateTime.Now, "Male")
                    ,  new Passenger("Tinky", "Winky", "mexican", "wrvsdsd21", DateTime.Now, "Female")};
                passengers[0].SetTicket(new Ticket(TicketClass.Economy, 1000, 10));
                passengers[1].SetTicket(new Ticket(TicketClass.Economy, 10000, 20));
                Flight[] flights = { new Flight(10, "New York", "A", "4", FlightType.Arrival, FlightStatus.GateClosed, DateTime.Now, 100),
                new Flight(20, "Paris", "B", "4", FlightType.Departure, FlightStatus.CheckIn, DateTime.Now, 60)};
                flights[0].AddPassenger(passengers[0]);
                flights[1].AddPassenger(passengers[1]);
                Airline airline = new Airline(flights, passengers);
                if (input == "1")
                {
                    FlightMenu flightMenu = new FlightMenu(airline);
                    airline = flightMenu.StartMenu();
                }
                else if(input == "2")
                {
                    PassengerMenu passengerMenu = new PassengerMenu(airline);
                    airline = passengerMenu.StartMenu();
                }
                else if(input == "3")
                {
                    exit = true;
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
