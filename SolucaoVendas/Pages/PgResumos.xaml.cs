namespace SolucaoVendas.Pages;

public partial class PgResumos : ContentPage
{
	public PgResumos()
	{
		InitializeComponent();
	}

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}