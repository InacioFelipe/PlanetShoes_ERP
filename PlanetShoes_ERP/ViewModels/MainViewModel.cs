using PlanetShoes.Core.Commands;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Repositories;
using PlanetShoes.ViewModels;
using System.Windows.Input;

namespace PlanetShoes.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMateriaPrimaRepository _materiaPrimaRepository;
        private readonly IPecaCabedalRepository _pecaCabedalRepository;

        private ViewModelBase _currentChildView;

        public ICommand ShowMateriaPrimaViewCommand { get; }
        public ICommand ShowAcabadoViewCommand { get; }
        public ICommand ShowAviamentoViewCommand { get; }
        public ICommand ShowSoladoViewCommand { get; }
        public ICommand ShowCabedalViewCommand { get; }
        public ICommand ShowFichaTecnicaViewCommand { get; }
        public ICommand ShowDashboardViewCommand { get; }
        public ICommand ShowManualMontagemViewCommand { get; }

        public MainViewModel(IMateriaPrimaRepository materiaPrimaRepository)
        {
            _materiaPrimaRepository = materiaPrimaRepository;

            ShowMateriaPrimaViewCommand = new RelayCommand(ExecuteShowMateriaPrimaViewCommand);
            ShowAcabadoViewCommand = new RelayCommand(ExecuteShowAcabadoViewCommand);
            ShowAviamentoViewCommand = new RelayCommand(ExecuteShowAviamentoViewCommand);
            ShowSoladoViewCommand = new RelayCommand(ExecuteShowSoladoViewCommand);
            ShowCabedalViewCommand = new RelayCommand(ExecuteShowCabedalViewCommand);
            ShowFichaTecnicaViewCommand = new RelayCommand(ExecuteShowFichaTecnicaViewCommand);
            ShowDashboardViewCommand = new RelayCommand(ExecuteShowDashboardViewCommand);
            ShowManualMontagemViewCommand = new RelayCommand(ExecuteShowManualMontagemViewCommand);
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set => SetProperty(ref _currentChildView, value);
        }

        //Navegação
        private void ExecuteShowMateriaPrimaViewCommand(object obj)
        {
            CurrentChildView = new MateriaPrimaViewModel(_materiaPrimaRepository);
        }
        private void ExecuteShowAcabadoViewCommand(object obj)
        {
            CurrentChildView = new AcabadoViewModel();
        }
        private void ExecuteShowAviamentoViewCommand(object obj)
        {
            CurrentChildView = new AviamentoViewModel();
        }
        private void ExecuteShowSoladoViewCommand(object obj)
        {
            CurrentChildView = new SoladoViewModel();
        }
        private void ExecuteShowCabedalViewCommand(object obj)
        {
            CurrentChildView = new CabedalViewModel();
        }

        private void ExecuteShowFichaTecnicaViewCommand(object obj)
        {
            CurrentChildView = new FichaTecnicaViewModel();
        }
        private void ExecuteShowDashboardViewCommand(object obj)
        {
            CurrentChildView = new DashboardViewModel();
        }
        private void ExecuteShowManualMontagemViewCommand(object obj)
        {
            CurrentChildView = new ManualMontagemViewModel();
        }
    }
}