namespace Pratele
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("kolik znáš lidí");
            int pocet = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Znáš nějaké přátele?");
            string pratele = (Console.ReadLine()); ;
            int[,] tabulka = new int[pocet, pocet];

            string[] vztahy = pratele.Split(' ');
            for (int i = 0; i < vztahy.Length; i++) 
            {
                string[] vztah = vztahy[i].Split('-');
                tabulka[Convert.ToInt32(vztah[0]) - 1, Convert.ToInt32(vztah[1]) - 1] = 1; // tabulka je symetricka
                tabulka[Convert.ToInt32(vztah[1]) - 1, Convert.ToInt32(vztah[0]) - 1] = 1;
            }
            Queue<int> fronta = new Queue<int>();



        }
    }
}
