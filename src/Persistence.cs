using semB.src.PriorityGenerators;
using semB.src.Treep;
using System;
using System.IO;
using System.Threading;

namespace semB.src
{
    internal class Persistence<K, P> where K : IComparable<K> where P : IComparable<P>
    {
        private static readonly string UserDataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "userData");

        static Persistence()
        {
            if (!Directory.Exists(UserDataDirectory))
            {
                Directory.CreateDirectory(UserDataDirectory);
            }
        }

        public static void LoadTreapFromFile(Treap<K, P> treap)
        {
            try
            {
                Console.WriteLine($"Soubory ve složce {UserDataDirectory}:");
                string[] files = Directory.GetFiles(UserDataDirectory);
                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }

                Console.WriteLine("Zadejte název souboru pro načtení:");
                string fileName = Console.ReadLine();
                string filePath = Path.Combine(UserDataDirectory, fileName);

                if (File.Exists(filePath))
                {
                    treap.LoadFromFile(filePath);
                }
                else
                {
                    Console.WriteLine("Soubor neexistuje.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba: {ex.Message}");
            }
        }

        public static void SaveTreapToFile(Treap<K, P> treap)
        {
            try
            {
                Console.WriteLine("Zadejte název souboru pro uložení:");
                string fileName = Console.ReadLine();
                string filePath = Path.Combine(UserDataDirectory, fileName);

                treap.SaveToFile(filePath);

                Console.WriteLine("Soubor byl úspěšně uložen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba: {ex.Message}");
            }
        }
    }
}
