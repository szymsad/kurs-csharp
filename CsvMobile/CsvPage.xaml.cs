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

            statusLabel.Text = $"Wybrano: {wynik.FileName}";
        }
        catch (Exception ex)
        {
            statusLabel.Text = $"Błąd: {ex.Message}";
        }
    }
}