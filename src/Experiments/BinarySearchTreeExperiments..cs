using semB.src.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semB.src.Experiments
{
    internal class BinarySearchTreeExperiments
    {
        public static void Experiment()
        {
            //tutorialBST();
            studentBST();
        }
        private static void tutorialBST()
        {
            BinarySearchTree<string, int> bst = new();
            bst.Insert("A", 8);
            bst.Insert("B", 3);
            bst.Insert("C", 10);
            bst.Insert("D", 1);
            bst.Insert("E", 6);
            bst.Insert("F", 14);
            bst.Insert("G", 4);
            bst.Insert("H", 7);
            bst.Insert("I", 13);

            bst.DisplayTree();
        }

        private static void studentBST()
        {
            BinarySearchTree<string, int> bst = new();
            bst.Insert("G", 4);
            bst.Insert("B", 7);
            bst.Insert("A", 10);
            bst.Insert("E", 23);
            bst.Insert("H", 5);
            bst.Insert("K", 65);
            bst.Insert("I", 73);

            bst.DisplayTree();
        }
    }


}
