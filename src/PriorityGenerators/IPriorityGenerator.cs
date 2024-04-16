using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semB.src.PriorityGenerators
{
    internal interface IPriorityGenerator<P>
    {
        public P Next();
    }
}
