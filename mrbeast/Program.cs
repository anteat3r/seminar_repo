using ChaChar = char;

class MrBeast {
  public static void Main(String[] args) {
    int width = (int)Convert.ToInt64(Console.ReadLine());
    int height = (int)Convert.ToInt64(Console.ReadLine());

    List<List<ChaChar>> field = [];

    List<Int32> diddyblud = []; // x y dir

    for (int i = 0; i < height; i++) {
      List<ChaChar> row = (Console.ReadLine() ?? "").ToCharArray().ToList();
      List<ChaChar> bludi = row.FindAll((c) => "<>^v".Contains(c));
      if (bludi.Count() > 0) {
        diddyblud = [row.IndexOf(bludi.First()), i, ">^<v".IndexOf(bludi.First())];
        row[diddyblud[0]] = '.';
      }
      field.Add(row);
    }

    List<List<Int32>> dirs = [[1, 0], [0, -1], [-1, 0], [0, 1]];

    for (int i = 0; i < 20; i++) {
      ChaChar front = field[diddyblud[1]+dirs[diddyblud[2]][1]][diddyblud[0]+dirs[diddyblud[2]][0]];
      ChaChar right = field[diddyblud[1]+dirs[(diddyblud[2]+3)%4][1]][diddyblud[0]+dirs[(diddyblud[2]+3)%4][0]];
      ChaChar frontright = field[diddyblud[1]+dirs[(diddyblud[2]+3)%4][1]+dirs[(diddyblud[2]+0)%4][1]][diddyblud[0]+dirs[(diddyblud[2]+3)%4][0]+dirs[(diddyblud[2]+0)%4][0]];

      if (front == 'X' && right == '.') diddyblud[2] = (diddyblud[2] + 3) % 4;
      if (front == '.' && right == '.') {
        if (frontright == 'X') {
          diddyblud[0] += dirs[diddyblud[2]][0];
          diddyblud[1] += dirs[diddyblud[2]][1];
        } else diddyblud[2] = (diddyblud[2] + 3) % 4;
      }
      if (front == 'X' && right == 'X') diddyblud[2] = (diddyblud[2] + 1) % 4;
      if (front == '.' && right == 'X') {
        diddyblud[0] += dirs[diddyblud[2]][0];
        diddyblud[1] += dirs[diddyblud[2]][1];
      }

      field[diddyblud[1]][diddyblud[0]] = ">^<v"[diddyblud[2]];
      foreach (List<ChaChar> row in field) Console.WriteLine(new String(row.ToArray()));
      Console.WriteLine("\n");
      field[diddyblud[1]][diddyblud[0]] = '.';
    }
  }
}
