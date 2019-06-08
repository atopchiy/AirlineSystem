using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    class Airline
    {
        private Flight[] _flights;
        public Airline(Flight [] flights)
        {
            _flights = flights;
        }
        public Airline()
        {

        }
        private void PrintFlightsNoPassenger()
        {
            foreach (var flight in _flights)
                if (flight.GetPassengers().Length == 0)
                    flight.Print();

        }
        private void PrintFlightsPassengers(int flightNumber)
        {
            foreach (var flight in _flights)
                if (flight.GetFlightNumber() == flightNumber)
                    flight.PrintPassenges();
        }
    }
}
