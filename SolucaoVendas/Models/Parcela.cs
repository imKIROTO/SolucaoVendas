namespace SolucaoVendas.Models
{
    public enum StatusParcela
    {
        NaoPaga,
        Paga,
        Vencida
    }

    public class Parcela
    {
        public int Numero { get; set; }          // 1ª, 2ª, 3ª parcela
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusParcela Status { get; set; }
    }
}
