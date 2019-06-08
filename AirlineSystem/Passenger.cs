using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    class Passenger: IPrintable
    {
        private string _firstName;
        private string _lastName;
        private string _nationality;
        private string _passport;
        private DateTime _birthday;
        private string _sex;
        private Ticket _ticket;
        public Passenger(string firstName, string lastName, string nationality, string passport, DateTime birthday, string sex,
            Ticket ticket)
        {
            _firstName = firstName;
            _lastName = lastName;
            _nationality = nationality;
            _passport = passport;
            _birthday = birthday;
            _sex = sex;
            _ticket = ticket ?? new Ticket();
        }
        public Passenger()
        {

        }

        public void Print()
        {
            Console.WriteLine($"Passenger name: {_firstName} {_lastName}\t Nationality: {_nationality}\t Passport: {_passport}\t " +
                $"Birthday: {_birthday}\t Sex: {_sex}");
        }
    }
}
