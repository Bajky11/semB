using semB.src.Treep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semB.src.Experiments.Treep
{
    internal class BasicExperiments
    {
        public static void Experiment()
        {
            Console.WriteLine("EXPERIMENT: ADDITION");
            NNDSA_Addition();
            Console.WriteLine("\n\nEXPERIMENT: DELETION");
            NNDSA_Deletion();
        }

        private static void NNDSA_Deletion()
        {
            Treap<string, int> treep = new();
            treep.Insert("G", 40);
            treep.Insert("E", 69);
            treep.Insert("X", 50);
            treep.Insert("B", 77);
            treep.Insert("F", 84);
            treep.Insert("M", 67);
            treep.Insert("Z", 90);
            treep.Insert("A", 99);
            treep.Insert("C", 79);
            treep.Insert("K", 70);
            treep.Insert("P", 72);

            var removedNode = treep.Delete("G");
            Console.WriteLine(removedNode.ToString()) ;

            treep.DisplayTree();
        }

        private static void NNDSA_Addition()
        {
            Treap<string, int> treep = new();
            treep.Insert("G", 4);
            treep.Insert("B", 7);
            treep.Insert("A", 10);
            treep.Insert("E", 23);
            treep.Insert("H", 5);
            treep.Insert("K", 65);
            treep.Insert("I", 73);

            treep.Insert("C", 25);
            treep.Insert("D", 9);
            treep.Insert("F", 2);

            treep.DisplayTree();
        }
    }
}
