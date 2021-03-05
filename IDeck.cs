using System.Collections.Generic;

namespace Uppgift4
{
    public interface IDeck
    {
        int[] Order { get; set; }
        int[] Value { get; set; }
        string Face { get; set; }
    }
}