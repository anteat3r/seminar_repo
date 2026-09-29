using TT = System.Collections.Generic.List<(int, System.Collections.Generic.List<int>)>;
namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            TT muzi = []; TT zeny = [];
            foreach (TT lst in new List<TT> { zeny, muzi })
                for (int i = 0; i < num; i++)
                    lst.Add((int.MaxValue, (Console.ReadLine() ?? "").Split(" ").Select(x => Convert.ToInt32(x) - 1).ToList()));
            List<int> que = Enumerable.Range(0, num).ToList();
            while (que.Count > 0)
            {
                int i = que[0];
                que.Remove(i);
                (int, List<int>) zena = zeny[i];
                foreach (int muz in zena.Item2)
                {
                    int idx = muzi[muz].Item2.IndexOf(i);
                    if (idx < muzi[muz].Item1)
                    {
                        if (muzi[muz].Item1 != int.MaxValue)
                        {
                            var muzz = muzi[muz];
                            zeny[muzz.Item2[muzz.Item1]] = (int.MaxValue, zeny[muzz.Item2[muzz.Item1]].Item2);
                            que.Add(muzz.Item2[muzz.Item1]);
                        }
                        muzi[muz] = (idx, muzi[muz].Item2);
                        zeny[i] = (muz, zeny[i].Item2);
                        break;
                    }
                }
            }

            foreach (var (idx, zena) in zeny.Select((x, i) => (i, x)))
            {
                Console.WriteLine($"Z{idx + 1}-M{zena.Item1 + 1}");
            }
        }

    }
}
