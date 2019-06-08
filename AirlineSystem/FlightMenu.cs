using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    class FlightMenu : IMenuCreate
    {
        public string CreateMenuOptions()
        {
            var menuOptions = new StringBuilder();
            menuOptions.AppendLine("1.View all flights without passengers").
                AppendLine("2.View all certain flight's passengers").
                AppendLine("3.Add new flight").
                AppendLine("4.Delete flight").
                AppendLine("5.Edit flight").
                AppendLine("6.Search flights that are suitable for user's price");
            return menuOptions.ToString();
        }

        public bool StartMenu()
        {
            Console.WriteLine(CreateMenuOptions());
            return true;
        }
    }
}
