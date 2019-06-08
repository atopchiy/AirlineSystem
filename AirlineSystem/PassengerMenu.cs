using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    class PassengerMenu : IMenuCreate
    {
        public string CreateMenuOptions()
        {
            var menuOptions = new StringBuilder();
            menuOptions.AppendLine("1.Add new passenger").
                AppendLine("2.Edit passenger").
                AppendLine("3.Delete passenger").
                AppendLine("4.Search passenger by first or last name").
                AppendLine("5.Search passenger by flight number").
                AppendLine("6.SSearch passenger by passport");
            return menuOptions.ToString();
        }

        public bool StartMenu()
        {
            throw new NotImplementedException();
        }
    }
}
