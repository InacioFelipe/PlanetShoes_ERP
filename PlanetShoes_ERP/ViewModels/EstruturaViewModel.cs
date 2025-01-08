using PlanetShoes.Core.Commands;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlanetShoes.ViewModels
{
    public class EstruturaViewModel : ViewModelBase
    {
        private readonly IEstruturaRepository _estruturaRepository;


        // Comandos
        public ICommand CarregarEstruturasCommand { get; }
        public ICommand SalvarEstruturaCommand { get; }
        public ICommand EditarEstruturaCommand { get; }
        public ICommand ExcluirEstruturaCommand { get; }


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

            }
        }

        // Construtor
        public EstruturaViewModel(IEstruturaRepository estruturaRepository)
        {
            _estruturaRepository = estruturaRepository;

            // Carrega as estruturas ao inicializar
            CarregarEstruturasAsync();

            // Inicializa os comandos
            CarregarEstruturasCommand = new RelayCommand(async (param) => await CarregarEstruturasAsync());
            SalvarEstruturaCommand = new RelayCommand(async (param) => await SalvarEstruturaAsync());
            EditarEstruturaCommand = new RelayCommand(async (param) => await EditarEstruturaAsync());
            ExcluirEstruturaCommand = new RelayCommand(async (param) => await ExcluirEstruturaAsync());

        }

        // Métodos
        private async Task CarregarEstruturasAsync()
        {
            Estruturas = await _estruturaRepository.GetAllAsync();
        }

        private async Task SalvarEstruturaAsync()
        {
            if (EstruturaSelecionada != null)
            {
                if (string.IsNullOrEmpty(EstruturaSelecionada.IdEstrutura))
                {
                    await _estruturaRepository.AddAsync(EstruturaSelecionada);
                }
                else
                {
                    await _estruturaRepository.UpdateAsync(EstruturaSelecionada);
                }
                await CarregarEstruturasAsync(); // Atualiza a lista após salvar
            }
        }

        private async Task EditarEstruturaAsync()
        {
            if (EstruturaSelecionada != null)
            {
                await _estruturaRepository.UpdateAsync(EstruturaSelecionada);
                await CarregarEstruturasAsync(); // Atualiza a lista após editar
            }
        }

        private async Task ExcluirEstruturaAsync()
        {
            if (EstruturaSelecionada != null)
            {
                await _estruturaRepository.DeleteAsync(EstruturaSelecionada.IdEstrutura);
                await CarregarEstruturasAsync(); // Atualiza a lista após excluir
            }
        }
    }
}
