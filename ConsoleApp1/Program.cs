// Program
using System.Globalization;
using System.Runtime.CompilerServices;
using CsvHelper;
using CsvHelper.Configuration;

var produkty = new List<Produkt>
{
    new Produkt("Laptop", 3500m, 5),
    new Produkt("Mysz", 150m, 23),
    new Produkt("Monitor", 1200m, 8),
    new Produkt("Klawiatura", 280m, 15),
};
var produkty2 = new List<Produkt2>
{
    new Produkt2("Laptop", 3500m, 5, "Elektronika"),
    new Produkt2("Mysz", 150m, 23, "Elektronika"),
    new Produkt2("Monitor", 1200m, 8, "Elektronika"),
    new Produkt2("Biurko", 800m, 10, "Meble"),
    new Produkt2("Krzesło", 600m, 15, "Meble"),
    new Produkt2("Szafa", 1500m, 3, "Meble"),
    new Produkt2("Zeszyt", 15m, 200, "Papiernicze"),
    new Produkt2("Długopis", 5m, 500, "Papiernicze"),
};


// Wypisuje tylko produkty których wartość całkowita (cena × ilość) jest większa niż 5000 zł
var over5000 = produkty.Where(p => p.WartoscCalkowita()>5000).OrderByDescending(p=> p.WartoscCalkowita()).ToList();
Console.WriteLine("Warstość całkowita ponad 5000");
foreach (var p in over5000)
    Console.WriteLine(p);



//Na końcu wypisuje ile takich produktów znalazłeś
Console.WriteLine(over5000.Count());

//sortowanie po kategorii

var sortedCat = produkty2
    .GroupBy(p => p.Kategoria)
    .Select(grupa => new
    {
        Nazwa = grupa.Key,
        Suma = grupa.Sum(p => p.WartoscCalkowita())
    });

foreach(var p in sortedCat) 
    Console.WriteLine($"{p.Nazwa}: {p.Suma:C} zl");

// Największa kategoria
Console.WriteLine(sortedCat.MaxBy(p => p.Suma));



var produkty3= new List<Produkt> { };
var plik = File.ReadAllLines("produkty.txt");
foreach (var line in plik)
{
    var produkt = line.Split(',');
    produkty3.Add(new Produkt(produkt[0], decimal.Parse(produkt[1]), int.Parse(produkt[2])));
}
foreach (var  produkt in produkty3)
{
    Console.WriteLine(produkt);
}

Console.WriteLine("\n--- Rozdzial 2 ---\n");

using (var reader = new StreamReader("sprzedaz.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<Sprzedaz>().ToList();

    //zad 1 wszystjkie ceny

    var allPrice = records
        .GroupBy(p => p.Kategoria)
        .Select(grupa => new
        {
            Nazwa = grupa.Key,
            Suma = grupa.Sum(p => p.WartoscCalkowita())
        });

    foreach (var record in allPrice)
        Console.WriteLine($"{record.Nazwa}: {record.Suma} zl ");

    //zad 2 top 3 sprzedaży

    var allSales = records
        .OrderByDescending(p => p.WartoscCalkowita())
        .Take(3)
        .ToList();
    Console.WriteLine("Najelpiej sprzedające sie produkty");
    int counter = 1;
    foreach(var record in allSales)
    {
        Console.WriteLine($"{counter}. {record.Produkt} - {record.WartoscCalkowita()}"); 
        counter++;
    }
    //zad 3 top miesiac 

    var monthlySales = records
        .GroupBy(p => p.Data.Month)
        .Select(u => new
        {
            Nazwa = u.Key,
            Suma = u.Sum(p => p.WartoscCalkowita())
        })
        //.OrderByDescending(p =>p.Suma)
        .ToList();
    foreach (var record in monthlySales)
    {
        Console.WriteLine($"{record.Nazwa}: {record.Suma}");
    }


}


Console.WriteLine("\n--- Rozdzial 3 ---\n");
/*
var produkty3= new List<Produkt> { };
var plik = File.ReadAllLines("produkty.txt");
foreach (var line in plik)
{
    var produkt = line.Split(',');
    produkty3.Add(new Produkt(produkt[0], decimal.Parse(produkt[1]), int.Parse(produkt[2])));
}
foreach (var  produkt in produkty3)
{
    Console.WriteLine(produkt);
}
 */
var sprzedaz = new List<Sprzedaz> { };
var plik_brudny = File.ReadAllLines("sprzedaz_brudna.csv");
int line_counter = 1;
foreach (var line in plik_brudny)
{
   
    var produkt = line.Split(',');
    int counter = 0;
    string filler = "";
    foreach (var x in produkt)
    {
        //0,1,2,3,4
        if (counter == 0) filler = "nazwy produktu";
        else if (counter == 1) filler = "kategorii";
        else if (counter == 2) filler = "ceny";
        else if (counter == 3) filler = "ilosci";
        else filler = "daty";


        if (x == string.Empty)
        {
            Console.WriteLine($"Błąd w lini {line_counter}: brak " + filler);
        }
        else
        {
            switch (counter)
            {
                case 2:
                    if (int.TryParse(x, out int parse));
                    else Console.WriteLine($"Błąd w lini {line_counter}: niepoprawna cena - {x}");
                    break;
                case 3:
                    if (decimal.TryParse(x, out decimal parse1)) ;
                    else Console.WriteLine($"Błąd w lini {line_counter}: niepoprawna ilosc - {x}");
                    break;
                case 4:

                    if (DateTime.TryParse(x, out DateTime parse2)) ;
                    else Console.WriteLine($"Błąd w lini {line_counter}: niepoprawna data - {x}");
                    break;
            }

        }
        counter++;

    }
    line_counter++;
}


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

class Produkt2
{
    public string Nazwa { get; set; }
    public decimal Cena { get; set; }
    public int Ilosc { get; set; }
    public string Kategoria { get; set; }

    public Produkt2(string nazwa, decimal cena, int ilosc, string kategoria)
    {
        Nazwa = nazwa;
        Cena = cena;
        Ilosc = ilosc;
        Kategoria = kategoria;
    }

    public decimal WartoscCalkowita()
    {
        return Cena * Ilosc;
    }

    public override string ToString()
    {
        return $"{Nazwa} | {Cena:C} | szt: {Ilosc} | kat: {Kategoria}";
    }
}

class Sprzedaz
{
    public string Produkt { get; set; }
    public string Kategoria { get; set; }
    public decimal Cena { get; set; }
    public int Ilosc { get; set; }
    public DateTime Data { get; set; }

    public decimal WartoscCalkowita()
    {
        return Cena * Ilosc;
    }
}
