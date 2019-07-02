using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    internal class Passenger: IPrintable, IParseble<Passenger>
    {
        private string _firstName;
        private string _lastName;
        private string _nationality;
        private string _passport;
        private DateTime _birthday;
        private string _sex;
        private Ticket _ticket;
        public string GetName() => _firstName + " " + _lastName;
        public void SetTicket(Ticket ticket) => _ticket = ticket ?? new Ticket(TicketClass.Economy, 0, 0);
        public string GetPassport() => _passport;
        public Passenger(string firstName, string lastName, string nationality, string passport, DateTime birthday, string sex)
        {
            _firstName = firstName;
            _lastName = lastName;
            _nationality = nationality;
            _passport = passport;
            _birthday = birthday;
            _sex = sex;

        }
        public Passenger()
        {

        }

        public void Print()
        {
            Console.WriteLine($"Passenger name: {_firstName} {_lastName}\t Nationality: {_nationality}\t Passport: {_passport}\t " +
                $"Birthday: {_birthday}\t Sex: {_sex}");
        }
        public Passenger ParseInput()
        {
            Passenger passenger = null;
            Console.WriteLine("Enter first name: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter nationality: ");
            var nationality = Console.ReadLine();
            Console.WriteLine("Enter passport: ");
            var passport = Console.ReadLine();
            Console.WriteLine("Enter birthday: ");
            DateTime birthday = new DateTime();
            try
            {
                birthday = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong date format...");
                return passenger;
            }
            Console.WriteLine("Enter sex: ");
            var sex = Console.ReadLine();
            
            passenger = new Passenger(firstName, lastName, nationality, passport, birthday, sex);
            Console.WriteLine("Does passenger have a ticket?");
            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.WriteLine("Enter ticket class: ");
                TicketClass ticket;
                bool ticketResult = Enum.TryParse(Console.ReadLine(), out ticket);
                Console.WriteLine("Enter ticket price: ");
                int price;
                bool priceResult = int.TryParse(Console.ReadLine(), out price);
                Console.WriteLine("Enter ticket flight number: ");
                int flightNumber;
                bool numberResult = int.TryParse(Console.ReadLine(), out flightNumber);
                if (ticketResult && priceResult)
                    passenger.SetTicket(new Ticket(ticket, price, flightNumber));
                else
                {
                    Console.WriteLine("Incorrect ticket input!");
                    return passenger;
                }
            }
            return passenger;
        }
    }
}
