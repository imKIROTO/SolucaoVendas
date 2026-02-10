namespace SolucaoVendas.Pages;

public partial class PgCadastros : ContentPage
{
	public PgCadastros()
	{
		InitializeComponent();
	}

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}