namespace Funkce1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cisla = { 1, 3, 5, 7, 0, 2, 4, 6, 8, -1, -5 };
            Console.WriteLine($"Púvodní pole je: "); // JE strašný, že mi to nedovolí napsat: Console.WriteLine($"Púvodní pole je {cisla}") a furt to chce nějakej for cyklus
            VypisPole(cisla);
            
            
            int maximum = FindMax(cisla);
            Console.WriteLine("Největší číslo v poli je: " + maximum);

       
            int[] serazene = SortArray(cisla);
            Console.WriteLine("Seřazen pole:");
            VypisPole(serazene);

           
            Console.WriteLine("Zadej číslo které chceš najít: ");
            int hledane = int.Parse(Console.ReadLine());

            int index = BinarySearch(serazene, hledane);
            if (index != -1)
                Console.WriteLine("Číslo " + hledane + " je na indexu " + index + ".");
            else
                Console.WriteLine("Číslo " + hledane + " tam není.");
        }
        static int FindMax(int[] pole)
        {
            int max = pole[0];
            for (int i = 1; i < pole.Length; i++)
            {
                if (pole[i] > max)
                {
                    max = pole[i];
                }
            }
            return max;
        }
        static int[] SortArray(int[] pole)
        {
            // Chat gpt mi řekl, ať vytvořím kopii, aby se to nepřepisovalo, opět for cyklus, je to v pythonu jiné?
            int[] novePole = new int[pole.Length];
            for (int i = 0; i < pole.Length; i++)
                novePole[i] = pole[i];

            for (int i = 0; i < novePole.Length - 1; i++)
            {
                for (int j = 0; j < novePole.Length - 1 - i; j++)
                {
                    if (novePole[j] > novePole[j + 1])
                    {
                        int x = novePole[j];
                        novePole[j] = novePole[j + 1];
                        novePole[j + 1] = x;
                    }
                }
            }

            return novePole;
        }

        static int BinarySearch(int[] pole, int hledane)
        {
            int leva = 0;
            int prava = pole.Length - 1;

            while (leva <= prava)
            {
                int stred = (leva + prava) / 2; // jestě ze se to zaokrouhluje dolu

                if (pole[stred] == hledane)
                    return stred;
                else if (pole[stred] < hledane)
                    leva = stred + 1; 
                else
                    prava = stred - 1; 
            }

            return -1; 
        }
        static void VypisPole(int[] pole)
        {
            for (int i = 0; i < pole.Length; i++)
            {
                Console.Write(pole[i] + " ");
            }
            Console.WriteLine();
        }




    }


}
