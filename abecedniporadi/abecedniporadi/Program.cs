namespace abecedniporadi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] vztahy = Console.ReadLine().Split(' ');
            List<char> znakyAbecedy = new List<char>();
            for (int i = 0; i < vztahy.Length; i++) 
            {
                string vztah = vztahy[i];
                if (!znakyAbecedy.Contains(vztah[0]));
                    znakyAbecedy.Add(vztah[0]);
                if (!znakyAbecedy.Contains(vztah[2]));
                    znakyAbecedy.Add(vztah[2]);
            }
            List<List<int>> maticeVztahu = new List<List<int>>();

        }
    }

}
