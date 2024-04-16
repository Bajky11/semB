using semB.src.PriorityGenerators;
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
            Console.WriteLine("\n\nEXPERIMENT S MĚSTY");
            MunicipalityKeysExperiment();
        }

        private static void MunicipalityKeysExperiment()
        {
            Treap<string, int> treap = new Treap<string, int>(new IntPriorityGenerator());

            string[] cities = ["Praha", "Brno", "Ostrava", "Plzeň", "Liberec", "Olomouc", "Žamberk", "Náchod", "Jaroměř", "Pardubice"];
            foreach (var city in cities)
            {
                Console.WriteLine("Inserted: " + city + "\n");
                treap.Insert(city);
                Console.WriteLine("Height: " + treap.GetHeight());
                treap.DisplayTree(10);
                Console.WriteLine("-----------------------------------------------------------");
            }
            Console.WriteLine("Experiment: Find Plzeň\n");
            var uzel = treap.Find("Plzeň");
            Console.WriteLine(uzel != null ? $"Nalezeno: {uzel}" : "Nenalezeno");
            Console.WriteLine("-----------------------------------------------------------");

            Console.WriteLine("Experiment: Deletion of Plzeň\n");
            treap.Delete("Plzeň");
            Console.WriteLine("Height: " + treap.GetHeight());
            treap.DisplayTree(10);
            Console.WriteLine("-----------------------------------------------------------");

            Console.WriteLine("Experiment: Find Plzeň\n");
            uzel = treap.Find("Plzeň");
            Console.WriteLine(uzel != null ? $"Nalezeno: {uzel}" : "Nenalezeno");
            Console.WriteLine("-----------------------------------------------------------");

            Console.WriteLine("Experiment: Deletion of Náchod\n");
            treap.Delete("Náchod");
            Console.WriteLine("Height: " + treap.GetHeight());
            treap.DisplayTree(10);
            Console.WriteLine("-----------------------------------------------------------");

            Console.WriteLine("Experiment: Deletion of Brno\n");
            treap.Delete("Brno");
            Console.WriteLine("Height: " + treap.GetHeight());
            treap.DisplayTree(10);
            Console.WriteLine("-----------------------------------------------------------");
        }
    }
}
