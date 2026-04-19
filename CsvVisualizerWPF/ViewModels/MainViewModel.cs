using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Input;
using CsvHelper;
using CsvVisualizerWPF.Models;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace CsvVisualizerWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Sprzedaz> _rekordy = new();
        public ObservableCollection<Sprzedaz> Rekordy
        {
            get => _rekordy;
            set
            {
                _rekordy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rekordy)));
            }
        }

        private string _status = "Brak wczytanych danych";
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }
        public ICommand WczytajCommand { get; }

        public MainViewModel()
        {
            WczytajCommand = new RelayCommand(WczytajCSV);
        }

        private void WczytajCSV()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv"
            };

            if (dialog.ShowDialog() == true)
            {
                using var reader = new StreamReader(dialog.FileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var dane = csv.GetRecords<Sprzedaz>().ToList();
                decimal suma = dane.Sum(p => p.WartoscCalkowita());
                var grupy = dane
                   .GroupBy(p => p.Kategoria)
                   .Select(g => new
                   {
                       Nazwa = g.Key,
                       Suma = (double)g.Sum(p => p.WartoscCalkowita())
                   })
                   .OrderByDescending(p => p.Suma)
                   .ToList();
                Rekordy = new ObservableCollection<Sprzedaz>(dane);
                Status = $"Łączna wartość: {suma} zł | Najlepsza kategoria: {grupy[0].Nazwa}";
                Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Name = "Wartość sprzedaży",
                        Values = grupy.Select(g => g.Suma).ToArray()
                    }
                };

                                XAxes = new Axis[]
                                {
                    new Axis
                    {
                        Labels = grupy.Select(g => g.Nazwa).ToArray()
                    }
                                };
                            }

        }
        private IEnumerable<ISeries> _series;
        public IEnumerable<ISeries> Series
        {
            get => _series;
            set
            {
                _series = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Series)));
            }
        }

        private IEnumerable<Axis> _xAxes;
        public IEnumerable<Axis> XAxes
        {
            get => _xAxes;
            set
            {
                _xAxes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(XAxes)));
            }
        }
    }
}