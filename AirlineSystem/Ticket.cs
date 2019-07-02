using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    internal class Ticket
    {
        private TicketClass _ticketClass;
        private int _price;
        private int _flightNumber;
        public int GetPrice() => _price;
               

        public Ticket(TicketClass ticketClass, int price, int flightNumber)
        {
            _ticketClass = ticketClass;
            _price = price;
            _flightNumber = flightNumber;
        }

    }
    public enum TicketClass
    {
        Business,
        Economy
    }
}
