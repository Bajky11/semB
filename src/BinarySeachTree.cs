using System;

namespace semB.src.BinarySearchTree
{
    class Node<K, P> where P : IComparable
    {
        public K Key { get; set; }
        public P Priority { get; set; }
        public Node<K, P> Left { get; set; }
        public Node<K, P> Right { get; set; }

        public Node(K key, P priority)
        {
            Key = key;
            Priority = priority;
        }

        public override string ToString()
        {
            var leftPriority = Left?.Priority.ToString() ?? "null";
            var rightPriority = Right?.Priority.ToString() ?? "null";
            return $"{leftPriority} L- {Priority} -R {rightPriority}";
        }
    }

    class BinarySearchTree<K, P> where P : IComparable
    {
        public Node<K, P> Root { get; private set; }

        public void Insert(K key, P priority)
        {
            Root = InsertRecursive(Root, key, priority);
        }

        private Node<K, P> InsertRecursive(Node<K, P> node, K key, P priority)
        {
            if (node == null)
            {
                return new Node<K, P>(key, priority);
            }

            if (priority.CompareTo(node.Priority) < 0)
            {
                node.Left = InsertRecursive(node.Left, key, priority);
            }
            else if (priority.CompareTo(node.Priority) > 0)
            {
                node.Right = InsertRecursive(node.Right, key, priority);
            }

            return node;
        }

        public Node<K, P> Find(P priority)
        {
            return FindRecursive(Root, priority);
        }

        private Node<K, P> FindRecursive(Node<K, P> node, P priority)
        {
            if (node == null || node.Priority.CompareTo(priority) == 0)
            {
                return node;
            }

            return priority.CompareTo(node.Priority) < 0 ? FindRecursive(node.Left, priority) : FindRecursive(node.Right, priority);
        }

        public void Delete(P priority)
        {
            Root = DeleteRecursive(Root, priority);
        }

        private Node<K, P> DeleteRecursive(Node<K, P> node, P priority)
        {
            if (node == null) return null;

            if (priority.CompareTo(node.Priority) < 0)
            {
                node.Left = DeleteRecursive(node.Left, priority);
            }
            else if (priority.CompareTo(node.Priority) > 0)
            {
                node.Right = DeleteRecursive(node.Right, priority);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                node.Priority = MinPriority(node.Right).Priority;
                // Update the node's key as well when replacing its priority during deletion
                node.Key = MinPriority(node.Right).Key;
                node.Right = DeleteRecursive(node.Right, node.Priority);
            }

            return node;
        }

        private Node<K, P> MinPriority(Node<K, P> node)
        {
            Node<K, P> current = node;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }

        public void DisplayTree()
        {
            DisplayTreeRecursive(Root, 0, "none");
        }

        private void DisplayTreeRecursive(Node<K, P> node, int space, string direction)
        {
            if (node == null) return;

            space += 5;
            DisplayTreeRecursive(node.Right, space, "left");

            Console.WriteLine(new string(' ', space) + (direction == "left" ? "/" : direction == "right" ? "\\" : "-") + node.Key + "(" + node.Priority + ")");
            DisplayTreeRecursive(node.Left, space, "right");
        }
    }
}
