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

        bool categoreis = true;

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


        private void chartType_Click(object sender, EventArgs e)
        {
            categoreis = !categoreis;
            if (categoreis)
            {
                var grupy = _records
                    .GroupBy(p => p.Kategoria)
                    .Select(g => new { Nazwa = g.Key, Suma = (double)g.Sum(p => p.WartoscCalkowita()) })
                    .ToList();

                OdswiezWykres(grupy.Select(g => g.Nazwa).ToList(), grupy.Select(g => g.Suma).ToList());
                chartType.Text = "Produkty";
            }
            else
            {
                var grupy = _records
                    .GroupBy(p => p.Produkt)
                    .Select(g => new { Nazwa = g.Key, Suma = (double)g.Sum(p => p.WartoscCalkowita()) })
                    .ToList();

                OdswiezWykres(grupy.Select(g => g.Nazwa).ToList(), grupy.Select(g => g.Suma).ToList());
                chartType.Text = "Kategorie";
            }
        }

        private void dateChanged()
        {
            if (categoreis)
            {
                var grupy = _records
                    .Where(p => p.Data > dateFrom.Value && p.Data < dateTo.Value)
                    .GroupBy(p => p.Kategoria)
                    .Select(g => new { Nazwa = g.Key, Suma = (double)g.Sum(p => p.WartoscCalkowita()) })
                    .ToList();

                OdswiezWykres(grupy.Select(g => g.Nazwa).ToList(), grupy.Select(g => g.Suma).ToList());
            }
            else
            {
                var grupy = _records
                    .Where(p => p.Data > dateFrom.Value && p.Data < dateTo.Value)
                    .GroupBy(p => p.Produkt)
                    .Select(g => new { Nazwa = g.Key, Suma = (double)g.Sum(p => p.WartoscCalkowita()) })
                    .ToList();

                OdswiezWykres(grupy.Select(g => g.Nazwa).ToList(), grupy.Select(g => g.Suma).ToList());
            }
        }
        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            dateChanged();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            dateChanged();
        }
        private void OdswiezWykres(List<string> nazwy, List<double> wartosci)
        {
            chart.Series = new ISeries[]
            {
        new ColumnSeries<double>
        {
            Name = "Wartość sprzedaży",
            Values = wartosci.ToArray()
        }
            };
            chart.XAxes = new Axis[]
            {
        new Axis
        {
            Labels = nazwy.ToArray()
        }
            };
        }

        private void export_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "PNG files (*.png)|*.png",
                FileName = "wykres.png"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var bitmap = new Bitmap(panel2.Width, panel2.Height);
                panel2.DrawToBitmap(bitmap, new Rectangle(0, 0, panel2.Width, panel2.Height));
                bitmap.Save(dialog.FileName);
                MessageBox.Show("Wykres zapisany!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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