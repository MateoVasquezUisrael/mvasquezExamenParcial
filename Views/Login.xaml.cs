namespace mvasquezExamenParcial.Views;

public partial class Login : ContentPage
{
	private String[,] data = new String[,]
    {
        {"estudiante", "moviles"},
        {"uisrael",     "2025" }
    };

	public Login()
	{
		InitializeComponent();
	}

    private async void loginButton_Pressed(object sender, EventArgs e)
    {
        bool loginSuccess = false;

        for (int i = 0; i < data.GetLength(0); i++)
        {
            if (usernameInput.Text == data[i, 0] && passwordInput.Text == data[i, 1])
            {
                loginSuccess = true;
                await Navigation.PushAsync(new Registro(data[i, 0], data[i, 1]));
                break;
            }
        }

        if (!loginSuccess)
        {
            await DisplayAlertAsync("Error", "Usuario o contraseña incorrecto", "OK");
        }
    }
}