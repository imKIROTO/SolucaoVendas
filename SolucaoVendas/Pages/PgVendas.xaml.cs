using Microsoft.Maui.Platform;
using SolucaoVendas.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SolucaoVendas.Pages;

public partial class PgVendas : ContentPage
{
    public PgVendas()
    {
        InitializeComponent();
        BindingContext = new VendaViewModel();

        
    }

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
    
}