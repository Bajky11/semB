using semB.src.Experiments.Treep;
using semB.src.Treep;
using semB.src;
using semB.src.PriorityGenerators;

Treap<int, int> treap = new(new IntPriorityGenerator());
bool exit = false;

while (!exit)
{
    Console.WriteLine("Vyberte akci:");
    Console.WriteLine("1 - Vložit klíč");
    Console.WriteLine("2 - Smazat klíč");
    Console.WriteLine("3 - Najít klíč");
    Console.WriteLine("4 - Zobrazit strom");
    Console.WriteLine("5 - Získat výšku stromu");
    Console.WriteLine("6 - Spustit experimenty");
    Console.WriteLine("7 - Načíst ze souboru");
    Console.WriteLine("8 - Uložit do souboru");
    Console.WriteLine("0 - Ukončit");

    string volba = Console.ReadLine();

    switch (volba)
    {
        case "1":
            Console.WriteLine("Zadejte klíč:");
            if (int.TryParse(Console.ReadLine(), out int klic1))
            {
                treap.Insert(klic1);
            }
            else
            {
                Console.WriteLine("Neplatný vstup, očekává se celé číslo.");
            }
            break;
        case "2":
            Console.WriteLine("Zadejte klíč k odstranění:");
            if (int.TryParse(Console.ReadLine(), out int klic2))
            {
                treap.Delete(klic2);
            }
            else
            {
                Console.WriteLine("Neplatný vstup, očekává se celé číslo.");
            }
            break;
        case "3":
            Console.WriteLine("Zadejte klíč k nalezení:");
            if (int.TryParse(Console.ReadLine(), out int klic3))
            {
                var uzel = treap.Find(klic3);
                Console.WriteLine(uzel != null ? $"Nalezeno: {uzel}" : "Nenalezeno");
            }
            else
            {
                Console.WriteLine("Neplatný vstup, očekává se celé číslo.");
            }
            break;
        case "4":
            treap.DisplayTree(10);
            break;
        case "5":
            int vyska = treap.GetHeight();
            Console.WriteLine($"Výška stromu: {vyska}");
            break;
        case "6":
            VybratASpustitExperiment();
            break;
        case "7":
            Persistence<int, int>.LoadTreapFromFile(treap);
            break;
        case "8":
            Persistence<int, int>.SaveTreapToFile(treap);
            break;
        case "0":
            exit = true;
            break;
        default:
            Console.WriteLine("Neplatná volba, zkuste to znovu.");
            break;
    }
}

static void VybratASpustitExperiment()
{
    bool zpet = false;

    while (!zpet)
    {
        Console.WriteLine("Vyberte experiment k provedení:");
        Console.WriteLine("1 - Experiment s názvy měst");
        Console.WriteLine("2 - Statistický experiment");
        Console.WriteLine("0 - Zpět do hlavního menu");

        string volbaExperimentu = Console.ReadLine();

        switch (volbaExperimentu)
        {
            case "1":
                var experimentSNázvyMěst = new CityNamesExperiment();
                CityNamesExperiment.Experiment();
                break;
            case "2":
                var statistickyExperiment = new StatisticExperiment();
                StatisticExperiment.Experiment();
                break;
            case "0":
                zpet = true;
                break;
            default:
                Console.WriteLine("Neplatná volba, zkuste to znovu.");
                break;
        }
    }
}
