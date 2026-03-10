using System.Text;

namespace PololetniUloha
{
    internal class Program
    {
        int[] cetnostZnamky = new int[5];
        static void Main(string[] args)
        {

            
            // (20b) 1. Seřaďte známky ze souboru znamky.txt od 1 do 5 algoritmem s lineární časovou složitostí vzhledem k počtu známek. 
            // Vypište je na řádek a pak vypište i četnosti jednotlivých známek.

            
            // => to, co jste pravděpodobně stvořili se nazývá Counting Sort



            // (40b) 2. Ze souboru znamky_prezdivky.csv vytvořte objekty typu Student se správně přiřazenou známkou a přezdívkou.
            // Seřaďte je podle známek (stabilně = dodržte pořadí v souboru) a vypište seřazené dvojice (znamka: přezdívka) - na každý řádek jednu.
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky_prezdivky.csv"))
            {

                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(";");

                }

            }
            // => to, co jste pravděpodobně stvořili se nazývá Bucket Sort (přihrádkové řazení)




            // (10b) 3. Určete časovou a prostorovou složitost algoritmu z 2. úkolu




            // (+60b) 4. BONUS: Napište kód, který bude řadit lexikograficky velká čísla v lineárním čase. Využijte dat ze souboru velka_cisla.txt

        }
        static void VypiseCetnostiZnamek(int[] cetnostZnamky) 
        {
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky.txt")) // otevření souboru pro čtení
            {


                while (!sr.EndOfStream) // dokud jsme nedošli na konec souboru
                {
                    int znamka = Convert.ToInt16(sr.ReadLine()); // čteme známky po řádcích a převádíme je na číslo
                    cetnostZnamky[znamka - 1] = +1;
                }
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
