using PlanetShoes.Core.Enums;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlanetShoes.ViewModels
{
    public class CabedalViewModel : ViewModelBase
    {
        private readonly IEstruturaRepository _estruturaRepository;
        private readonly IPecaRepository _pecaRepository;

        public CabedalViewModel(IEstruturaRepository estruturaRepository, IPecaRepository pecaRepository)
        {
            _estruturaRepository = estruturaRepository;
            _pecaRepository = pecaRepository;

            // Inicializa as coleções
            EstruturasComPecaCabedal = new ObservableCollection<SubEstruturaComPecaCabedal>();
            DesignsCabedal = new ObservableCollection<DesignCabedal>();
            PecasDaEstruturaSelecionada = new ObservableCollection<Peca>();

            // Carrega as estruturas e designs
            CarregarEstruturasComPecaCabedal();
            CarregarDesignsCabedal();
        }

        // Propriedades para as estruturas
        
        private ObservableCollection<DesignCabedal> _designsCabedal;
        public ObservableCollection<DesignCabedal> DesignsCabedal
        {
            get => _designsCabedal;
            set => SetProperty(ref _designsCabedal, value);
        }

        private ObservableCollection<SubEstruturaComPecaCabedal> _estruturasComPecaCabedal;
        public ObservableCollection<SubEstruturaComPecaCabedal> EstruturasComPecaCabedal
        {
            get => _estruturasComPecaCabedal;
            set => SetProperty(ref _estruturasComPecaCabedal, value);
        }

        private SubEstruturaComPecaCabedal _estruturaSelecionada;
        public SubEstruturaComPecaCabedal EstruturaSelecionada
        {
            get => _estruturaSelecionada;
            set
            {
                if (SetProperty(ref _estruturaSelecionada, value))
                {
                    // Carrega as peças da estrutura selecionada
                    CarregarPecasDaEstruturaSelecionada();
                    // Seleciona a primeira peça por padrão
                    PecaSelecionada = PecasDaEstruturaSelecionada.FirstOrDefault();
                }
            }
        }

        // Propriedades para as peças da estrutura selecionada
        private ObservableCollection<Peca> _pecasDaEstruturaSelecionada;
        public ObservableCollection<Peca> PecasDaEstruturaSelecionada
        {
            get => _pecasDaEstruturaSelecionada;
            set => SetProperty(ref _pecasDaEstruturaSelecionada, value);
        }

        private Peca _pecaSelecionada;
        public Peca PecaSelecionada
        {
            get => _pecaSelecionada;
            set
            {
                if (SetProperty(ref _pecaSelecionada, value))
                {
                    // Notifica a View sobre mudanças nas propriedades da peça selecionada
                    OnPropertyChanged(nameof(NomePeca));
                    OnPropertyChanged(nameof(Descricao));
                    OnPropertyChanged(nameof(Tamanho));
                    OnPropertyChanged(nameof(Consumo));
                    OnPropertyChanged(nameof(ImgPeca));
                }
            }
        }

        // Propriedades para os campos de texto (vinculadas à PecaSelecionada)
        public AgrupamentoPeca Agrupamento
        {
            get => PecaSelecionada?.Agrupamento?? default(AgrupamentoPeca); // Valor padrão do enum*/
            set
            {
                if (PecaSelecionada != null)
                {
                    PecaSelecionada.Agrupamento = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Codigo
        {
            get => PecaSelecionada.Codigo;
            set
            {
                if (PecaSelecionada != null)
                {
                    PecaSelecionada.Codigo = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Consumo
        {
            get => PecaSelecionada?.Consumo ?? 0;
            set
            {
                if (PecaSelecionada != null)
                {
                    PecaSelecionada.Consumo = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Descricao
        {
            get => PecaSelecionada?.Descricao;
            set
            {
                if (PecaSelecionada != null)
                {
                    PecaSelecionada.Descricao = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte[] ImgPeca
        {
            get => PecaSelecionada?.ImgPeca;
            set
            {
                if (PecaSelecionada != null)
                {
                    PecaSelecionada.ImgPeca = value;
                    OnPropertyChanged();
                }
            }
        }
        public string NomePeca
        {
            get => PecaSelecionada?.Nome;
            set
            {
                if (PecaSelecionada != null)
                {
                    PecaSelecionada.Nome = value;
                    OnPropertyChanged();
                }
            }
        }
        public TamanhoPeca Tamanho
        {
            //get => (TamanhoPeca)(PecaSelecionada?.Tamanho);
            get => PecaSelecionada?.Tamanho ?? default(TamanhoPeca); // Valor padrão do enum
            set
            {
                if (PecaSelecionada != null)
                {
                    PecaSelecionada.Tamanho = value;
                    OnPropertyChanged();
                }
            }
        }


        // Métodos para carregar dados
        private async void CarregarEstruturasComPecaCabedal()
        {
            var estruturas = await _estruturaRepository.GetAllEstruturasAsync();
            var estruturasFiltradas = estruturas
                .OfType<SubEstruturaComPecaCabedal>() // Filtra apenas estruturas do tipo SubEstruturaComPecaCabedal
                .ToList();

            EstruturasComPecaCabedal = new ObservableCollection<SubEstruturaComPecaCabedal>(estruturasFiltradas);
        }

        private void CarregarDesignsCabedal()
        {
            // Carrega todos os valores do enum DesignCabedal
            var designsCabedal = System.Enum.GetValues(typeof(DesignCabedal))
                .Cast<DesignCabedal>()
                .ToList();

            DesignsCabedal = new ObservableCollection<DesignCabedal>(designsCabedal);
        }

        private async void CarregarPecasDaEstruturaSelecionada()
        {
            if (EstruturaSelecionada != null)
            {
                // Carrega as peças da estrutura selecionada
                var pecas = await _pecaRepository.GetPecasByEstruturaIdAsync(EstruturaSelecionada.IdEstrutura);
                PecasDaEstruturaSelecionada = new ObservableCollection<Peca>(pecas);
            }
            else
            {
                // Limpa a lista de peças se nenhuma estrutura estiver selecionada
                PecasDaEstruturaSelecionada.Clear();
            }
        }
    }
}