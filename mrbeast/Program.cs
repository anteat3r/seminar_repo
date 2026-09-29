using ChaChar = char;

class MrBeast
{

    struct Gru
    {
        public int x { get; set; }
        public int y { get; set; }

        public Gru(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Gru operator +(Gru a, Gru b) => new Gru(a.x + b.x, a.y + b.y);
        public static Gru operator ^(Gru a, int rot)
        {
            Gru newGru = a;
            for (int i = 0; i < rot; i++)
                newGru = new Gru(-newGru.y, newGru.x);
            return newGru;
        }

        public static bool operator ==(Gru a, Gru b) => a.x == b.x && a.y == b.y;
        public static bool operator !=(Gru a, Gru b) => !(a == b);
        public override bool Equals(object? obj) => obj is Gru g && this == g;
        public override int GetHashCode() => HashCode.Combine(x, y);

        public static List<Gru> moralCompass = [new Gru(1, 0), new Gru(0, -1), new Gru(-1, 0), new Gru(0, 1)];
    }

    class Field
    {
        public List<List<ChaChar>> omaha { get; set; }
        public List<IShowSpeed> speedove { get; set; }

        public Field(List<List<ChaChar>> grid, List<IShowSpeed>? speeds = null)
        {
            this.omaha = grid;
            this.speedove = speeds ?? [];
        }

        public ChaChar this[Gru g]
        {
            get
            {
                if (speedove.Any(s => s.pos == g)) return 'X';
                return omaha[g.y][g.x];
            }
        }

        public IShowSpeed Summon(int x, int y, ChaChar dirChar)
        {
            IShowSpeed speed = new IShowSpeed(this, new Gru(x, y), Gru.moralCompass[">^<v".IndexOf(dirChar)]);
            speedove.Add(speed);
            return speed;
        }

        public void Tango()
        {
            foreach (IShowSpeed speed in speedove.ToList())
                speed.Tango();
        }

        public void Print()
        {
            foreach (IShowSpeed speed in speedove)
                omaha[speed.pos.y][speed.pos.x] = ">^<v"[Gru.moralCompass.IndexOf(speed.dir)];

            foreach (List<ChaChar> row in omaha)
                Console.WriteLine(new String(row.ToArray()));
            Console.WriteLine("\n");

            foreach (IShowSpeed speed in speedove)
                omaha[speed.pos.y][speed.pos.x] = '.';
        }

        public void Dvanactiminutovka(int steps = 20)
        {
            for (int i = 0; i < steps; i++)
            {
                Tango();
                Print();
            }
        }

        public static Field FromConsole()
        {
            int width = (int)Convert.ToInt64(Console.ReadLine());
            int height = (int)Convert.ToInt64(Console.ReadLine());

            List<List<ChaChar>> grid = [];
            Field field = new Field(grid);

            for (int i = 0; i < height; i++)
            {
                List<ChaChar> row = (Console.ReadLine() ?? "").ToCharArray().ToList();
                for (int j = 0; j < row.Count; j++)
                {
                    if (">^<v".Contains(row[j]))
                    {
                        field.Summon(j, i, row[j]);
                        row[j] = '.';
                    }
                }
                grid.Add(row);
            }

            return field;
        }
    }

    class IShowSpeed
    {
        public Gru pos { get; set; }
        public Gru dir { get; set; }

        public Field field { get; set; }

        public IShowSpeed(Field field, Gru pos, Gru dir)
        {
            this.field = field;
            this.pos = pos;
            this.dir = dir;
        }

        public void Tango()
        {
            Gru facing = dir;
            Gru rightDir = facing ^ 1;

            ChaChar front = field[pos + facing];
            ChaChar right = field[pos + rightDir];
            ChaChar frontright = field[pos + rightDir + facing];

            if (front == 'X' && right == '.') dir ^= 1;
            if (front == '.' && right == '.')
            {
                if (frontright == 'X') pos += facing;
                else dir ^= 1;
            }
            if (front == 'X' && right == 'X') dir ^= 3;
            if (front == '.' && right == 'X') pos += facing;
        }
    }

    public static void Main(String[] args)
    {
        Field field = Field.FromConsole();
        field.Dvanactiminutovka(20);
    }
}
