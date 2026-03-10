namespace BinarniVyhledavaciStromy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>();
            binarySearchTree.Insert(4, "a");
            binarySearchTree.Insert(1, "b");
            binarySearchTree.Insert(6, "c");
            binarySearchTree.Insert(3, "d");
            binarySearchTree.Insert(5, "e");
            binarySearchTree.Insert(2, "f");
            Console.ReadLine();
        }
    }

    class BinarySearchTree<T>
    {
        public Node<T> Root;

        public void Insert(int newKey, T newValue)
        {

            void _insert(Node<T> node, int newKey, T newValue)
            {
                if (newKey < node.Key) // jdeme doleva
                    if (node.LeftSon == null)
                        node.LeftSon = new Node<T>(newKey, newValue);
                    else
                        _insert(node.LeftSon, newKey, newValue);
                else if (newKey > node.Key) // jdeme doprava
                    if (node.RightSon == null)
                        node.RightSon = new Node<T>(newKey, newValue);
                    else
                        _insert(node.RightSon, newKey, newValue);
                else // našli jsme náš klíč, což bychom neměli, mají být unikátní.... :/
                    throw new Exception(); // vyhodíme chybu
            }

            if (Root == null) // pokud ještě není definován kořen
                Root = new Node<T>(newKey, newValue);
            else
                _insert(Root, newKey, newValue);
        }
    }

    class Node<T> // T může být libovolný typ
    {
        public Node(int key, T value)
        {
            Key = key;
            Value = value;
        }
        public int Key;
        public T Value;

        public Node<T> LeftSon;
        public Node<T> RightSon;



    }

}





