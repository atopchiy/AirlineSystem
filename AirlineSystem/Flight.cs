using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlineSystem
{
    internal class Flight : IPrintable, IParseble<Flight>
    {
        private int _flightNumber;
        private string _city;
        private string _terminal;
        private string _gate;
        private FlightType _flightType;
        private FlightStatus _flightStatus;
        private int _economyTicketPrice;
        private DateTime _flightTime;
        private Passenger[] _passengers;
        public Passenger[] GetPassengers() => _passengers;

        public int GetEconomyPrice() => _economyTicketPrice;
        public int GetFlightNumber() => _flightNumber;
        public Flight(int flightNumber, string city, string terminal, string gate, FlightType flightType, FlightStatus flightStatus,
            DateTime flightTime, int economyTicketPrice)
        {
            _flightNumber = flightNumber;
            _city = city;
            _terminal = terminal;
            _gate = gate;
            _flightType = flightType;
            _flightStatus = flightStatus;
            _flightTime = flightTime;
            _economyTicketPrice = economyTicketPrice;
            

        }
        public Flight()
        {

        }

        public void Print()
        {
            Console.WriteLine($"Flight number: {_flightNumber}\t City: {_city}\t Terminal: {_terminal}\t Flight type: {_flightType}" +
                $"\nFlight status: {_flightStatus}\t Flight time: {_flightTime}\t");
        }
        public void PrintPassenges()
        {
            foreach (var passenger in _passengers)
                passenger?.Print();
        }

        public Flight ParseInput()
        {
            Flight flight = null;
            Console.WriteLine("Enter flight number: ");
            int number = 0;
            bool result = int.TryParse(Console.ReadLine(), out number);
            Console.WriteLine("Enter city: ");
            var city = Console.ReadLine();
            Console.WriteLine("Enter terminal: ");
            var terminal = Console.ReadLine();
            Console.WriteLine("Enter gate: ");
            var gate = Console.ReadLine();
            Console.WriteLine("Enter flight type: ");
            FlightType type;
            bool typeResult = Enum.TryParse(Console.ReadLine(), out type);
            Console.WriteLine("Enter flight status: ");
            FlightStatus status;
            bool statusResult = Enum.TryParse(Console.ReadLine(), out status);
            Console.WriteLine("Enter economy ticket price: ");
            int price = 0;
            bool priceResult = int.TryParse(Console.ReadLine(), out price);
            DateTime flightTime = new DateTime();
            Console.WriteLine("Enter date: ");
            try
            {
                flightTime = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong date format...");
                return flight;
            }
            if (result && typeResult && statusResult && priceResult)
            {
                flight = new Flight(number, city, terminal, gate, type, status, flightTime, price);
                Console.WriteLine("Flight succesfully added!");
                return flight;
            }
            else
            {
                Console.WriteLine("Some data was in incorrect format, please try again");
                return flight;
            }
        }
        public void AddPassenger(Passenger passenger)
        {
            if (_passengers == null)
                if (passenger != null)
                {
                    _passengers = new Passenger[] { passenger };
                    return;
                }
            if (passenger != null)
            {
                var tempPassenger = new Passenger[_passengers.Length + 1];
                for (int i = 0; i < _passengers.Length; i++)
                    tempPassenger[i] = _passengers[i];
                tempPassenger[_passengers.Length] = passenger;
                _passengers = tempPassenger;
            }
        }
        public void EditPassenger(string passport, Passenger passenger)
        {
            for (var i = 0; i < _passengers.Length; i++)
                if (_passengers[i].GetPassport() == passport)
                    _passengers[i] = passenger;
            Console.WriteLine("Passenger has been edited");
            Console.ReadKey();
        }
        public void RemovePassenger(string passport)
        {
            _passengers = _passengers.Where(val => val.GetPassport() != passport).ToArray();
            Console.WriteLine("Passenger has been removed");
            Console.ReadKey();
        }
    }
    public enum FlightType
    {
        Arrival,
        Departure
    }
    public enum FlightStatus
    {
        CheckIn,
        GateClosed,
        Arrived,
        DepartedAt,
        Unknown,
        CanceledAt,
        ExpectedAt,
        Delayed,
        InFlight
    }
}
