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
            List<Blud> epsteinList = [.. dishwahers];
            while (epsteinList.Count() > 0)
            {
                Blud lindsayClancy = epsteinList[0];
                epsteinList.Remove(lindsayClancy);
                foreach (Blud diddy in lindsayClancy.epsteinList)
                {
                    int freakyIndex = diddy.epsteinList.IndexOf(lindsayClancy);
                    int oldFreakyIndex = diddy.DiddlerIndex();
                    if (freakyIndex < oldFreakyIndex)
                    {
                        if (diddy.diddler != null)
                        {
                            diddy.diddler.VaporizeDiddy();
                            epsteinList.Add(diddy.diddler);
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
    }
}
