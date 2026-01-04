namespace program_usporna_navigace
{
    class Program
    {
        
        class Hrana
        {
            public int Tam;
            public int Delka;
            public int Placeno;

            public Hrana(int tam, int delka, int placeno)
            {
                Tam = tam;
                Delka = delka;
                Placeno = placeno;
            }
        }

        
        class Stav
        {
            public int Mesto;
            public int BylPlaceno;
            public int Vzdalenost;

            public Stav(int mesto, int bylPlaceno, int vzdalenost)
            {
                Mesto = mesto;
                BylPlaceno = bylPlaceno;
                Vzdalenost = vzdalenost;
            }
        }

        static void Main()
        {
            try
            {
                int[] first = ReadInts();
                if (first.Length != 2) throw new Exception();

                int M = first[0];
                int S = first[1];

                if (M <= 0 || S < 0) throw new Exception();

                List<Hrana>[] graph = new List<Hrana>[M];
                for (int i = 0; i < M; i++)
                    graph[i] = new List<Hrana>();

                for (int i = 0; i < S; i++)
                {
                    int[] line = ReadInts();
                    if (line.Length != 4) throw new Exception();

                    int a = line[0];
                    int b = line[1];
                    int delka = line[2];
                    int placeno = line[3];

                    if (a < 0 || a >= M || b < 0 || b >= M) throw new Exception();
                    if (delka <= 0) throw new Exception();
                    if (placeno != 0 && placeno != 1) throw new Exception();

                    graph[a].Add(new Hrana(b, delka, placeno));
                    graph[b].Add(new Hrana(a, delka, placeno));
                }

                int[] last = ReadInts();
                if (last.Length != 2) throw new Exception();

                int start = last[0];
                int end = last[1];

                if (start < 0 || start >= M || end < 0 || end >= M)
                    throw new Exception();

                Dijkstra(graph, start, end);
            }
            catch
            {
                Console.WriteLine("Neplatný vstup.");
            }
        }

        static void Dijkstra(List<Hrana>[] graph, int start, int end)
        {
            int M = graph.Length;
            const int INF = int.MaxValue / 2;

            int[,] vzdalenost = new int[M, 2];
            (int mesto, int bylPlaceno)[,] prev = new (int, int)[M, 2];

            for (int i = 0; i < M; i++)
                for (int j = 0; j < 2; j++)
                    vzdalenost[i, j] = INF;

            vzdalenost[start, 0] = 0;
            prev[start, 0] = (-1, -1);

            PriorityQueue<Stav, int> pq = new PriorityQueue<Stav, int>();
            pq.Enqueue(new Stav(start, 0, 0), 0);

            while (pq.Count > 0)
            {
                Stav cur = pq.Dequeue();

                if (cur.Vzdalenost != vzdalenost[cur.Mesto, cur.BylPlaceno])
                    continue;

                foreach (Hrana e in graph[cur.Mesto])
                {
                    int nextUsed = cur.BylPlaceno + e.Placeno;
                    if (nextUsed > 1) continue;

                    int newDist = cur.Vzdalenost + e.Delka;

                    if (newDist < vzdalenost[e.Tam, nextUsed])
                    {
                        vzdalenost[e.Tam, nextUsed] = newDist;
                        prev[e.Tam, nextUsed] = (cur.Mesto, cur.BylPlaceno);
                        pq.Enqueue(new Stav(e.Tam, nextUsed, newDist), newDist);
                    }
                }
            }

            int nejStav = vzdalenost[end, 0] <= vzdalenost[end, 1] ? 0 : 1;
            int nejVzdalenost = vzdalenost[end, nejStav];

            if (nejVzdalenost >= INF)
            {
                Console.WriteLine("Cesta neexistuje.");
                return;
            }

            List<int> cesta = new List<int>();
            int c = end;
            int s = nejStav;

            while (c != -1)
            {
                cesta.Add(c);
                var p = prev[c, s];
                c = p.mesto;
                s = p.bylPlaceno;
            }

            cesta.Reverse();

            Console.WriteLine(string.Join(" -> ", cesta));
            Console.WriteLine($"Vzdálenost: {nejVzdalenost}");
        }

        static int[] ReadInts()
        {
            string line = Console.ReadLine();
            if (line == null) throw new Exception();

            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] result = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
                result[i] = int.Parse(parts[i]);

            return result;
        }
    }
}