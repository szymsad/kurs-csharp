using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvVisualizerWPF.Models
{
    public class Sprzedaz
    {
        public string Produkt { get; set; }
        public string Kategoria { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        public DateTime Data { get; set; }
        public decimal WartoscCalkowita() => Cena * Ilosc;
    }
}
