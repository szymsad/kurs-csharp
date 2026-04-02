using CsvHelper;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using System.Globalization;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private CartesianChart chart;
        private DataGridView dataGridView1;
        private Panel panel1;

        private List<Sprzedaz> _records;
        public Form1()
        {
            InitializeComponent();

            // Najpierw panel (Fill wypełnia całą resztę)

            Controls.Add(panel2);

            Controls.Add(dataGridView2);

            // Wykres do panelu
            chart = new CartesianChart
            {
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(chart);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using var reader = new StreamReader(dialog.FileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                _records = csv.GetRecords<Sprzedaz>().ToList();

                dataGridView2.DataSource = _records;

                var grupy = _records
                    .GroupBy(p => p.Kategoria)
                    .Select(g => new
                    {
                        Nazwa = g.Key,
                        Suma = (double)g.Sum(p => p.WartoscCalkowita())
                    })
                    .ToList();

                chart.Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Name = "Wartość sprzedaży",
                        Values = grupy.Select(g => g.Suma).ToArray()
                    }
                };

                chart.XAxes = new Axis[]
                {
                    new Axis
                    {
                        Labels = grupy.Select(g => g.Nazwa).ToArray()
                    }
                };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var grupy = _records
                    .GroupBy(p => p.Produkt)
                    .Select(g => new
                    {
                        Nazwa = g.Key,
                        Suma = (double)g.Sum(p => p.WartoscCalkowita())
                    })
                    .ToList();

            chart.Series = new ISeries[]
            {
                    new ColumnSeries<double>
                    {
                        Name = "Wartość sprzedaży",
                        Values = grupy.Select(g => g.Suma).ToArray()
                    }
            };

            chart.XAxes = new Axis[]
            {
                    new Axis
                    {
                        Labels = grupy.Select(g => g.Nazwa).ToArray()
                    }
            };
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            var grupy = _records
                .GroupBy(p => p.Kategoria)
                .Select(g => new
                {
                    Nazwa = g.Key,
                    Suma = (double)g.Sum(p => p.WartoscCalkowita())
                })
                .ToList();

            chart.Series = new ISeries[]
            {
                    new ColumnSeries<double>
                    {
                        Name = "Wartość sprzedaży",
                        Values = grupy.Select(g => g.Suma).ToArray()
                    }
            };

            chart.XAxes = new Axis[]
            {
                    new Axis
                    {
                        Labels = grupy.Select(g => g.Nazwa).ToArray()
                    }
            };
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