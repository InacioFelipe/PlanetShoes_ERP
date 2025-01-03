using PlanetShoes.Core.Commands;
using PlanetShoes.Core.Enums;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlanetShoes.ViewModels
{
    public class MateriaPrimaViewModel : ViewModelBase
    {
        private readonly IMateriaPrimaRepository _materiaPrimaRepository;
        private MateriaPrima _materiaPrimaSelecionada;
        private bool _emEdicao;

        public MateriaPrimaViewModel(IMateriaPrimaRepository materiaPrimaRepository)
        {
            _materiaPrimaRepository = materiaPrimaRepository;
            CarregarMateriasPrimas();

            NovoCommand = new RelayCommand(Novo);
            EditarCommand = new RelayCommand(Editar, CanEditar);
            SalvarCommand = new RelayCommand(Salvar, CanSalvar);
            ExcluirCommand = new RelayCommand(Excluir, CanExcluir);

            GerenciarEstadoControles();
        }

        public List<MateriaPrima> MateriasPrimas { get; set; }
        public Dictionary<UnidadeDeMedida, string> UnidadesDeMedida { get; set; }

        public MateriaPrima MateriaPrimaSelecionada
        {
            get => _materiaPrimaSelecionada;
            set
            {
                SetProperty(ref _materiaPrimaSelecionada, value);
                GerenciarEstadoControles();
            }
        }

        public ICommand NovoCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }

        private async void CarregarMateriasPrimas()
        {
            MateriasPrimas = await _materiaPrimaRepository.GetAllAsync();
            OnPropertyChanged(nameof(MateriasPrimas));
        }

        private void Novo(object obj)
        {
            MateriaPrimaSelecionada = new MateriaPrima
            {
                IdMateriaPrima = Guid.NewGuid().ToString(),
                Codigo = GerarCodigo(),
                UnidadeMedida = UnidadeDeMedida.Milimetro // Valor padrão
            };
            _emEdicao = true;
            GerenciarEstadoControles();
        }

        private void Editar(object obj)
        {
            _emEdicao = true;
            GerenciarEstadoControles();
        }

        private async void Salvar(object obj)
        {
            if (_emEdicao)
            {
                if (MateriaPrimaSelecionada.IdMateriaPrima == null)
                {
                    await _materiaPrimaRepository.AddAsync(MateriaPrimaSelecionada);
                }
                else
                {
                    await _materiaPrimaRepository.UpdateAsync(MateriaPrimaSelecionada);
                }
                CarregarMateriasPrimas();
            }
            _emEdicao = false;
            GerenciarEstadoControles();
        }

        private async void Excluir(object obj)
        {
            if (MateriaPrimaSelecionada != null)
            {
                await _materiaPrimaRepository.DeleteAsync(MateriaPrimaSelecionada.IdMateriaPrima);
                CarregarMateriasPrimas();
            }
        }

        private bool CanEditar(object obj) => MateriaPrimaSelecionada != null && !_emEdicao;
        private bool CanSalvar(object obj) => _emEdicao;
        private bool CanExcluir(object obj) => MateriaPrimaSelecionada != null && !_emEdicao;

        private void GerenciarEstadoControles()
        {
            OnPropertyChanged(nameof(CanEditar));
            OnPropertyChanged(nameof(CanSalvar));
            OnPropertyChanged(nameof(CanExcluir));
        }

        private int GerarCodigo()
        {
            return MateriasPrimas.Any() ? MateriasPrimas.Max(m => m.Codigo) + 1 : 1;
        }
    }
}