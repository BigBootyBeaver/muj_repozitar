using System.ComponentModel.Design;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Počet studentů: ");
            int pocet = Convert.ToInt32(Console.ReadLine());
            List<string> studenti = new List<string>();
            List<int> veky = new List<int>();
            List<float> prumery = new List<float>();
            for (int i = 0; i < pocet; i++)
            {
                Console.Write("Jméno: ");
                string jmeno = Console.ReadLine();
                studenti.Add(jmeno);

                Console.Write("Věk: ");
                int vek = Convert.ToInt32(Console.ReadLine());
                veky.Add(vek);

                Console.Write("Průměr ");
                float prumer = float.Parse(Console.ReadLine());
                prumery.Add(prumer);

            }
            
            while (true)
            {
                Console.Write(" a) vypíše studenty; b) vypíše dobré studenty; c) průměrný věk; d) pápá");
                string vyber = Console.ReadLine();
                if (vyber == "a")
                {
                    for (int i = 0; i < studenti.Count; i++)
                    {
                        Console.WriteLine($"{studenti[i]}({veky[i]}): {prumery[i]}");
                    }
                }
                else if (vyber == "b")
                {
                    for (int i = 0; i < studenti.Count; i++)
                    {
                        if (prumery[i] < 2)
                        {
                            Console.WriteLine($"{studenti[i]}({veky[i]}): {prumery[i]}");

                        }
                    }
                }
                else if (vyber == "c")
                {
                    float soucet = 0;
                    foreach (int vek in veky)
                    {
                        soucet += vek;
                    }
                    float prumerVeku = (float)soucet / veky.Count;
                    Console.WriteLine($"Průměrný věk: {prumerVeku}");

                }
                else if (vyber == "d")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Piš správně.");
                }
            }


            

        }
    }
}