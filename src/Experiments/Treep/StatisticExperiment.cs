using semB.src.Treep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semB.src.Experiments.Treep
{
    internal class StatisticExperiment
    {
        private static readonly Random random = new Random();
        private const int NumberOfExperiments = 10000;
        private const int NumberOfElementsInTree = 1023;

        public static void Experiment()
        {
            var heights = new List<int>();
            for (int i = 0; i < NumberOfExperiments; i++)
            {
                heights.Add(ExperimentImplementation());
            }

            // Statistické zpracování
            double averageHeight = heights.Average();
            int maxHeight = heights.Max();
            int minHeight = heights.Min();
            int modeHeight = heights.GroupBy(v => v)
                                    .OrderByDescending(g => g.Count())
                                    .First().Key;
            var cumulativeAverages = heights.Select((height, index) => heights.Take(index + 1).Average()).ToList();

            Console.WriteLine($"Průměr: {averageHeight}, Max: {maxHeight}, Min: {minHeight}, Modus: {modeHeight}");
            // Kumulativní průměry mohou být velké, zde zobrazíme pouze prvních 10 pro demonstraci
            Console.WriteLine("Prvních 10 kumulativních průměrů:");
            cumulativeAverages.Take(10).ToList().ForEach(avg => Console.WriteLine(avg));
        }

        private static int ExperimentImplementation()
        {
            var treap = new Treap<int, int>(); // Předpokládá implementaci Treapu
            for (int i = 0; i < NumberOfElementsInTree; i++)
            {
                int key = random.Next();
                int priority = random.Next();
                treap.Insert(key, priority);
            }
            return treap.GetHeight(); // Tuto metodu musíte přidat do vaší Treap třídy
        }
    }
}
