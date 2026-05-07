namespace mvasquezExamenParcial.Views;

public partial class Registro : ContentPage
{
    private String user;
    private String password;
    public Registro(String user, String password)
    {
        InitializeComponent();
        this.user = user;
        this.password = password;
        LabelSaludo.Text = $"Usuario conectado: {this.user}";
    }

    private async void resumeButton_Pressed(object sender, EventArgs e)
    {
        // Verificar país y ciudad seleccionados
        if (countryPicker.SelectedIndex == -1 || cityPicker.SelectedIndex == -1)
        {
            await DisplayAlertAsync("Error", "Seleccione un país y una ciudad", "Ok");
            return;
        }

        // Verificar que el monto no esté vacío y sea numérico válido
        if (string.IsNullOrWhiteSpace(originalAmountEntry.Text) ||
            !decimal.TryParse(originalAmountEntry.Text, out decimal monto) ||
            monto <= 0)
        {
            await DisplayAlertAsync("Error", "Ingrese un monto válido mayor a 0", "Ok");
            return;
        }

        // Verificar nombre, apellido y edad
        if (string.IsNullOrWhiteSpace(nameInput.Text) ||
            string.IsNullOrWhiteSpace(lastnameInput.Text))
        {
            await DisplayAlertAsync("Error", "Ingrese nombre y apellido", "Ok");
            return;
        }

        if (string.IsNullOrWhiteSpace(ageInput.Text) ||
            !int.TryParse(ageInput.Text, out int edad) ||
            edad <= 0 || edad > 120)
        {
            await DisplayAlertAsync("Error", "Ingrese una edad válida", "Ok");
            return;
        }

        // Verificar que la fecha no sea futura (opcional, según lógica de negocio)
        if (datePicker.Date > DateTime.Today)
        {
            await DisplayAlertAsync("Error", "La fecha no puede ser futura", "Ok");
            return;
        }

        DateOnly birthDate = DateOnly.FromDateTime(datePicker.Date ?? DateTime.Today);

        string city = cityPicker.SelectedItem.ToString();
        string country = countryPicker.SelectedItem.ToString();

        // Navegar al resumen pasando los datos
        await Navigation.PushAsync(new Resumen(
     user,
     nameInput.Text,
     lastnameInput.Text,
     ageInput.Text,
     birthDate,
     city,
     country,
     decimal.Parse(originalAmountEntry.Text),
     decimal.Parse(monthlyPayEntry.Text)  // pass the decimal directly, not the display string
 ));
    }

    private void calcButton_Pressed(object sender, EventArgs e)
    {
        if (!decimal.TryParse(originalAmountEntry.Text, out decimal value))
        {
            // Handle invalid input
            monthlyPayEntry.Text = "Invalid input";
            return;
        }

        const decimal totalAmount = 1500m;
        const decimal interestRate = 0.04m;
        const int installments = 4;

        decimal remaining = totalAmount - value;
        decimal monthlyPrincipal = remaining / installments;
        decimal monthlyInterest = totalAmount * interestRate; // Interest on remaining balance
        decimal monthlyPayment = monthlyPrincipal + monthlyInterest;

        monthlyPayEntry.Text = monthlyPayment.ToString("F2"); // Format to 2 decimal places
    }
}
