namespace Test_z_ostreho_c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string odchod = Console.ReadLine();

            while (odchod != "q") 
            {
                int x1 = 0; // tuto sekci bych vložil do funkce Delky_stran, odtud pak do funkce Vzdalenost, lterá by byla volána uvnotř funkce Delky_stran
                int y1 = 0;

                int x2 = 1;
                int y2 = 1;

                List<int> vrcholy = new List<int>();

                Console.WriteLine($"vzdalenost je {Vzdalenost(x1, x2, y1, y2)}");
                Console.WriteLine("pokud chces ukoncit program, stiskni q");
                odchod = Console.ReadLine();

            }
        
        }
        static double Vzdalenost(int a1, int b1, int a2, int b2) 
        {
            
            int x_slozka = b1 - a1;
            int y_slozka = b2 - a2;
            double mezivypocet= Math.Pow(x_slozka, 2) + Math.Pow(y_slozka,2);
            double velikost = Math.Sqrt(mezivypocet);
            return velikost;
        }
        static Delky_stran // Pointa byla zeptat se uživatele na souřadnice x a y 3 bodů, // hodilo by si vzpomenout na covert ToInt32, kdyz se ptam uzivatele
                           // dále je postupně dát do 3 polí
                           // tyto tři pole dát do dalšího ploe
                           // pak příjde for cyklus který, běží třikrát pro velké pole. Vždy vezme pole ve velkém poli na pozici 'i' a pak pole 'i -1'
                           // vytáhne pomocí indexů souřadnice bodů z obou malých polí a dosadí je do funkce Vzdalenost.
                           // Do nového seznamu pak přidá vzdálenosti mezi body


    }   
}
