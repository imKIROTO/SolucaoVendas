using System.Collections.ObjectModel;
using SolucaoVendas.Models;
using System.Linq;

namespace SolucaoVendas.ViewModels
{
    public class ResumoViewModel
    {
        public ObservableCollection<Venda> Vendas { get; set; }
            = new ObservableCollection<Venda>();

        public decimal TotalRecebido =>
            Vendas
                .SelectMany(v => v.Parcelas)
                .Where(p => p.Status == StatusParcela.Paga)
                .Sum(p => p.Valor);
    }
}
