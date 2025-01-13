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
        private readonly IMateriaPrimaRepository _materiaPrimaRepository;

        public CabedalViewModel(IEstruturaRepository estruturaRepository, IPecaRepository pecaRepository, IMateriaPrimaRepository materiaPrimaRepository)
        {
            _estruturaRepository = estruturaRepository;
            _pecaRepository = pecaRepository;
            _materiaPrimaRepository = materiaPrimaRepository;

            // Inicializa as coleções
            EstruturasComPecaCabedal = new ObservableCollection<SubEstruturaComPecaCabedal>();
            DesignsCabedal = new ObservableCollection<DesignCabedal>();
            PecasDaEstruturaSelecionada = new ObservableCollection<Peca>();
            MateriasPrimas = new ObservableCollection<MateriaPrima>();
            MateriasPrimasDasPecas = new ObservableCollection<MateriaPrima>();

            // Carrega as estruturas e designs
            CarregarEstruturasComPecaCabedal();
            CarregarDesignsCabedal();

            // Seleciona a primeira estrutura automaticamente
            if (EstruturasComPecaCabedal.Any())
            {
                EstruturaSelecionada = EstruturasComPecaCabedal.First();

                // Força o carregamento das matérias-primas das peças da estrutura selecionada
                CarregarPecasDaEstruturaSelecionada().ContinueWith(task =>
                {
                    if (!task.IsFaulted)
                    {
                        CarregarMateriasPrimasDasPecas();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
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

                    // Carrega as matérias-primas das Peças da Estrutura selecionada
                    CarregarMateriasPrimasDasPecas();

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

        // Propriedades para as materias primas das peças da estrutura selecionada
        private ObservableCollection<MateriaPrima> _materiasPrimasDasPecas;
        public ObservableCollection<MateriaPrima> MateriasPrimasDasPecas
        {
            get => _materiasPrimasDasPecas;
            set => SetProperty(ref _materiasPrimasDasPecas, value);
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

                    // Verifica se a peça selecionada é do tipo PecaCabedal ou PecaSolado
                    if (_pecaSelecionada is PecaCabedal pecaCabedal)
                    {
                        OnPropertyChanged(nameof(Data));
                        OnPropertyChanged(nameof(Hora));
                        OnPropertyChanged(nameof(NomeModelo));
                        OnPropertyChanged(nameof(Perimetro));
                        OnPropertyChanged(nameof(Superficie));
                        OnPropertyChanged(nameof(Agrupamento));
                    }
                    else if (_pecaSelecionada is PecaSolado pecaSolado)
                    {
                        OnPropertyChanged(nameof(Peso));
                    }

                    CarregarMateriasPrimasDaPecaByCod();
                }
            }
        }

        // Propriedades para as matérias-primas
        private ObservableCollection<MateriaPrima> _materiasPrimas;
        public ObservableCollection<MateriaPrima> MateriasPrimas
        {
            get => _materiasPrimas;
            set => SetProperty(ref _materiasPrimas, value);
        }

        private MateriaPrima _materiaPrimaSelecionada;
        public MateriaPrima MateriaPrimaSelecionada
        {
            get => _materiaPrimaSelecionada;
            set
            {
                if (SetProperty(ref _materiaPrimaSelecionada, value))
                {
                    OnPropertyChanged(nameof(DescricaoMateriaPrima));
                }
            }
        }

        
        public string DescricaoMateriaPrima
        {
            get => MateriaPrimaSelecionada?.Nome;
            set
            {
                if (PecaSelecionada != null)
                {
                    MateriaPrimaSelecionada.Nome = value;
                    OnPropertyChanged();
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

        // Propriedades específicas de PecaCabedal
        public DateTime Data
        {
            get => (_pecaSelecionada as PecaCabedal)?.Data ?? DateTime.MinValue;
            set
            {
                if (_pecaSelecionada is PecaCabedal pecaCabedal)
                {
                    pecaCabedal.Data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }
        public TimeSpan Hora
        {
            get => (_pecaSelecionada as PecaCabedal)?.Hora ?? TimeSpan.Zero;
            set
            {
                if (_pecaSelecionada is PecaCabedal pecaCabedal)
                {
                    pecaCabedal.Hora = value;
                    OnPropertyChanged(nameof(Hora));
                }
            }
        }
        public string NomeModelo
        {
            get => (_pecaSelecionada as PecaCabedal)?.NomeModelo;
            set
            {
                if (_pecaSelecionada is PecaCabedal pecaCabedal)
                {
                    pecaCabedal.NomeModelo = value;
                    OnPropertyChanged(nameof(NomeModelo));
                }
            }
        } 
        public float Perimetro
        {
            get => (_pecaSelecionada as PecaCabedal)?.Perimetro ?? 0;
            set
            {
                if (_pecaSelecionada is PecaCabedal pecaCabedal)
                {
                    pecaCabedal.Perimetro = value;
                    OnPropertyChanged(nameof(Perimetro));
                }
            }
        }
        public float Superficie
        {
            get => (_pecaSelecionada as PecaCabedal)?.Superficie ?? 0;
            set
            {
                if (_pecaSelecionada is PecaCabedal pecaCabedal)
                {
                    pecaCabedal.Superficie = value;
                    OnPropertyChanged(nameof(Superficie));
                }
            }
        }

        // Propriedades específicas de PecaSolado
        public float Peso
        {
            get => (_pecaSelecionada as PecaSolado)?.Peso ?? 0;
            set
            {
                if (_pecaSelecionada is PecaSolado pecaCabedal)
                {
                    pecaCabedal.Peso = value;
                    OnPropertyChanged(nameof(Peso));
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

            // Seleciona a primeira estrutura automaticamente
            if (EstruturasComPecaCabedal.Any())
            {
                EstruturaSelecionada = EstruturasComPecaCabedal.First();
            }
        }

        private void CarregarDesignsCabedal()
        {
            // Carrega todos os valores do enum DesignCabedal
            var designsCabedal = System.Enum.GetValues(typeof(DesignCabedal))
                .Cast<DesignCabedal>()
                .ToList();

            DesignsCabedal = new ObservableCollection<DesignCabedal>(designsCabedal);
        }

        private async Task CarregarPecasDaEstruturaSelecionada()
        {
            if (EstruturaSelecionada != null)
            {
                PecasDaEstruturaSelecionada.Clear();

                // Carrega as peças da estrutura selecionada
                var pecas = await _pecaRepository.GetPecasByEstruturaIdAsync(EstruturaSelecionada.IdEstrutura);
                PecasDaEstruturaSelecionada = new ObservableCollection<Peca>(pecas);

                // Seleciona a primeira peça automaticamente
                if (PecasDaEstruturaSelecionada.Any())
                {
                    PecaSelecionada = PecasDaEstruturaSelecionada.First();
                }

                // Carrega as matérias-primas das peças da estrutura selecionada
                await CarregarMateriasPrimasDasPecas();
            }
            else
            {
                // Limpa a lista de peças se nenhuma estrutura estiver selecionada
                PecasDaEstruturaSelecionada.Clear();
            }
        }

        private async void CarregarMateriasPrimasDaPeca()
        {
            if (PecaSelecionada != null && !string.IsNullOrEmpty(PecaSelecionada.IdMateriaPrima))
            {
                var materiaPrima = await _materiaPrimaRepository.GetByIdAsync(PecaSelecionada.IdMateriaPrima);
                MateriasPrimas = new ObservableCollection<MateriaPrima> { materiaPrima };
                MateriaPrimaSelecionada = materiaPrima;
            }
            else
            {
                MateriasPrimas.Clear();
                MateriaPrimaSelecionada = null;
            }
        }
        private async void CarregarMateriasPrimasDaPecaByCod()
        {
            if (PecaSelecionada != null && !string.IsNullOrEmpty(PecaSelecionada.IdMateriaPrima))
            {
                var materiaPrima = await _materiaPrimaRepository.GetByCodAsync(PecaSelecionada.Codigo);
                MateriasPrimas = new ObservableCollection<MateriaPrima> { materiaPrima };
                MateriaPrimaSelecionada = materiaPrima;
            }
            else
            {
                MateriasPrimas.Clear();
                MateriaPrimaSelecionada = null;
            }
        }
        private async Task CarregarMateriasPrimasDasPecas()
        {
            if (PecasDaEstruturaSelecionada != null && PecasDaEstruturaSelecionada.Any())
            {
                var codigosPecas = PecasDaEstruturaSelecionada.Select(p => p.Codigo).ToList();
                var materiasPrimas = await _materiaPrimaRepository.GetByPecasCodigosAsync(codigosPecas);
                MateriasPrimasDasPecas = new ObservableCollection<MateriaPrima>(materiasPrimas); // Usa a nova lista
            }
            else
            {
                MateriasPrimasDasPecas.Clear(); // Limpa a nova lista
            }
        }
    }
}