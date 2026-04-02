using CsvVisualizerWPF.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
    }
}