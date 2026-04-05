namespace quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] neserazenene = [5, 4, 0, 3, 1, 7, 6, 2];

            QuicSort(neserazenene, 0, neserazenene.Length - 1);
            Console.WriteLine(string.Join(", ", neserazenene));

        }
        static void QuicSort(int[] pole, int l, int r) // druhá verze quicksortu ze zadání
        {
            if (l >= r) 
            {
                return;
            }
            int nahodnyIndex = Random.Shared.Next(l, r + 1);
            int pivot = pole[nahodnyIndex];
            int i = l;
            int j = r;

            while (i <= j) 
            {
                while (pole[i] < pivot) 
                {
                    i++;
                }
                while (pole[j] > pivot) 
                {
                    j--;
                }
                if (i < j) 
                {
                    int drzitel = pole[i];
                    pole[i] = pole[j];
                    pole[j] = drzitel;
                }
                if (i <= j) 
                {
                    i++;
                    j--;
                }

               
            }
            QuicSort(pole, l, j);
            QuicSort(pole, i, r);
        }
        // Bonus 1, medián v lineárním čase.
        //bude se hledat medián mediánů.
        //
        // pole (například s 1000 prvky) se rozdělí třeba na pětice.
        // z každé pětice se vybere medián například pomocí insertion sort.
        // pole s tisíci prvky se rozdělí na 200 pětic, z nichž bude vybráno 200 mediánů a ty se naskládají do pole.
        // pro toto pole 200 prků se stejný algoritmus zavolá rekurzivně znovu. tady 200 prvků rozdělí do 40 pětic a znich opět vybere 40 mediánů.
        // pokud prvky nelze rozdělit přesně do pětic, tak vezme nejbližší menší počet prvků dělitelný pěti a ten rozdělí do pětic. pro přebývající prvky pak najde medián pomocí stejného algoritmu. Pokud je počet prvků v přebývající skupině sudý, tak jako medián může vzít například menší z čísel uprostřed.
        // takto to bude algoritmus dělat do té doby, než mu nezůstane poslední pětice (nebo i nějaká méně-tice), ze které vybere poslední medián. ten se pak nastaví jako pivot.
        // tento algoritmus zamezí výběru špatného pivota, kam patří ta největší nebo ta nejmenší čísla v poli.
    }
}
