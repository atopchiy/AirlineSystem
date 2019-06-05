using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    class Ticket
    {
        private TicketClass _ticketClass;
        private string _price;
        public Ticket(TicketClass ticketClass, string price)
        {
            _ticketClass = ticketClass;
            _price = price;
        }
        public Ticket()
        {

        }
    }
    public enum TicketClass
    {
        Business,
        Economy
    }
}
