using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.ViewModels
{
    using PlanetShoes.Core.Commands;
    using PlanetShoes.Core.Enums;
    using PlanetShoes.Core.Interfaces;
    using PlanetShoes.Infrastructure.Data;
    using PlanetShoes.Infrastructure.Repositories;
    using PlanetShoes.ViewModels;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    public class EstruturaViewModel : ViewModelBase
    {
        private readonly IEstruturaRepository _estruturaRepository;
        private readonly IPecaRepository _pecaRepository;
        
        // Commands
        public ICommand AdicionarEstruturaCommand { get; }
        public ICommand EditarEstruturaCommand { get; }
        public ICommand ExcluirEstruturaCommand { get; }
        public ICommand CarregarPecasPorTipoCommand { get; }


        // Construtor
        public EstruturaViewModel(IEstruturaRepository estruturaRepository,
                                  IPecaRepository pecaRepository,
                                  IMateriaPrimaRepository materiaPrimaRepository)
        {
            _estruturaRepository = estruturaRepository ?? throw new ArgumentNullException(nameof(estruturaRepository));
            _pecaRepository = pecaRepository ?? throw new ArgumentNullException(nameof(pecaRepository));
           
            CarregarEstruturas();
            Pecas = new ObservableCollection<Peca>(); // Inicializa a lista de peças
        }

        // Propriedades
        private List<Estrutura> _estruturas;
        public List<Estrutura> Estruturas
        {
            get => _estruturas;
            set => SetProperty(ref _estruturas, value);
        }

        private Estrutura _estruturaSelecionada;
        public Estrutura EstruturaSelecionada
        {
            get => _estruturaSelecionada;
            set
            {
                SetProperty(ref _estruturaSelecionada, value);
                CarregarPecasPorEstruturaSelecionada();
            }
        }

        private Estrutura _estruturaCompleta;
        public Estrutura EstruturaCompleta
        {
            get => _estruturaCompleta;
            set => SetProperty(ref _estruturaCompleta, value);
        }

        private Peca _pecaSelecionada;
        public Peca PecaSelecionada
        {
            get => _pecaSelecionada;
            set
            {
                SetProperty(ref _pecaSelecionada, value);
            }
        }

        private MateriaPrima _materiaPrimaDaPeca;
        public MateriaPrima MateriaPrimaDaPeca
        {
            get => _materiaPrimaDaPeca;
            set => SetProperty(ref _materiaPrimaDaPeca, value);
        }


        // Propriedade para armazenamento
        private ObservableCollection<MateriaPrima> _materiasPrimas;
        public ObservableCollection<MateriaPrima> MateriasPrimas
        {
            get => _materiasPrimas;
            set => SetProperty(ref _materiasPrimas, value);
        }

        private ObservableCollection<Peca> _pecas;
        public ObservableCollection<Peca> Pecas
        {
            get => _pecas;
            set => SetProperty(ref _pecas, value);
        }


        
        // Métodos
        private async void CarregarEstruturas()
        {
            Estruturas = await _estruturaRepository.GetAllEstruturasAsync();
        }

        private async void CarregarPecasPorEstruturaSelecionada()
        {
            if (EstruturaSelecionada != null && !string.IsNullOrEmpty(EstruturaSelecionada.IdEstrutura))
            {
                var pecas = await _pecaRepository.GetPecasByEstruturaIdAsync(EstruturaSelecionada.IdEstrutura);
                Pecas = new ObservableCollection<Peca>(pecas);
            }
            else
            {
                Pecas.Clear(); // Limpa a lista de peças se nenhuma estrutura estiver selecionada
            }
        }

        private async void AdicionarEstrutura()
        {
            var novaEstrutura = new Estrutura { IdEstrutura = Guid.NewGuid().ToString() };
            await _estruturaRepository.AddEstruturaAsync(novaEstrutura);
            CarregarEstruturas();
        }

        private async void EditarEstrutura()
        {
            if (EstruturaSelecionada != null)
            {
                await _estruturaRepository.UpdateEstruturaAsync(EstruturaSelecionada);
                CarregarEstruturas();
            }
        }

        private async void ExcluirEstrutura()
        {
            if (EstruturaSelecionada != null)
            {
                await _estruturaRepository.DeleteEstruturaAsync(EstruturaSelecionada.IdEstrutura);
                CarregarEstruturas();
            }
        }
    }
}
