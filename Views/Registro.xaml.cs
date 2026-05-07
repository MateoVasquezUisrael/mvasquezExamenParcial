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
		if(countryPicker.SelectedIndex == -1 || cityPicker.SelectedIndex == -1)
		{
			await DisplayAlertAsync("Error", "Seleccione un pais y una ciudad", "Ok");
			return;
		}

		if
    }
}