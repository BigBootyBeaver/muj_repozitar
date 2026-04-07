using System.Reflection.Metadata.Ecma335;

namespace TestAlgoritmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolik je měst?");
            string nVstup = Console.ReadLine();
            int n = int.Parse(nVstup);

            List<string[]> vztahy = new List<string[]>();
            int[,] maticeSousednosti = new int[n, n];


            NapisMaticiSousednosti(ZadejDvojiceMest(vztahy, n), maticeSousednosti);
        }
        public static List<string[]> ZadejDvojiceMest(List<string[]> vztahy, int n) 
        {
            Console.WriteLine("Zadej dvojici, odděl mezerou");

            while (true) 
            {
                Console.WriteLine("Chceš zadat dvojici? a pro ano, cokoliv jineho pro ukončit zadávání");
                string rozhodnutí = Console.ReadLine();
                if (rozhodnutí == "a") // zadávání dvojice
                {
                    Console.WriteLine("Zadej dvojici, odděl mezerou, nezadavej vetši čisla než počet měst");
                    string[] dvojice = Console.ReadLine().Split(" ");
                    int prvniClenDvojice = int.Parse(dvojice[0]);
                    int druhyClenDvojice = int.Parse(dvojice[1]);

                    // kontrola vstupu, aby zadávaná čísla měst nebyla větší, než rozměry matice
                    if ((prvniClenDvojice > n) || (druhyClenDvojice > n)) 
                    {
                     
                        while ((prvniClenDvojice > n) || (druhyClenDvojice > n)) 
                        {
                            Console.WriteLine("Napiš to správně nezadavej vetši čisla než počet měst");
                            dvojice = Console.ReadLine().Split(" ");
                            prvniClenDvojice = int.Parse(dvojice[0]);
                            druhyClenDvojice = int.Parse(dvojice[1]);
                        }
                    }
                        

                    vztahy.Add(dvojice);
                }
                else // uživatel chce ukončit zadávání dvoji, vztahy se dají do matice sousednosti a ta se potom vypíše
                {
                    break;
                }

            }

            return vztahy;
        
        }
        public static int[,] NapisMaticiSousednosti(List<string[]> seznam, int[,] matice) 
        { 
            for (int i = 0; i < seznam.Count; i++) 
            {
                string[] dvojice = seznam[i];
                int prvniClenDvojice = int.Parse(dvojice[0]);
                int druhyClenDvojice = int.Parse(dvojice[1]);
                
                matice[prvniClenDvojice - 1, druhyClenDvojice -1] = 1; // přidá na místo vztahu 1 v tabulce vztahů

            }
            
            
            for (int j = 0; j < matice.GetLength(0); j++) // vypíše matici
            {
                for (int k = 0; k < matice.GetLength(1); k++) 
                {
                    Console.Write($"{matice[j, k]} ");

                }
                Console.WriteLine();
            }
            return matice;
        }   
        
        
        


    }
}
