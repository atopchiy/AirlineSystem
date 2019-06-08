using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    class Flight : IPrintable
    {
        private int _flightNumber;
        private string _city;
        private string _terminal;
        private string _gate;
        private FlightType _flightType;
        private FlightStatus _flightStatus;
        private DateTime _flightTime;
        private Passenger[] _passengers;
        public Passenger[] GetPassengers() => _passengers;
        public int GetFlightNumber() => _flightNumber;
        public Flight(int flightNumber, string city, string terminal, string gate, FlightType flightType, FlightStatus flightStatus,
            DateTime flightTime, Passenger[] passengers)
        {
            _flightNumber = flightNumber;
            _city = city;
            _terminal = terminal;
            _gate = gate;
            _flightType = flightType;
            _flightStatus = flightStatus;
            _flightTime = flightTime;
            _passengers = passengers;

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
                passenger.Print();
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
