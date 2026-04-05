using System.Text;

namespace PololetniUloha
{
    internal class Program
    {




        static void Main(string[] args)
        {
            // (20b) 1. Seřaďte známky ze souboru znamky.txt od 1 do 5 algoritmem s lineární časovou složitostí vzhledem k počtu známek. 
            // Vypište je na řádek a pak vypište i četnosti jednotlivých známek.
            List<int> znamky = new List<int>();
            
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky.txt")) // otevření souboru pro čtení
            {
                while (!sr.EndOfStream) // dokud jsme nedošli na konec souboru
                {
                    int znamka = Convert.ToInt16(sr.ReadLine()); // čteme známky po řádcích a převádíme je na číslo
                    znamky.Add(znamka);
                } 
            }
            int lengthZnamky = znamky.Count;
            int[] poleReseni = new int[5];
            
            CountingSort(znamky, lengthZnamky, poleReseni);
            // => to, co jste pravděpodobně stvořili se nazývá Counting Sort
            static void CountingSort(List<int> znamkyM, int lenthZnamkyM, int[] poleReseniM)
            {
                for (int i = 0; i < lenthZnamkyM; i++) 
                {
                    poleReseniM[znamkyM[i] - 1] += 1;
                }
                for (int j = 0; j < 5; j++) 
                {
                    for (int k = 0; k < poleReseniM[j]; k++)
                    {
                        Console.Write($"{j + 1}, "); // Vypíše konkrétní známku
                    }
                }
            }


            // (40b) 2. Ze souboru znamky_prezdivky.csv vytvořte objekty typu Student se správně přiřazenou známkou a přezdívkou.
            // Seřaďte je podle známek (stabilně = dodržte pořadí v souboru) a vypište seřazené dvojice (znamka: přezdívka) - na každý řádek jednu.


            List<Student>[] znamkyStudentu =
                    {
                        new List<Student>(), new List<Student>(), new List<Student>(), new List<Student>(), new List<Student>()
                    };

            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky_prezdivky.csv"))
            {
                
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(";");
                    string jmeno = line[0];
                    int znamka = Convert.ToInt16(line[1]);

                    znamkyStudentu[znamka - 1].Add(new Student(jmeno, znamka));
                }
                
                foreach (List<Student> kbelik in znamkyStudentu) 
                {
                    foreach (Student student in kbelik) 
                    {
                        Console.WriteLine($"{student.Znamka}: {student.Prezdivka}");
                    }
                }

            }
            // => to, co jste pravděpodobně stvořili se nazývá Bucket Sort (přihrádkové řazení)




            // (10b) 3. Určete časovou a prostorovou složitost algoritmu z 2. úkolu
            // časová složitost je (n), protože se to projede n-krát při splitování a pak ještě n-krát při vypisování, takže jakoby 2n, ale obecně se to označuje jako n
            // pametova slozitost je O(n), protože se musí uložit n studentů, pak ještě 5 kbleíku, ale to nikoho nezajímá.




            // (+60b) 4. BONUS: Napište kód, který bude řadit lexikograficky velká čísla v lineárním čase. Využijte dat ze souboru velka_cisla.txt
            
            
            List<string> cisla = new List<string>();
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\velka_cisla.txt")) // otevření souboru pro čtení
            {
                while (!sr.EndOfStream) // dokud jsme nedošli na konec souboru
                {
                    string cislo = Convert.ToString(sr.ReadLine()); // čteme známky po řádcích a převádíme je na číslo
                    cisla.Add(cislo);
                }
            }

           
            
            List<string> serazeno = SortBig(cisla, 0);
            Console.WriteLine(string.Join("\n", serazeno));

            // algoritmus rozřazuje čísla do 10 škatulek podle první cifry. pokud je v nějaké škatulce více čísel, zavolá se rekurzivně v té škatulce a tam to rozřadí do podškatulek podle druhé cifry. Tak to jede, dokud to nebude rozřazené.
            static List<string> SortBig(List<string> seznam, int poziceCifry) 
            {
                if (seznam.Count <= 1 || poziceCifry >= seznam[0].Length)
                    return seznam;
                
                List<string>[] skatulky = new List<string>[10];
                for (int i = 0; i < 10; i++) 
                {
                    skatulky[i] = new List<string>();
                }

                foreach (var cislo in seznam) 
                {
                    int cifra = cislo[poziceCifry] - '0';
                    skatulky[cifra].Add(cislo);
                }
                List<string> vysledek = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    
                    vysledek.AddRange(SortBig(skatulky[i], poziceCifry + 1));
                }

                return vysledek;
            }
        }
    }

    class Student
    {
        public string Prezdivka { get; } // tím, že je zde pouze get říkáme, že tato vlastnost třídy Student jde mimo třídu pouze číst, nikoli upravovat
        public int Znamka { get; }
        public Student(string prezdivka, int znamka) // konstruktor třídy
        {
            // použitím samotného { get; } také říkáme, že tyto vlastnosti jdou nastavit nejpozději v konstruktoru - tedy v této metodě
            Prezdivka = prezdivka;
            Znamka = znamka;
        }
    }
}
