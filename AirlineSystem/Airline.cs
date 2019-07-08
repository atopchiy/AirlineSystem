using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlineSystem
{
    internal class Airline
    {
        private Flight[] _flights;
        public Flight[] GetFlights() => _flights;
        public Airline(Flight [] flights)
        {
            _flights = flights;
        }
        public Airline() { }
        public void PrintFlightsNoPassenger()
        {
            int count = 0;
            foreach (var flight in _flights)
                if (flight.GetPassengers() == null)
                {
                    flight.Print();
                    count++;
                }
            if (count == 0)
                Console.WriteLine("All flights have passengers..");
            Console.ReadKey();
        }
        public void PrintFlightsPassengers(int flightNumber)
        {
            foreach (var flight in _flights)
                if (flight.GetFlightNumber() == flightNumber)
                    flight.PrintPassenges();
            Console.ReadKey();
        }
        public void PrintEconomTickets(int ticketPrice)
        {
            foreach (var flight in _flights)
                if (flight.GetEconomyPrice() < ticketPrice)
                    flight.Print();
            Console.ReadKey();
        }
        public void SearchPassenger(string searchParam, string paramType)
        {
            switch (paramType)
            {
                case "name":
                    SearchPassByName(searchParam);
                    break;
                case "passport":
                    SearchPassByPassport(searchParam);
                    break;
                case "flightNumber":
                    SearchPassByFlightNumber(int.Parse(searchParam));
                    break;
            }
        }
        private void SearchPassByName(string name)
        {
            int counter = 0;
            foreach(var flight in _flights)
            foreach (var passenger in flight.GetPassengers())
                if (passenger.GetName().Contains(name))
                {
                    passenger.Print();
                    counter++;
                }
            if (counter == 0)
                Console.WriteLine("No passengers found");
            Console.ReadKey();
        }
        private void SearchPassByFlightNumber(int number)
        {
            int counter = 0;
            foreach (var flight in _flights)
                if (flight.GetFlightNumber() == number)
                {
                    flight.PrintPassenges();
                    counter++;
                }
            if (counter == 0)
                Console.WriteLine("No passengers found");
            Console.ReadKey();
        }
        private void SearchPassByPassport(string passport)
        {
            int counter = 0;
            foreach (var flight in _flights)
                foreach (var passenger in flight.GetPassengers())
                if (passenger.GetPassport().Contains(passport))
                {
                    passenger.Print();
                    counter++;
                }
            if (counter == 0)
                Console.WriteLine("No passengers found");
            Console.ReadKey();
        }
        public void AddFlight(Flight flight)
        {
            if (flight != null)
            {
                var tempFlights = new Flight[_flights.Length + 1];
                for (int i = 0; i < _flights.Length; i++)
                    tempFlights[i] = _flights[i];
                tempFlights[_flights.Length] = flight;
                _flights = tempFlights;
            }
            Console.WriteLine("Flight has been added");
            Console.ReadKey();
        }
       
        public void RemoveFlight(int number)
        {
            _flights = _flights.Where(val => val.GetFlightNumber() != number).ToArray();
            Console.WriteLine("Flight has been removed!");
            Console.ReadKey();
        }
        public void EditFlight(int flightNumber, Flight flight)
        {
            for (var i = 0; i < _flights.Length; i++)
                if (_flights[i].GetFlightNumber() == flightNumber)
                    _flights[i] = flight;
            Console.WriteLine("Flight has been edited");
            Console.ReadKey();
        }
       
        public Airline CreateTestDataAirline()
        {
            Passenger[] passengers = {new Passenger("Frank", "Blakc", "brazilian", "AAdsafsdgsg", DateTime.Now, "Male")
                    ,  new Passenger("Tinky", "Winky", "mexican", "wrvsdsd21", DateTime.Now, "Female")};
            passengers[0].SetTicket(new Ticket(TicketClass.Economy, 1000, 10));
            passengers[1].SetTicket(new Ticket(TicketClass.Economy, 10000, 20));
            Flight[] flights = { new Flight(10, "New York", "A", "4", FlightType.Arrival, FlightStatus.GateClosed, DateTime.Now, 100),
                new Flight(20, "Paris", "B", "4", FlightType.Departure, FlightStatus.CheckIn, DateTime.Now, 60)};
            flights[0].AddPassenger(passengers[0]);
            flights[1].AddPassenger(passengers[1]);
            return new Airline(flights);
        }
    }
}
