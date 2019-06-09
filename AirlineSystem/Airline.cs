using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirlineSystem
{
    class Airline
    {
        private Flight[] _flights;
        private Passenger[] _passengers;
        public Flight[] GetFlights() => _flights;
        public Airline(Flight [] flights, Passenger [] passengers)
        {
            _flights = flights;
            _passengers = passengers;
        }
        public Airline()
        {

        }
        public void PrintFlightsNoPassenger()
        {
            int count = 0;
            foreach (var flight in _flights)
                if (flight.GetPassengers().First() == null)
                {
                    flight.Print();
                    count++;
                }
            if (count == 0)
                Console.WriteLine("All flights have passengers..");
        }
        public void PrintFlightsPassengers(int flightNumber)
        {
            foreach (var flight in _flights)
                if (flight.GetFlightNumber() == flightNumber)
                    flight.PrintPassenges();
        }
        public void PrintEconomTickets(int ticketPrice)
        {
            foreach (var flight in _flights)
                if (flight.GetEconomyPrice() < ticketPrice)
                    flight.Print();
        }
        public void SearchPassByName(string name)
        {
            foreach (var passenger in _passengers)
                if (passenger.GetName().Contains(name))
                    passenger.Print();
        }
        public void SearchPassByFlightNumber(int number)
        {
            foreach (var flight in _flights)
                if (flight.GetFlightNumber() == number)
                    flight.PrintPassenges();
        }
        public void SearchPassByPassport(string passport)
        {
            foreach (var passenger in _passengers)
                if (passenger.GetPassport().Contains(passport))
                    passenger.Print();
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
        }
        public void AddPassenger(Passenger passenger)
        {
            if (passenger != null)
            {
                var tempPassenger = new Passenger[_passengers.Length + 1];
                for (int i = 0; i < _passengers.Length; i++)
                    tempPassenger[i] = _passengers[i];
                tempPassenger[_passengers.Length] = passenger;
                _passengers = tempPassenger;
            }
        }
        public void RemoveFlight(int number)
        {
            _flights = _flights.Where(val => val.GetFlightNumber() != number).ToArray();
        }
        public void EditFlight(int flightNumber, Flight flight)
        {
            for (var i = 0; i < _flights.Length; i++)
                if (_flights[i].GetFlightNumber() == flightNumber)
                    _flights[i] = flight;
        }
        public void EditPassenger(string passport, Passenger passenger)
        {
            for (var i = 0; i < _passengers.Length; i++)
                if (_passengers[i].GetPassport() == passport)
                    _passengers[i] = passenger;
        }
        public void RemovePassenger(string passport)
        {
            _passengers = _passengers.Where(val => val.GetPassport() != passport).ToArray();
        }
    }
}
