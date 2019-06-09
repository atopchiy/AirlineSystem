using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineSystem
{
    interface IParseble<T>
    {
        T ParseInput();
    }
}
