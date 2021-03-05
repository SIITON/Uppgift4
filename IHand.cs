using System.Collections.Generic;

namespace Uppgift4
{
    public interface IHand
    {
        List<int> Values { get; set; }
        List<string> Faces { get; set; }
    }
}