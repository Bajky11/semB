using semB.src.PriorityGenerators;
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
            Console.WriteLine("Prvních 10 kumulativních průměrů:");
            cumulativeAverages.Take(10).ToList().ForEach(avg => Console.WriteLine(avg));
            Console.WriteLine("Všechna výsledná data uložena do souboru statisticExperiment.txt");

            using (StreamWriter writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "userData/statisticExperiment.txt")))
            {
                writer.WriteLine($"Průměr: {averageHeight}, Max: {maxHeight}, Min: {minHeight}, Modus: {modeHeight}");
                foreach (var cumulativeAverage in cumulativeAverages)
                {
                    writer.WriteLine(cumulativeAverage);
                }
            }
        }

        private static int ExperimentImplementation()
        {
            var treap = new Treap<int, int>(new IntPriorityGenerator()); // Předpokládá implementaci Treapu
            for (int i = 0; i < NumberOfElementsInTree; i++)
            {
                int key = random.Next();
                treap.Insert(key);
            }
            return treap.GetHeight(); // Tuto metodu musíte přidat do vaší Treap třídy
        }
    }
}
