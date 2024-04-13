using semB.src.Experiments.Treep;
using semB.src.Experiments;
using semB.src.Treep;

Treap<int, int> treap = new();
bool exit = false;

while (!exit)
{
    Console.WriteLine("Choose an action:");
    Console.WriteLine("1 - Insert key and priority");
    Console.WriteLine("2 - Delete key");
    Console.WriteLine("3 - Find key");
    Console.WriteLine("4 - Display tree");
    Console.WriteLine("5 - Get tree height");
    Console.WriteLine("6 - Run experiments");
    Console.WriteLine("0 - Exit");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Enter key:");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter priority:");
            int priority = Convert.ToInt32(Console.ReadLine());
            treap.Insert(key, priority);
            break;
        case "2":
            Console.WriteLine("Enter key to delete:");
            key = Convert.ToInt32(Console.ReadLine());
            treap.Delete(key);
            break;
        case "3":
            Console.WriteLine("Enter key to find:");
            key = Convert.ToInt32(Console.ReadLine());
            var node = treap.Find(key);
            Console.WriteLine(node != null ? $"Found: {node.Key}" : "Not found");
            break;
        case "4":
            treap.DisplayTree();
            break;
        case "5":
            int height = treap.GetHeight();
            Console.WriteLine($"Tree height: {height}");
            break;
        case "6":
            SelectAndRunExperiment();
            break;
        case "0":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid choice, please try again.");
            break;
    }
}

static void SelectAndRunExperiment()
{
    bool back = false;

    while (!back)
    {
        Console.WriteLine("Select an experiment to run:");
        Console.WriteLine("1 - Basic Experiments");
        Console.WriteLine("2 - City Names Experiment");
        Console.WriteLine("3 - Statistic Experiment");
        Console.WriteLine("4 - Binary Search Tree Experiments");
        Console.WriteLine("0 - Back to main menu");

        string experimentChoice = Console.ReadLine();

        switch (experimentChoice)
        {
            case "1":
                var basicExperiment = new BasicExperiments();
                BasicExperiments.Experiment();
                break;
            case "2":
                var cityNamesExperiment = new CityNamesExperiment();
                CityNamesExperiment.Experiment();
                break;
            case "3":
                var statisticExperiment = new StatisticExperiment();
                StatisticExperiment.Experiment();
                break;
            case "4":
                var binarySearchTreeExperiments = new BinarySearchTreeExperiments();
                BinarySearchTreeExperiments.Experiment();
                break;
            case "0":
                back = true;
                break;
            default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
        }
    }
}

