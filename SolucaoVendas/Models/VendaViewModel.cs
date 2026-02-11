using System.ComponentModel;
using SolucaoVendas.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SolucaoVendas.ViewModels
{
    public class VendaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Produto> Produtos { get; set; }
        public ObservableCollection<Cliente> Cliente { get; set; }
        public ObservableCollection<int> QuantParcela { get; set; }


        public ICommand SalvarCommand { get; }

        // lista de clientes e produtos ----------------------------------------------------------------
        public VendaViewModel()
        {
            //lista de produtos ------------------------------------------------------------------------
            Produtos = new ObservableCollection<Produto>
            {
                new Produto { Nome = "Motor", PercentualComissao = 3 },
                new Produto { Nome = "Balança", PercentualComissao = 8 },
                new Produto { Nome = "Esteira", PercentualComissao = 5 }
            };
            //lista de clientes ------------------------------------------------------------------------
            Cliente = new ObservableCollection<Cliente>
            {
                new Cliente { Nome = "Cliente A" },
                new Cliente { Nome = "Cliente B" },
                new Cliente { Nome = "Cliente C" }
            };

            //lista de parcelas ---------------------------------------------------------------------------
            QuantParcela = new ObservableCollection<int> { 1, 3, 6, 9, 12 };

            SalvarCommand = new Command(Salvar);

        }

        private async void Salvar()
        {
            if (ValorVenda <= 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Atenção",
                    "Informe um valor de venda válido.",
                    "OK");
                return;
            }

            if (ProdutoSelecionado == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Atenção",
                    "Selecione um produto.",
                    "OK");
                return;
            }

            if (ClienteSelecionado == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Atenção",
                    "Selecione um cliente.",
                    "OK");
                return;
            }

            if(ParcelaSelecionado == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Atenção",
                    "Selecione a quantidade de parcelas.",
                    "OK");
                return;
            }

            await Application.Current.MainPage.DisplayAlert(
                "Sucesso",
                "Venda salva com sucesso!",
                "OK");

            var venda = new Venda
            {
                Cliente = ClienteSelecionado,
                Produto = ProdutoSelecionado,
                ValorTotal = ValorVenda,
                DataVenda = DateTime.Now
            };

            decimal valorParcela = ValorCalculado / ParcelaSelecionado;

            for (int i = 1; i <= ParcelaSelecionado; i++)
            {
                venda.Parcelas.Add(new Parcela
                {
                    Numero = i,
                    Valor = valorParcela,
                    DataVencimento = DateTime.Now.AddMonths(i),
                    Status = StatusParcela.NaoPaga
                });
            }

        }

        //clientes selecionado -----------------------------------------------------------------------
        private Cliente clienteSelecionado;
        public Cliente ClienteSelecionado
        {
            get => clienteSelecionado;
            set
            {
                clienteSelecionado = value;
                OnPropertyChanged(nameof(ClienteSelecionado));
            }
        }

        //Parcelas selecionado-----------------------------------------------------------------------------------
        private int parcelaSelecionado;
        public int ParcelaSelecionado
        {
            get => parcelaSelecionado;
            set
            {
                parcelaSelecionado = value;
                OnPropertyChanged(nameof(ParcelaSelecionado));
            }
        }


        //produto comandos ------------------------------------------------------------------------

        private Produto produtoSelecionado;
        public Produto ProdutoSelecionado
        {
            get => produtoSelecionado;
            set
            {
                produtoSelecionado = value;
                OnPropertyChanged(nameof(ProdutoSelecionado));

                if (produtoSelecionado != null)
                {
                    Percentual = produtoSelecionado.PercentualComissao;
                }
            }
        }

        

        private decimal valorVenda;
        public decimal ValorVenda
        {
            get => valorVenda;
            set
            {
                valorVenda = value;
                OnPropertyChanged(nameof(ValorVenda));
                Recalcular();
            }
        }

        private decimal percentual;
        public decimal Percentual
        {
            get => percentual;
            set
            {
                percentual = value;
                OnPropertyChanged(nameof(Percentual));
                Recalcular();
            }
        }

        private decimal valorCalculado;
        public decimal ValorCalculado
        {
            get => valorCalculado;
            private set
            {
                valorCalculado = value;
                OnPropertyChanged(nameof(ValorCalculado));
            }
        }

        private void Recalcular()
        {
            ValorCalculado = ValorVenda * (Percentual / 100);
        }

        //bloco salvar ---------------------------------------------------------------------


        private void OnPropertyChanged(string nome)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
        }
    }
}
