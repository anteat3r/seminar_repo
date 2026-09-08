namespace Program {
  internal class Program {
    public static void Main(string[] args) {
      Film rrr = new Film("RRRrrrr!!!", "Alain", "Chabat", 2004);
      Film birdemic = new Film("Birdemic: Shock and Terror", "James", "Nguyen", 2010);
      Film bulk = new Film("The Amazing Bulk", "Lewis", "Schoenbrun", 2012);

      List<Film> films = [rrr, birdemic, bulk];

      var rand = new Random();

      for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 15; j++) {
          films[i].PridatHodnoceni(rand.Next(5));
        }
      }

      foreach (Film film in films) {
        Console.WriteLine($"{film.Nazev}: {film.Hodnoceni} ⭐");
        if (film.Hodnoceni < 3.0f) {
          Console.WriteLine($"*{film.Nazev} je odpad! Má hodnocení jen {film.Hodnoceni}.*");
        }
      }

      films.Sort((f1, f2) => f1.Hodnoceni.CompareTo(f2.Hodnoceni));
      Console.WriteLine($"Nejlepší film: {films.Last()}");

      films.Sort((f1, f2) => f1.Nazev.Length.CompareTo(f2.Nazev.Length));
      Console.WriteLine($"Film s nejdelším názvem: {films.Last()}");
    }
  }

  public class Film {
    public string Nazev = "";
    public string JmenoRezisera = "";
    public string PrijmeniRezisera = "";
    public int RokVzniku = 1900;
    public float Hodnoceni = float.NaN;

    private List<int> SeznamHodnoceni = [];

    public void PridatHodnoceni(int hodnoceni) {
      SeznamHodnoceni.Add(hodnoceni);
      Hodnoceni = (float)SeznamHodnoceni.Average();
    }

    public Film(string nazev, string jmeno, string prijmeni, int rok) {
      Nazev = nazev;
      JmenoRezisera = jmeno;
      PrijmeniRezisera = prijmeni;
      RokVzniku = rok;
    }

    override public string ToString() {
      return $"{Nazev} ({RokVzniku}; {PrijmeniRezisera}, {JmenoRezisera.First()}): {Hodnoceni} ⭐";
    }
  }
}
