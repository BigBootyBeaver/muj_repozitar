using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ConnectFour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] hraciPole = new int [6, 7];
            bool konec = false;
            int hrac = 1;

            while (konec != true) 

            {
                Console.Clear();

                Console.WriteLine($"\n--- NA TAHU JE HRÁČ {hrac} ---");
                VypisPole(hraciPole);


                int vybranySloupec = VyberSloupec(hraciPole, hrac);
                UmistiZeton(hraciPole, vybranySloupec, hrac);
                
                
                
                int vysledek = ZkontrolujVitezstvi(hraciPole);
                if (vysledek > 0)
                {
                    Console.Clear();
                    VypisPole(hraciPole);
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------------");
                    Console.WriteLine($"KONGRAČULEJŠNS. VYHRÁL hráč {vysledek}, šílenej borec, nelze popřít");
                    konec = true;
                }
                else if (vysledek == -1)
                {
                    Console.Clear();
                    VypisPole(hraciPole);
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------------");
                    Console.WriteLine("REMÍZA, pole je plné. životní prostor má nevyčíslitelnou cenu. Každého, kdo s ním nenakládá, jak nejlépe to jde, čeká jen zkáza, tma a zatracení ");
                    konec = true;
                }
                else // střidani tahů
                {
                    if (hrac == 1)
                    {
                        hrac = 2;
                    }
                    else
                    {
                        hrac = 1;
                    }

                }
               
            }
        }

        public static void VypisPole(int[,] pole)
        {
            Console.WriteLine("\n 1 2 3 4 5 6 7 "); 
            Console.WriteLine("---------------");

            for (int radek = 0; radek < 6; radek++) 
            {
                Console.Write("|"); 
                for (int sloupec = 0; sloupec < 7; sloupec++) 
                {

                    if (pole[radek, sloupec] == 0)
                    {
                        Console.Write(". ");
                    }
                    else 
                    {
                        Console.Write(pole[radek, sloupec] + " ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("---------------");
        }

        public static string VyberSopuere() // ok to je těžší, než jsem si myslel.
        {
            Console.WriteLine("Vyber si soupeře. h pro human (člověk), c pro computer(počítač)");
            string vstup = Console.ReadLine();
            while (vstup != "h" && vstup != "c") 
            {
                Console.WriteLine("zadávej pouze písmena h nebo c");
                Console.WriteLine("Vyber si soupeře. h pro human (člověk), c pro computer(počítač)");
                vstup = Console.ReadLine();
            }
            if (vstup == "h")
            {
                return "human";
            }
            else 
            {
                return "computer";
            }

        }


        public static bool JeSloupecPrazdny(int vybranySloupecMet, int[,] hraciPoleMet) 
        {
            int indexSloupce = vybranySloupecMet - 1;

            if (hraciPoleMet[0, indexSloupce] != 0)
            {
                Console.WriteLine("Tento sloupec už je plný! Vyber si jiný.");
                return false;
            }
            else 
            {
                return true;
            }

        }
        public static int VyberSloupec(int[,] hraciPoleMet, int hracMet) 
        {
            int volba_counter = 0;
            int volba = 0;
            
            
            while (volba_counter != 1) 
            {
                Console.WriteLine("Vyber si sloupec (1 až 7), kam umístíš žeton");
                string vstup = Console.ReadLine();

                if (int.TryParse(vstup, out volba) && volba >= 1 && volba <= 7 && JeSloupecPrazdny(volba, hraciPoleMet))
                {
                    
                    Console.WriteLine($"Vybral jsi sloupec {volba}.");
                    
                    volba_counter = 1;
                }
                else
                {
                    Console.WriteLine("Protože postrádáš šedou hmotu, ještě jednou:");
                    Console.WriteLine("Pouze celá čísla v rozmezí od 1 až 7. Umisťuj jen do prázdných sloupců.");
                }

            }
            return volba;

            
        }
        public static void UmistiZeton(int[,] pole, int sloupec, int hrac)
        {
            int indexSlouplce = sloupec - 1;
            for (int radek = 5; radek >= 0; radek--) 
            {
                if (pole[radek, indexSlouplce] == 0) 
                {
                    pole[radek, indexSlouplce] = hrac;
                    break;
                }
            
            }
        }
        public static int ZkontrolujVitezstvi(int[,] pole)

        {
            // výhra vodorovně
            for (int r = 0; r < 6; r++) 
            {
                for (int s = 0; s < 4; s++) // protože k výhře stačí 4 v řadě tak se to po 3 sloupci nemusí kontrolovat. od slopuce 4 do sloupce 7 nemůže vzniknout další čtveřice, nevejde se tam.
                {
                    if (pole[r, s] != 0 && pole[r, s] == pole[r, s + 1] && pole[r, s] == pole[r, s + 2] && pole[r, s] == pole[r, s + 3]) // zkontroluje, jestli jsou všechna pole v řadě stejné číslo.
                        return pole[r, s];
                }
            }

            // výhra svisle
            for (int r = 0; r < 3; r++) // 6 řádků, stačí kontrolovat do radku 2
            {
                for (int s = 0; s < 7; s++)
                {
                    if (pole[r, s] != 0 && pole[r, s] == pole[r + 1, s] && pole[r, s] == pole[r + 2, s] && pole[r, s] == pole[r + 3, s])
                        return pole[r, s];
                }
            }
            // výhra šikmo shora dolu
            for (int r = 0; r < 3; r++) // aby se do pole diagonala vešla, tak se její nejvyšíí, počáteční bod musí nacházet v rozmezí 1. až 3. řádku shora a 1. až 4 řádku zleva doprava. a od toho bodu se kontroluje diagonála. obdobne je to i u šikmeho směru nahoru.
            {
                for (int s = 0; s < 4; s++)
                {
                    if (pole[r, s] != 0 && pole[r, s] == pole[r + 1, s + 1] && pole[r, s] == pole[r + 2, s + 2] && pole[r, s] == pole[r + 3, s + 3])
                        return pole[r, s];
                }
            }
            // vyhra šikmo zdola nahoru
            for (int r = 3; r < 6; r++)
            {
                for (int s = 0; s < 4; s++)
                {
                    if (pole[r, s] != 0 && pole[r, s] == pole[r - 1, s + 1] && pole[r, s] == pole[r - 2, s + 2] && pole[r, s] == pole[r - 3, s + 3])
                        return pole[r, s];
                }
            }
            bool jePlno = true;
            for (int s = 0; s < 7; s++) // stačí kontrolovat horní řádek, aby se zaplni, musí být zaplneno všechno pod ním.
            {
                if (pole[0, s] == 0) jePlno = false; // pokud je nahore alespoň jedna 0, tak pole není plné.
            }
            if (jePlno) return -1; // -1 značí remízu

            return 0; // hraje se  dál

        }   
    }
}
