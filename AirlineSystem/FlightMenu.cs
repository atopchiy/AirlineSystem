using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    class FlightMenu : IMenuCreate
    {
        Airline _airline;
        public FlightMenu(Airline airline)
        {
            _airline = airline;
        }
        public string CreateMenuOptions()
        {
            var menuOptions = new StringBuilder();
            menuOptions.AppendLine("1.View all flights without passengers").
                AppendLine("2.View all certain flight's passengers").
                AppendLine("3.Add new flight").
                AppendLine("4.Delete flight").
                AppendLine("5.Edit flight").
                AppendLine("6.Search flights that are suitable for user's price").
                AppendLine("7.Exit to main menu");
            return menuOptions.ToString();
        }

        public Airline StartMenu()
        {
            
            bool exit = false;
            var options = CreateMenuOptions();
            while (!exit)
            {
                Console.WriteLine(options);
                var chosenOption = Console.ReadLine();
                switch (chosenOption)
                {
                    case "1": _airline.PrintFlightsNoPassenger();
                        break;
                    case "2": Console.WriteLine("Print flight's number: ");
                        _airline.PrintFlightsPassengers(int.Parse(Console.ReadLine()));
                        break;
                    case "3":
                        _airline.AddFlight(new Flight().ParseInput());
                        break;
                    case "4":
                        Console.WriteLine("Enter a flight number to delete: ");
                        _airline.RemoveFlight(int.Parse(Console.ReadLine()));
                        break;
                    case "5":
                        Console.WriteLine("Enter a flight number to edit: ");
                        int number = int.Parse(Console.ReadLine());
                        _airline.EditFlight(number, new Flight().ParseInput());
                        break;
                    case "6":
                        Console.WriteLine("Enter a sum, that is maximum, that you can spend: ");
                        _airline.PrintEconomTickets(int.Parse(Console.ReadLine()));
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input!");
                        break;
                }
            }
            return _airline;
        }
    }
}
