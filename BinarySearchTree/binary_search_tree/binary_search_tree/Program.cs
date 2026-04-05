namespace binary_search_tree
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // odtud by mělo být přístupné jen to nejdůležitější, žádné vnitřní pomocné implementace.
            // Strom a jeho metody mají fungovat jako černá skříňka, která nám nabízí nějaké úkoly a my se nemusíme starat o to, jakým postupem budou splněny.
            // rozhodně také nechceme mít možnost datovou stukturu nějak měnit jinak, než je dovoleno (třeba nějakým jiným způsobem moct přidat nebo odebrat uzly, aniž by platili invarianty struktury)

            BinarySearchTree<Student> tree = new BinarySearchTree<Student>();

            // čteme data z CSV souboru se studenty (soubor je uložen ve složce projektu bin/Debug u exe souboru)
            // CSV je formát, kdy ukládáme jednotlivé hodnoty oddělené čárkou
            // v tomto případě: Id,Jméno,Příjmení,Věk,Třída
            using (StreamReader streamReader = new StreamReader("../../../../studenti_shuffled.csv"))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    string[] studentData = line.Split(',');

                    Student student = new Student(
                        Convert.ToInt32(studentData[0]),    // Id
                        studentData[1],                     // Jméno
                        studentData[2],                     // Příjmení
                        Convert.ToInt16(studentData[3]),    // Věk
                        studentData[4]);                    // Třída

                    // vložíme studenta do stromu, jako klíč slouží jeho Id
                    tree.Insert(student.Id, student);
                    line = streamReader.ReadLine();
                }
            }

            // Najděte studenta s ID 20 (David Urban (ID: 20) ze třídy 4.A)
            Student s20 = tree.Find(20);
            Console.WriteLine($"Hledaný student ID 20: {s20}");


            // Najděte studenta s nejnižším ID (Kateřina Sedláček (ID: 1) ze třídy 1.B)
            Student nejmensi = tree.FindMin();
            Console.WriteLine($"Student s nejnižším ID: {nejmensi}");

            // Vložte vlastního studenta s ID > 100 (je potřeba vytvořit nový objekt typu Student) a zkuste ho pak najít
            Student novy = new Student(120009999, "Hřib", "Ručník", 20, "4.B");
            tree.Insert(novy.Id, novy);
            Console.WriteLine($"Nově vložený: {tree.Find(105)}");
            
            // Smažte všechny studenty se sudým ID.                              fuj, nefachá mi to 
            

            // Vypište strom (měli byste vidět jen ID lichá a seřazená)
            Console.WriteLine("\n--- Výpis stromu (pouze lichá ID) ---");
            tree.Print();





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
    class Student
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public string ClassName { get; }

        public Student(int id, string firstName, string lastName, int age, string className)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ClassName = className; // nějak to tu nebylo
        }

        // aby se nám při Console.WriteLine(student) nevypsala jen nějaká adresa v paměti,
        // upravíme výpis objektu typu student na něco čitelného
        public override string ToString()
        {
            return string.Format("{0} {1} (ID: {2}) ze třídy {3}", FirstName, LastName, Id, ClassName);
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
                    if(node.LeftSon== null)
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

            if(Root == null) // pokud ještě není definován kořen
                Root = new Node<T>(newKey, newValue);
            else
                _insert(Root, newKey, newValue);
        }
        public T Find(int key)
        {
            Node<T> current = Root;
            while (current != null)
            {
                if (key == current.Key) 
                {
                    return current.Value;
                }
                    
                current = key < current.Key ? current.LeftSon : current.RightSon;
            }
            return default; // hledali, hledali, ale nenašli
        }

        
        public T FindMin()
        {
            if (Root == null) 
            {
                return default;
            } 
            Node<T> current = Root;
            while (current.LeftSon != null) 
            {
                current = current.LeftSon;
            } 
            return current.Value;
        }

        
        public void Print()
        {
            PrintRecursive(Root);
        }

        private void PrintRecursive(Node<T> node)
        {
            if (node == null) 
            {
                return;
            } 
            PrintRecursive(node.LeftSon);
            Console.WriteLine(node.Value);
            PrintRecursive(node.RightSon);
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