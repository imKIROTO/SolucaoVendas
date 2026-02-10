using System.Collections.ObjectModel;

namespace SolucaoVendas.Models
{
    public class Venda
    {
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }

        public ObservableCollection<Parcela> Parcelas { get; set; }
            = new ObservableCollection<Parcela>();
    }
}
