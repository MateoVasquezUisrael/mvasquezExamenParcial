namespace mvasquezExamenParcial.Views;

public partial class Resumen : ContentPage
{
    private String user;
    public Resumen(String user, String name, String lastname, string age, 
		DateOnly date, String city, String country, decimal amouthPayed, decimal monthlyPay)
	{
		InitializeComponent();

        this.user = user;

        connectedUserLabel.Text = $"Usuario conectado: {this.user}";
        nombreLabel.Text = name;
        apellidoLabel.Text = lastname;
        edadLabel.Text = age;
        fechaLabel.Text = date.ToString();
        ciudadLabel.Text = city;
        paisLabel.Text = country;
        edadLabel.Text = country;
        montoInicialLabel.Text = amouthPayed.ToString();
        pagoMensualLabel.Text = monthlyPay.ToString();

        decimal totalPayed = amouthPayed + (monthlyPay * 4);

        pagoTotalLabel.Text = totalPayed.ToString();

    }
}