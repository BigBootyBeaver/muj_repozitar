namespace vyhledavaci_strom
{
    internal class Program
    {

        
        // 256 kvuli ascii hodnotam
        static List<char>[] graf = new List<char>[256]; // pole seznamů následovníků pro znaky
        static int[] stupne = new int[256]; // počty předchůdců pro znak
        static bool[] jeVAbecede = new bool[256]; // ukláda, jaké všechny znaky jsou ve slovech
        static void Main(string[] args)
        {
            for (int i = 0; i < 256; i++) 
            {
                graf[i] = new List<char>(); // dá seznamy do seznamu graf
            }

            Console.WriteLine("Slovnik pls: ");
            string vstup = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(vstup)) return;
            string[] slova = vstup.Split(' ');

            foreach (string s in slova) // tohle projede každý znak v každém slově a na pozici 0 až 255 (odpovídající pozici znaku v ASCII) v jeVAbecede přidá true. 
                foreach (char c in s)
                    jeVAbecede[c] = true;

            
            PorovnejSlova(slova);
            VypisPoradiZnaku();

            // Khanův algoritmus
            static void VypisPoradiZnaku() 
            {
                Queue<char> fronta = new Queue<char>();
                for (int i = 0; i < 256; i++) // hledá znaky ktere nikdo nepředchazí. Jsou jak v jeVAbecede tak v stupne. Přidá je do fronty.
                {
                    if (jeVAbecede[i] && stupne[i] == 0) fronta.Enqueue((char)i);
                }

                List<string> vysledek = new List<string>();

                while (fronta.Count > 0)
                {
                    char aktualni = fronta.Dequeue();
                    vysledek.Add(aktualni.ToString());

                    foreach (char naslednik in graf[aktualni]) //koukne se na všechny nasledniky pro aktualni znak
                    {
                        stupne[naslednik] -= 1; // sníží počet závislostí u naslednika o 1. Pokud uz naslednik nema zadne zavislosti (nema predchudce a tedy neni naslednikem), tak ho to vrazí do fronty
                        if (stupne[naslednik] == 0) 
                        {
                            fronta.Enqueue(naslednik);
                        }
                        
                    }
                }

                // Detekce cyklů. kontroluje to, jestli je stejně typů znaků na začatku jako ve vysledku na konci. treba na vstupu "acb abc cab bac" jsou tri znaky (a, c, b). Kdyby ve vysledku nějaky znak chyběl, tak je tam cyklus.
                int celkemZnaku = 0;            // vysledkem vyskytu cyklu je to, že fronta se vyprazdni, ale žadane další zanky se tam nepřidají (přidávají se jen znaky, co nejsou následníci, ale v cyklu se to následnictví stále udržuje). pokud je fronta prázdná, program skončí, ale nepřidaly se všechny znaky.
                for (int i = 0; i < 256; i++) 
                {
                    if (jeVAbecede[i]) 
                    {
                        celkemZnaku += 1;
                    } 

                } 

                if (vysledek.Count < celkemZnaku)
                {
                    Console.WriteLine("obsahuje cyklus => nejde");
                }
                else
                {
                    Console.WriteLine(string.Join(" -> ", vysledek));
                }

            }


            // vycucne ze slov vstahy mezi znaky
            static void PorovnejSlova(string[] slova) 
            {
                for (int i = 0; i < slova.Length - 1; i++)
                {
                    string slovo1 = slova[i];
                    string slovo2 = slova[i + 1];


                    if (slovo1.StartsWith(slovo2) && slovo1.Length > slovo2.Length) // ve slovníku nemůže být delší slovo zařazené před kratším slovem, pokud je v něm kratší slovo obsáhlé na začátku. Nesmí se stát: "abcd" a pak slovo "abc"
                    {

                        throw new ArgumentException($"Chyba ve slovníku (neplatné pořadí slov): Slovo '{slovo1}' nesmí začínat na '{slovo2}' a být delší.");
                    }

                    int delkaMensiho = Math.Min(slovo1.Length, slovo2.Length);
                    for (int j = 0; j < delkaMensiho; j++) 
                    {
                        if (slovo1[j] != slovo2[j]) 
                        {
                            char pred = slovo1[j];
                            char za = slovo2[j];


                            if (!graf[pred].Contains(za)) // kontroluje, jestli se to tam uz nepridalo. kdyz ne, tak to tam prida. 
                            {
                                graf[pred].Add(za);
                                stupne[za]++; 
                            }

                            break;
                        }
                        
                    }
                }
            }

            
        }
    }
}
