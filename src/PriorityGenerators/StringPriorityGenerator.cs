using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semB.src.PriorityGenerators
{
    internal class StringPriorityGenerator : IPriorityGenerator<string>
    {
        Random rand = new();
        public string Next()
        {
            return rand.Next().ToString();
        }
    }
}
