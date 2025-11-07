namespace SpojovéSeznamy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> seznam = new LinkedList<string>();

            // Přidání prvků
            seznam.AddLast("Kč");
            seznam.AddLast("Groš");
            seznam.AddLast("3KilaSádry");
            seznam.AddLast("Ochrana");
            seznam.AddLast("BitováMince");
            seznam.AddLast("Kč");
            seznam.AddLast("Kč");
            seznam.AddLast("PrasCoin");
            
            // Procházení seznamu
            Console.WriteLine("\nNa začátku:");
            foreach (var prvek in seznam)
            {
                Console.WriteLine(prvek);
            }

            Console.WriteLine($"\nMáme v kapse Euro? Odpověď: {Exist(seznam, "Euro")}");
            Console.WriteLine($"Máme v kapse PrasCoin? Odpověď: {Exist(seznam, "PrasCoin")}");

            // Odebrání prvku
            RemoveFromEnd(seznam);
            Console.WriteLine("\nPo odebrání posledního:");
            foreach (var prvek in seznam)
            {
                Console.WriteLine(prvek);
            }
            // Odebrání všech stejných prvků
            RemoveAll(seznam, "Kč");
            Console.WriteLine("\nTeď odebereme všechny Kč, takto vypadá naše kapsa:");
            foreach (var prvek in seznam)
            {
                Console.WriteLine(prvek);
            }

            // Vytvoření nového seznamu
            LinkedList<string> peněženka = new LinkedList<string>();
            peněženka.AddLast("Ochrana");
            peněženka.AddLast("Poukaz");
            peněženka.AddLast("občanka");
            peněženka.AddLast("BitováMince");
            peněženka.AddLast("Kč");
            peněženka.AddLast("PrasCoin");
            Console.WriteLine("\nToto je v peněžence");
            foreach (var prvek in peněženka)
            {
                Console.WriteLine(prvek);
            }

            // Prunik
            Console.WriteLine("\nToto je prunik 2 seznamů");
            foreach (var prvek in Intersection(seznam, peněženka)) 
            {
                Console.WriteLine(prvek);
            }

            // Sjednocení
            Console.WriteLine("\nToto je sjednocení 2 seznamů");
            foreach (var prvek in Union(seznam, peněženka))
            {
                Console.WriteLine(prvek);
            }


        }
        static void RemoveFromEnd(LinkedList<string> seznam)
        {
            if (seznam.Count == 0)
            {
                Console.WriteLine("Jsme švorc, o všechno jsme přišli, víc si nemůžeme dovolit.");
                return;
            }
            seznam.RemoveLast();
        }
        static bool Exist(LinkedList<string> seznam, string value)
        {
            foreach (var prvek in seznam)
            {
                if (prvek == value)
                {
                    return true;
                }
            }

            return false;
        }
        static void RemoveAll(LinkedList<string> seznam, string value)
        {
            var node = seznam.First;
            while (node != null)
            {
                var nextnode = node.Next;
                if (node.Value == value)
                {
                    seznam.Remove(node);
                }
                node = nextnode;
            }

        }
        static LinkedList<string> Intersection(LinkedList<string> seznam, LinkedList<string> peněženka)
        {
            LinkedList<string> prunik = new LinkedList<string>();
            
            var node1 = seznam.First;
            while (node1 != null)
            {
                var next1 = node1.Next;
                if (!Exist(prunik, node1.Value))
                {
                    if  (Exist(peněženka, node1.Value))
                    {
                        prunik.AddLast(node1.Value);
                    }
                
                }
                node1 = next1;
            }
            return prunik;
        }
        static LinkedList<string> Union(LinkedList<string> seznam, LinkedList<string> peněženka) 
        {
            LinkedList<string> sjednoceni = new LinkedList<string>();

            var node1 = seznam.First;
            while (node1 != null)
            {
                var next1 = node1.Next;
                if (!Exist(sjednoceni, node1.Value))
                {
                    sjednoceni.AddLast(node1.Value);
                }
                node1 = next1;
            }
            var node2 = peněženka.First;
            while (node2 != null)
            {
                if (!Exist(sjednoceni, node2.Value))
                    sjednoceni.AddLast(node2.Value);

                node2 = node2.Next;
            }


            return sjednoceni;
        }
    
    }

    
}



    