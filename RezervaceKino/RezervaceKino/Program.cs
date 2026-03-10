using System.ComponentModel.Design;

namespace RezervaceDoKina
{
    internal class Program
    {

        const int POCET_RAD = 8;
        const int SEDADLA_V_RADE = 10;
        const int ZAKLADNI_CENA = 180;
        const int VIP_PRIPLATEK = 70;

        static int[,] sedadla = {
            {0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
            {0, 0, 1, 0, 0, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 1, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 1, 0, 1, 1, 0},
            {0, 0, 0, 0, 0, 0, 1, 1, 1, 1},
        };


        static void Main(string[] args)
        {
            bool konec = false;
            while (konec == false)
                {
                ZobrazMenu();
                int volba = NactiCislo("Vyber akci: ");

                if (volba == 1)
                {
                    VypisSedadla(sedadla);
                }
                else if (volba == 2)
                {
                    RezervujSedadlo();
                }
                else if (volba == 3)
                {
                    konec = true;
                    Console.WriteLine("Program ukončen.");
                }
                else
                {
                    Console.WriteLine("Neplatná volba.");
                }
            }
        }
        
        static void ZobrazMenu() 
        {
            Console.WriteLine("\n--- REZERVACE KINA ---");
            Console.WriteLine("1 - Zobrazit sál");
            Console.WriteLine("2 - Rezervovat sedadlo");
            Console.WriteLine("3 - Konec");
        }

        static void VypisSedadla(int[,] sedadla) // funkce na vypsání 2D sezanmu sedadel pomocí 2 for cyklů
        {
            // vypíše číslování sloupců
            Console.Write("   ");                       
            for (int i = 1; i <= sedadla.GetLength(1); i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();



            for (int i = 0; i < sedadla.GetLength(0); i++)
            {   // vypíše opísmenkování řad
                char radek = (char)('A' + i);
                Console.Write($"{radek}  ");
                
                for (int j = 0; j < sedadla.GetLength(1); j++) // vypíše samotná sedadla "■" = plné, "O" = prázné
                {
                    if (sedadla[i, j] == 1)
                    {
                        Console.Write("■" + " ");
                    }
                    else 
                    {
                        Console.Write("O" + " ");
                    }
                    
                }
                Console.WriteLine();
            }

        }

        static void RezervujSedadlo()
        {
            Console.Write("Zadej řadu (A-H): ");
            string vstupRad = Console.ReadLine();

            if (string.IsNullOrEmpty(vstupRad))
            {
                Console.WriteLine("Nezadal jsi řadu.");
                return;
            }

            vstupRad = vstupRad.ToUpper();

            char pismeno = vstupRad[0];
            int radek = pismeno - 'A'; // najde to číselnou pozici řádku

            if (radek < 0 || radek >= POCET_RAD) // zkontroluje, jestli uživatel zadává řady v rozmezí
            {
                Console.WriteLine("Řada neexistuje.");
                return;
            }

            int sedadlo = NactiCislo("Zadej sedadlo (1-10): "); 
            if (sedadlo == -1) // -1 je z funkce načti číslo, znamená neúspěšně zadaný vstup, v tomto případě se ukončí rezervace a pokračuje se v hlavní smyčce
            {
                return;
            }

            sedadlo = sedadlo - 1; //převede na souřadnice, protože se čísluje od 0

            if (sedadlo < 0 || sedadlo >= SEDADLA_V_RADE) // zkontroluje, jestli uživatel zadává sedadla v rozmezí
            {
                Console.WriteLine("Sedadlo neexistuje.");
                return;
            }

            if (sedadla[radek, sedadlo] == 1)
            {
                Console.WriteLine("Sedadlo je obsazené.");
                return;
            }

            sedadla[radek, sedadlo] = 1;

            int cena = VypocitejCenu(radek);
            Console.WriteLine("Rezervace úspěšná.");
            Console.WriteLine("Cena lístku: " + cena + " Kč");
        }
        static int VypocitejCenu(int radek)
        {
            int cena = ZAKLADNI_CENA;

            if (radek >= 6)
            {
                cena = cena + VIP_PRIPLATEK;
            }

            return cena;
        }

        static int NactiCislo(string zprava)
        {
            Console.Write(zprava);
            string vstup = Console.ReadLine();

            int cislo;
            bool uspech = int.TryParse(vstup, out cislo); // pokud uživatel zadá něco jiného než číslo, TryParse selže

            if (uspech != true)
            {
                Console.WriteLine("Zadal jsi neplatný vstup, zadej číslo (1 - 10).");
                return -1; // -1 je značka pro neúspěch, používá se v ostatních funkcích
            }

            return cislo; // pokud vše proběhlo uspěšně do funkce se vrátí číslo uživatele
        }
    }
}
