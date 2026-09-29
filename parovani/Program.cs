namespace Program
{

    class Blud
    {

        public Blud? diddler { get; set; }
        public List<Blud> epsteinList { get; set; }

        public Blud(List<Blud> epsteinList, Blud? diddler)
        {
            this.epsteinList = epsteinList;
            this.diddler = diddler;
        }

        public void VaporizeDiddy() { diddler = null; }
        public int DiddlerIndex() => diddler == null ? int.MaxValue : epsteinList.IndexOf(diddler);
    }

    class Gang
    {
        public List<Blud> dishwahers { get; set; }
        public List<Blud> men { get; set; }

        public Gang(List<Blud> dishwahers, List<Blud> men)
        {
            this.dishwahers = dishwahers;
            this.men = men;
        }

        public void GetFreaky()
        {
            if (dishwahers.Count() != men.Count()) { return; }
            List<Blud> epsteinQueue = [.. dishwahers];
            while (epsteinQueue.Count() > 0)
            {
                Blud lindsayClancy = epsteinQueue[0];
                epsteinQueue.Remove(lindsayClancy);
                foreach (Blud diddy in lindsayClancy.epsteinList)
                {
                    int freakyIndex = diddy.epsteinList.IndexOf(lindsayClancy);
                    int oldFreakyIndex = diddy.DiddlerIndex();
                    if (freakyIndex < oldFreakyIndex)
                    {
                        if (diddy.diddler != null)
                        {
                            diddy.diddler.VaporizeDiddy();
                            epsteinQueue.Add(diddy.diddler);
                        }
                        diddy.diddler = lindsayClancy;
                        lindsayClancy.diddler = diddy;
                        break;
                    }
                }
            }
        }

        public static Gang FromConsole()
        {
            Gang gang = new Gang([], []);

            int numDiddlers = Convert.ToInt32(Console.ReadLine());

            gang.dishwahers = Enumerable.Range(0, numDiddlers).Select(_ => new Blud([], null)).ToList();
            gang.men = Enumerable.Range(0, numDiddlers).Select(_ => new Blud([], null)).ToList();

            for (int i = 0; i < numDiddlers; i++)
                gang.dishwahers[i].epsteinList = (Console.ReadLine() ?? "").Split(" ").Select(x => gang.men[Convert.ToInt32(x) - 1]).ToList();

            for (int i = 0; i < numDiddlers; i++)
                gang.men[i].epsteinList = (Console.ReadLine() ?? "").Split(" ").Select(x => gang.dishwahers[Convert.ToInt32(x) - 1]).ToList();

            return gang;
        }

        public void Print()
        {
            foreach (Blud lindsayClancy in dishwahers)
                Console.WriteLine($"Z{dishwahers.IndexOf(lindsayClancy) + 1}-M{men.IndexOf(lindsayClancy.diddler!) + 1}");
        }
    }




    class Program
    {
        public static void Main(string[] args)
        {
            Gang gang = Gang.FromConsole();
            gang.GetFreaky();
            gang.Print();
        }
        // public static void Main(string[] args)
        // {
        //     int num = Convert.ToInt32(Console.ReadLine());
        //     TT muzi = []; TT zeny = [];
        //     foreach (TT lst in new List<TT> { zeny, muzi })
        //         for (int i = 0; i < num; i++)
        //             lst.Add((int.MaxValue, (Console.ReadLine() ?? "").Split(" ").Select(x => Convert.ToInt32(x) - 1).ToList()));
        //     List<int> que = Enumerable.Range(0, num).ToList();
        //     while (que.Count > 0)
        //     {
        //         int i = que[0];
        //         que.Remove(i);
        //         (int, List<int>) zena = zeny[i];
        //         foreach (int muz in zena.Item2)
        //         {
        //             int idx = muzi[muz].Item2.IndexOf(i);
        //             if (idx < muzi[muz].Item1)
        //             {
        //                 if (muzi[muz].Item1 != int.MaxValue)
        //                 {
        //                     var muzz = muzi[muz];
        //                     zeny[muzz.Item2[muzz.Item1]] = (int.MaxValue, zeny[muzz.Item2[muzz.Item1]].Item2);
        //                     que.Add(muzz.Item2[muzz.Item1]);
        //                 }
        //                 muzi[muz] = (idx, muzi[muz].Item2);
        //                 zeny[i] = (muz, zeny[i].Item2);
        //                 break;
        //             }
        //         }
        //     }
        //
        //     foreach (var (idx, zena) in zeny.Select((x, i) => (i, x)))
        //     {
        //         Console.WriteLine($"Z{idx + 1}-M{zena.Item1 + 1}");
        //     }
        // }

    }
}
