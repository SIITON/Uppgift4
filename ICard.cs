using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift4
{
    public interface ICard
    {
        int Value { get; set; }
        string Face { get; set; }
    }
}
