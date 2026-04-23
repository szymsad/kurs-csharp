using System.Globalization;
using CsvHelper;

namespace CsvMobile;

public partial class CsvPage : ContentPage
{
    public CsvPage()
    {
        InitializeComponent();
    }

    private async void WczytajPlik(object sender, EventArgs e)
    {
        try
        {
            var wynik = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Wybierz plik CSV",
                FileTypes = new FilePickerFileType(
                    new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                    { DevicePlatform.Android, new[] { "text/csv", "text/comma-separated-values" } }
                    })
            });

            if (wynik == null) return;

            using var stream = await wynik.OpenReadAsync();
            var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var rekordy = csv.GetRecords<Sprzedaz>().ToList();

            statusLabel.Text = $"Wczytano {rekordy.Count} rekordów";
            listaRekordow.ItemsSource = rekordy;


            var statystyki = rekordy
                .GroupBy(p => p.Kategoria)
                .Select(g => new { Nazwa = g.Key, Suma = g.Sum(p => p.WartoscCalkowita()) })
                .ToList();

            listaStatystyk.ItemsSource = statystyki;
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Błąd: {ex.Message}";
        }
    }

    class Sprzedaz
    {
        public string Produkt { get; set; }
        public string Kategoria { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        public DateTime Data { get; set; }
        public decimal WartoscCalkowita() => Cena * Ilosc;
    }
}