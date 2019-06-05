using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    class Flight
    {
        private int _flightNumber;
        private string _city;
        private string _terminal;
        private string _gate;
        private FlightType _flightType;
        private FlightStatus _flightStatus;
        private DateTime _flightTime;
        private List<Passenger> _passengers;
        public Flight(int flightNumber, string city, string terminal, string gate, FlightType flightType, FlightStatus flightStatus,
            DateTime flightTime, List<Passenger> passengers)
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
