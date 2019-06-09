using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    class PassengerMenu : IMenuCreate
    {
        Airline _airline;
        public PassengerMenu(Airline airline)
        {
            _airline = airline;
        }
        public string CreateMenuOptions()
        {
            var menuOptions = new StringBuilder();
            menuOptions.AppendLine("1.Add new passenger").
                AppendLine("2.Edit passenger").
                AppendLine("3.Delete passenger").
                AppendLine("4.Search passenger by first or last name").
                AppendLine("5.Search passenger by flight number").
                AppendLine("6.Search passenger by passport").
                AppendLine("7.Exit to main menu");
            return menuOptions.ToString();
        }

        public Airline StartMenu()
        {
            bool exit = false;
            Console.WriteLine(CreateMenuOptions());
            while (!exit)
            {
                var chosenOption = Console.ReadLine();
                switch (chosenOption)
                {
                    case "1":
                        _airline.AddPassenger(new Passenger().ParseInput());
                        break;
                    case "2":
                        Console.WriteLine("Enter a passenger's passport to edit: ");
                        string passport = Console.ReadLine();
                        _airline.EditPassenger(passport, new Passenger().ParseInput());
                        break;
                    case "3":
                        Console.WriteLine("Enter a passenger's passport to delete: ");
                        _airline.RemovePassenger(Console.ReadLine());
                        break;
                    case "4":
                        Console.WriteLine("Enter a passenger's first or last name:  ");
                        _airline.SearchPassByName(Console.ReadLine());
                        break;
                    case "5":
                        Console.WriteLine("Enter a passenger's flight number: ");
                        int number = int.Parse(Console.ReadLine());
                        _airline.SearchPassByFlightNumber(number);
                        break;
                    case "6":
                        Console.WriteLine("Enter a passenger's passport: ");
                       _airline.SearchPassByPassport(Console.ReadLine());
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
