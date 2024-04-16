using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semB.src.PriorityGenerators
{
    internal class IntPriorityGenerator : IPriorityGenerator<int>
    {
        Random rand = new();
        public int Next()
        {
            return rand.Next();
        }
    }
}
