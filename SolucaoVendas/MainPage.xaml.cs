namespace SolucaoVendas
{
    public partial class MainPage : ContentPage
    {
     

        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnVendas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.PgVendas());
        }

        private void BtnDespesas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.PgDespesas());
        }

        private void BtnResumos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.PgResumos());
        }

        private void BtnCadastros_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.PgCadastros());
        }
    }
}
