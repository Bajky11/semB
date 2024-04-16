using semB.src.PriorityGenerators;
using System;

namespace semB.src.Treep
{


    class Treap<K, P> : IEnumerable<Treap<K, P>.Node>, ITreap<K> where K : IComparable<K> where P : IComparable<P>
    {
        private class Node
        {
            public K Key { get; set; }
            public P Priority { get; set; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            public Node(K key, P priority)
            {
                Key = key;
                Priority = priority;
                Left = null;
                Right = null;
            }

            public override string ToString()
            {
                var leftKey = Left?.Key.ToString() ?? "null";
                var rightKey = Right?.Key.ToString() ?? "null";
                return $"{leftKey} <-({Key}:{Priority})-> {rightKey}";
            }
        }

        private Node? Root { get; set; } // Kořenový uzel stromu
        private IPriorityGenerator<P> PriorityGenerator;

        public Treap(IPriorityGenerator<P> generator)
        {
            Root = null;
            PriorityGenerator = generator;
        }

        // Metoda pro vkládání uzlu do stromu
        private void Insert(K key, P priority)
        {
            Root = InsertRecursive(Root, key, priority);
        }

        // Metoda pro vkládání uzlu do stromu
        public void Insert(K key)
        {
            Root = InsertRecursive(Root, key, PriorityGenerator.Next());
        }

        // Rekurzivní pomocná metoda pro vkládání uzlu
        private Node InsertRecursive(Node node, K key, P priority)
        {
            if (node == null) return new Node(key, priority); // Vytvoření nového uzlu, pokud je místo prázdné

            int comparison = key.CompareTo(node.Key); // Porovnání klíčů
            if (comparison < 0)
            {
                node.Left = InsertRecursive(node.Left, key, priority); // Vložení do levého podstromu
                // Rotace doprava, pokud je priorita menší
                if (node.Left.Priority.CompareTo(node.Priority) < 0) node = RotateRight(node);
            }
            else if (comparison > 0)
            {
                node.Right = InsertRecursive(node.Right, key, priority); // Vložení do pravého podstromu
                // Rotace doleva, pokud je priorita menší
                if (node.Right.Priority.CompareTo(node.Priority) < 0) node = RotateLeft(node);
            }
            return node; // Vrácení upraveného uzlu
        }

        // Rotace uzlu doprava
        private Node RotateRight(Node node)
        {
            Node temp = node.Left; // Uložení levého potomka
            node.Left = temp.Right; // Přesun pravého potomka levého uzlu na místo původního uzlu
            temp.Right = node; // Nastavení původního uzlu jako pravého potomka
            return temp; // Vrácení nového kořenového uzlu
        }

        // Rotace uzlu doleva
        private Node RotateLeft(Node node)
        {
            Node temp = node.Right; // Uložení pravého potomka
            node.Right = temp.Left; // Přesun levého potomka pravého uzlu na místo původního uzlu
            temp.Left = node; // Nastavení původního uzlu jako levého potomka
            return temp; // Vrácení nového kořenového uzlu
        }

        // Metoda pro vyhledávání uzlu podle klíče
        public object Find(K key)
        {
            return FindRecursive(Root, key);
        }

        // Rekurzivní pomocná metoda pro vyhledávání
        private Node FindRecursive(Node node, K key)
        {
            if (node == null) return null; // Vrácení null, pokud uzel není nalezen

            int comparison = key.CompareTo(node.Key); // Porovnání klíčů
            if (comparison == 0) return node; // Nalezení uzlu
            else if (comparison < 0) return FindRecursive(node.Left, key); // Vyhledávání v levém podstromu
            else return FindRecursive(node.Right, key); // Vyhledávání v pravém podstromu
        }

        // Metoda pro odstranění uzlu
        public object Delete(K key)
        {
            Node deletedNode;
            Root = DeleteRecursive(Root, key, out deletedNode);
            return deletedNode;
        }

        // Rekurzivní pomocná metoda pro odstranění uzlu
        private Node DeleteRecursive(Node node, K key, out Node deletedNode)
        {
            deletedNode = null;
            if (node == null) return null;

            int comparison = key.CompareTo(node.Key);
            if (comparison < 0) node.Left = DeleteRecursive(node.Left, key, out deletedNode);
            else if (comparison > 0) node.Right = DeleteRecursive(node.Right, key, out deletedNode);
            else
            {
                // Případ, kdy je třeba uzel odstranit
                deletedNode = node;
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                // Vybere se potomek s vyšší prioritou pro rotaci
                if (node.Left.Priority.CompareTo(node.Right.Priority) < 0)
                {
                    node = RotateRight(node);
                    node.Right = DeleteRecursive(node.Right, key, out _);
                }
                else
                {
                    node = RotateLeft(node);
                    node.Left = DeleteRecursive(node.Left, key, out _);
                }
            }
            return node;
        }

        // Metoda která vrací výšku stromu
        public int GetHeight()
        {
            return GetHeightRecursive(Root);
        }

        // Rekurzivní pomocná metoda pro výpočet výšky stromu
        private int GetHeightRecursive(Node node)
        {
            if (node == null) return 0; // Výška neinicializovaného stromu je 0
            //if (node.Left == null && node.Right == null) return 1; // Výška stromu s jediným uzlem je 1

            int leftHeight = GetHeightRecursive(node.Left);
            int rightHeight = GetHeightRecursive(node.Right);

            // Výpočet maximální výšky mezi levým a pravým podstromem a přidání 1 pro aktuální uzel
            return 1 + Math.Max(leftHeight, rightHeight);
        }


        // Metoda pro zobrazení stromu
        public void DisplayTree(int? spacing = 5)
        {
            DisplayTreeRecursive(Root, 0, "none", spacing);
        }

        // Rekurzivní pomocná metoda pro vizualizaci stromu
        private void DisplayTreeRecursive(Node node, int space, string direction, int? spacing)
        {
            if (node == null) return; // Pokud uzel neexistuje, ukončí se rekurze

            space += spacing.HasValue ? spacing.Value : 5; // Zvýšení odsazení pro vizualizaci
            DisplayTreeRecursive(node.Right, space, "left", spacing); // Rekurze pro pravý podstrom

            // Vytisknutí uzlu s odsazením a směrem
            Console.WriteLine(new string(' ', space) + (direction == "left" ? "/" : direction == "right" ? "\\" : "-") + node.Key + "(" + node.Priority + ")");
            DisplayTreeRecursive(node.Left, space, "right", spacing); // Rekurze pro levý podstrom
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var node in this)
                {
                    writer.WriteLine($"{node.Key},{node.Priority}");
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                K key = (K)Convert.ChangeType(parts[0], typeof(K));
                P priority = (P)Convert.ChangeType(parts[1], typeof(P));
                Insert(key, priority);
            }
        }

        private IEnumerator<Node> GetEnumerator()
        {
            return InOrderTraversal(Root).GetEnumerator();
        }

        private IEnumerable<Node> InOrderTraversal(Node node)
        {
            if (node != null)
            {
                foreach (var leftNode in InOrderTraversal(node.Left))
                {
                    yield return leftNode;
                }

                yield return node;

                foreach (var rightNode in InOrderTraversal(node.Right))
                {
                    yield return rightNode;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Treap<K, P>.Node> IEnumerable<Treap<K, P>.Node>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

