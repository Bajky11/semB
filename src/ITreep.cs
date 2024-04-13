namespace semB.src.Treep
{
    internal interface ITreep<K, P>
        where K : IComparable<K>
        where P : IComparable<P>
    {
        Node<K, P> Root { get; }
        Node<K, P> Delete(K key);
        Node<K, P> Find(K key);
        void Insert(K key, P priority);
        void DisplayTree(int? spacing = 5);
        int GetHeight();
    }
}