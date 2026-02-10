namespace SolucaoVendas.Pages;

public partial class PgDespesas : ContentPage
{
	public PgDespesas()
	{
		InitializeComponent();
	}

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}