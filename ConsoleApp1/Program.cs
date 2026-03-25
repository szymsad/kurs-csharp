// Program
var produkty = new List<Produkt>
{
    new Produkt("Laptop", 3500m, 5),
    new Produkt("Mysz", 150m, 23),
    new Produkt("Monitor", 1200m, 8),
    new Produkt("Klawiatura", 280m, 15),
};


// Wypisuje tylko produkty których wartość całkowita (cena × ilość) jest większa niż 5000 zł
var over5000 = produkty.Where(p => p.WartoscCalkowita()>5000).OrderByDescending(p=> p.WartoscCalkowita()).ToList();
Console.WriteLine("Warstość całkowita ponad 5000");
foreach (var p in over5000)
    Console.WriteLine(p);



//Na końcu wypisuje ile takich produktów znalazłeś
Console.WriteLine(over5000.Count());

// Definicja klasy - ZAWSZE na dole w tym stylu pisania
class Produkt
{
    public string Nazwa { get; set; }
    public decimal Cena { get; set; }
    public int Ilosc { get; set; }

    public Produkt(string nazwa, decimal cena, int ilosc)
    {
        Nazwa = nazwa;
        Cena = cena;
        Ilosc = ilosc;
    }

    public decimal WartoscCalkowita()
    {
        return Cena * Ilosc;
    }

    public override string ToString()
    {
        return $"{Nazwa} | {Cena:C} | szt: {Ilosc}";
    }
}