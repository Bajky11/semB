using System;

namespace semB.src.Treep
{
    class Node<K, P> where K : IComparable<K> where P : IComparable<P>
    {
        public K Key { get; set; } // Klíč uzlu
        public P Priority { get; set; } // Priorita uzlu
        public Node<K, P> Left { get; set; } // Levý potomek
        public Node<K, P> Right { get; set; } // Pravý potomek

        // Konstruktor pro inicializaci uzlu s klíčem a prioritou
        public Node(K key, P priority)
        {
            Key = key;
            Priority = priority;
        }

        // Přepsání metody ToString pro lepší vizualizaci uzlu
        public override string ToString()
        {
            var leftPriority = Left?.Priority.ToString() ?? "null"; // Priorita levého potomka nebo "null"
            var rightPriority = Right?.Priority.ToString() ?? "null"; // Priorita pravého potomka nebo "null"
            return $"{leftPriority} <-({Key}:{Priority})-> {rightPriority}";
        }
    }

    class Treap<K, P> : ITreep<K, P> where K : IComparable<K> where P : IComparable<P>
    {
        public Node<K, P> Root { get; private set; } // Kořenový uzel stromu

        // Metoda pro vkládání uzlu do stromu
        public void Insert(K key, P priority)
        {
            Root = InsertRecursive(Root, key, priority);
        }

        // Rekurzivní pomocná metoda pro vkládání uzlu
        private Node<K, P> InsertRecursive(Node<K, P> node, K key, P priority)
        {
            if (node == null) return new Node<K, P>(key, priority); // Vytvoření nového uzlu, pokud je místo prázdné

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
        private Node<K, P> RotateRight(Node<K, P> node)
        {
            Node<K, P> temp = node.Left; // Uložení levého potomka
            node.Left = temp.Right; // Přesun pravého potomka levého uzlu na místo původního uzlu
            temp.Right = node; // Nastavení původního uzlu jako pravého potomka
            return temp; // Vrácení nového kořenového uzlu
        }

        // Rotace uzlu doleva
        private Node<K, P> RotateLeft(Node<K, P> node)
        {
            Node<K, P> temp = node.Right; // Uložení pravého potomka
            node.Right = temp.Left; // Přesun levého potomka pravého uzlu na místo původního uzlu
            temp.Left = node; // Nastavení původního uzlu jako levého potomka
            return temp; // Vrácení nového kořenového uzlu
        }

        // Metoda pro vyhledávání uzlu podle klíče
        public Node<K, P> Find(K key)
        {
            return FindRecursive(Root, key);
        }

        // Rekurzivní pomocná metoda pro vyhledávání
        private Node<K, P> FindRecursive(Node<K, P> node, K key)
        {
            if (node == null) return null; // Vrácení null, pokud uzel není nalezen

            int comparison = key.CompareTo(node.Key); // Porovnání klíčů
            if (comparison == 0) return node; // Nalezení uzlu
            else if (comparison < 0) return FindRecursive(node.Left, key); // Vyhledávání v levém podstromu
            else return FindRecursive(node.Right, key); // Vyhledávání v pravém podstromu
        }



        // Metoda pro odstranění uzlu
        public Node<K, P> Delete(K key)
        {
            Node<K, P> deletedNode;
            Root = DeleteRecursive(Root, key, out deletedNode);
            return deletedNode;
        }

        // Rekurzivní pomocná metoda pro odstranění uzlu
        private Node<K, P> DeleteRecursive(Node<K, P> node, K key, out Node<K, P> deletedNode)
        {
            deletedNode = null;
            if (node == null) return null;

            int comparison = key.CompareTo(node.Key);
            if (comparison < 0) node.Left = DeleteRecursive(node.Left, key, out deletedNode);
            else if (comparison > 0) node.Right = DeleteRecursive(node.Right, key, out deletedNode);
            else
            {
                // Případ, kdy je třeba uzel odstranit
                deletedNode = node; // The node to be deleted is found
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

        // Rekurzivní pomocná meotda pro výpočet výšky stromu
        private int GetHeightRecursive(Node<K, P> node)
        {
            if (node == null) return 0; // Výska neinicializovaného stromu je 0
            // Výpočet výsky každého podstromu a přičtení 1 pro akttální node
            return 1 + Math.Max(GetHeightRecursive(node.Left), GetHeightRecursive(node.Right));
        }

        public void DisplayTree(int? spacing = 5)
        {
            DisplayTreeRecursive(Root, 0, "none", spacing);
        }

        // Rekurzivní pomocná metoda pro vizualizaci stromu
        private void DisplayTreeRecursive(Node<K, P> node, int space, string direction, int? spacing)
        {
            if (node == null) return; // Pokud uzel neexistuje, ukončí se rekurze

            space += spacing.HasValue ? spacing.Value : 5; // Zvýšení odsazení pro vizualizaci
            DisplayTreeRecursive(node.Right, space, "left", spacing); // Rekurze pro pravý podstrom

            // Vytisknutí uzlu s odsazením a směrem
            Console.WriteLine(new string(' ', space) + (direction == "left" ? "/" : direction == "right" ? "\\" : "-") + node.Key + "(" + node.Priority + ")");
            DisplayTreeRecursive(node.Left, space, "right", spacing); // Rekurze pro levý podstrom
        }
    }
}
