using semB.src.Treep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semB.src.Experiments.Treep
{
    internal class CityNamesExperiment
    {

        public static void Experiment()
        {
            Console.WriteLine("\n\nEXPERIMENT: MUNICIPALITY KEYS");
            MunicipalityKeysExperiment();
        }

        private static void MunicipalityKeysExperiment()
        {
            Treap<string, int> treep = new Treap<string, int>();
            Console.WriteLine("Municipality Keys Experiment: Insertion\n");
            // Vkládání obcí s unikátními klíči
            string[] municipalities = new string[] { "Praha", "Brno", "Ostrava", "Plzeň", "Liberec", "Olomouc", "Žamberk", "Náchod", "Jaroměř", "Pardubice" };
            int value = 1;
            foreach (var municipality in municipalities)
            {
                Console.WriteLine("Inserted: " + municipality + "\n");
                treep.Insert(municipality, value++);
                treep.DisplayTree(10); // Zobrazit strom po každém vložení
                Console.WriteLine("-----------------------------------------------------------");
            }

            Console.WriteLine("Municipality Keys Experiment: Deletion\n");
            // Příklady mazání
            treep.Delete("Plzeň");
            treep.DisplayTree(10); // Zobrazit strom po mazání
            Console.WriteLine("-----------------------------------------------------------");

            // Doplnit další operace podle potřeby...
        }
    }
}
