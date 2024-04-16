
namespace semB.src.Treep
{
    internal interface ITreap<K> where K : IComparable<K>
    {
        void Insert(K key);
        object Delete(K key);
        object Find(K key);
        void DisplayTree(int? spacing = 5);
        int GetHeight();
        void LoadFromFile(string filePath);
        void SaveToFile(string filePath);
    }
}