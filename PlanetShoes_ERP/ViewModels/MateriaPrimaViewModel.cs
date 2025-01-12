using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PlanetShoes.Core.Commands;
using PlanetShoes.Core.Enums;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Microsoft.Win32;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace PlanetShoes.ViewModels
{
    public class MateriaPrimaViewModel : ViewModelBase
    {
        // Propriedades
        private readonly IMateriaPrimaRepository _materiaPrimaRepository;
        public Dictionary<UnidadeDeMedida, string> UnidadesDeMedida { get; set; }
        public List<MateriaPrima> MateriasPrimas { get; set; }

        private List<MateriaPrima> _materiasPrimasFiltradas;
        public List<MateriaPrima> MateriasPrimasFiltradas
        {
            get => _materiasPrimasFiltradas;
            set => SetProperty(ref _materiasPrimasFiltradas, value);
        }

        private MateriaPrima _materiaPrimaSelecionada;
        public MateriaPrima MateriaPrimaSelecionada
        {
            get => _materiaPrimaSelecionada;
            set
            {
                SetProperty(ref _materiaPrimaSelecionada, value);
                GerenciarEstadoControles();
            }
        }

        private Brush _bordaCor = Brushes.Transparent; // Cor padrão da borda
        public Brush BordaCor
        {
            get => _bordaCor;
            set => SetProperty(ref _bordaCor, value);
        }

        private bool _emEdicao;
        public bool EmEdicao
        {
            get => _emEdicao;
            set
            {
                SetProperty(ref _emEdicao, value);
            }
        }

        private bool _campoEmFoco;
        public bool CampoEmFoco
        {
            get => _campoEmFoco;
            set
            {
                SetProperty(ref _campoEmFoco, value);
            }
        }

        private string _filtroCodigo;
        public string FiltroCodigo
        {
            get => _filtroCodigo;
            set
            {
                SetProperty(ref _filtroCodigo, value);
                FiltrarMateriasPrimas();
            }
        }

        private string _filtroDescricao;
        public string FiltroDescricao
        {
            get => _filtroDescricao;
            set
            {
                SetProperty(ref _filtroDescricao, value);
                FiltrarMateriasPrimas();
            }
        }


        // Gerencia estado dos botões
        private bool CanEditar(object obj) => !_emEdicao && MateriaPrimaSelecionada != null;
        private bool CanSalvar(object obj) => _emEdicao;
        private bool CanExcluir(object obj) => !_emEdicao && MateriaPrimaSelecionada != null;
        private bool CanImportar(object obj) => _emEdicao;

        //Construtor
        public MateriaPrimaViewModel(IMateriaPrimaRepository materiaPrimaRepository)
        {
            _materiaPrimaRepository = materiaPrimaRepository;
            MateriasPrimasFiltradas = new List<MateriaPrima>(); // Inicializa como vazia
            MateriaPrimaSelecionada = new MateriaPrima(); // Inicializa com um objeto não nulo
            CarregarMateriasPrimas();

            NovoCommand = new RelayCommand(Novo);
            EditarCommand = new RelayCommand(Editar, CanEditar);
            SalvarCommand = new RelayCommand(Salvar, CanSalvar);
            ExcluirCommand = new RelayCommand(Excluir, CanExcluir);
            ImportarExcelCommand = new RelayCommand(ImportarExcel);

            // Inicializa a lista de unidades de medida
            UnidadesDeMedida = Enum.GetValues(typeof(UnidadeDeMedida))
                                  .Cast<UnidadeDeMedida>()
                                  .ToDictionary(u => u, u => u.ToString());

            GerenciarEstadoControles();
        }


        // Commands
        public ICommand NovoCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand SalvarCommand { get; }
        public ICommand ExcluirCommand { get; }
        public ICommand ImportarExcelCommand { get; }


        // Métodos
        private async void CarregarMateriasPrimas()
        {
            //Carrega lista normal
            //MateriasPrimas = await _materiaPrimaRepository.GetAllAsync();

            // Carrega as matérias-primas do repositório e ordena por código
            var materiasPrimas = await _materiaPrimaRepository.GetAllAsync();
            MateriasPrimas = materiasPrimas.OrderBy(m => m.Codigo).ToList();


            // Seleciona a primeira linha da grid
            if (MateriasPrimas.Any())
            {
                MateriaPrimaSelecionada = MateriasPrimas.First();
            }

            OnPropertyChanged(nameof(MateriasPrimas));
            OnPropertyChanged(nameof(MateriasPrimasFiltradas));
        }

        private void FiltrarMateriasPrimas()
        {

            // Verifica se ambos os campos de busca estão vazios
            if (string.IsNullOrEmpty(FiltroCodigo) && string.IsNullOrEmpty(FiltroDescricao))
            {
                MateriasPrimasFiltradas = new List<MateriaPrima>(); // Define a lista filtrada como vazia
                OnPropertyChanged(nameof(MateriasPrimasFiltradas));
                return; // Sai do método sem aplicar filtros
            }

            var query = MateriasPrimas.AsQueryable();

            if (!string.IsNullOrEmpty(FiltroCodigo))
            {
                query = query.Where(m => m.Codigo.ToString().Contains(FiltroCodigo));
            }

            if (!string.IsNullOrEmpty(FiltroDescricao))
            {
                // Sensitive Case
                //query = query.Where(m => m.Nome != null && m.Nome.Contains(FiltroDescricao));

                // Não sensitive Case
                query = query.Where(m => m.Nome != null && m.Nome.ToLower().Contains(FiltroDescricao.ToLower()));
            }

            MateriasPrimasFiltradas = query.ToList();
            OnPropertyChanged(nameof(MateriasPrimasFiltradas));
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
            AtualizarCorBorda();
        }

        private void Editar(object obj)
        {
            _emEdicao = true;
            GerenciarEstadoControles();
        }

        private async void Salvar(object obj)
        {

            // Verifica se o registro já existe no banco de dados
            var materiaPrimaExistente = MateriasPrimas
                .FirstOrDefault(mp => mp.IdMateriaPrima == MateriaPrimaSelecionada.IdMateriaPrima);

            if (_emEdicao)
            {

                if (materiaPrimaExistente == null)
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
            AtualizarCorBorda();
        }

        private async void Excluir(object obj)
        {
            if (MateriaPrimaSelecionada != null)
            {
                await _materiaPrimaRepository.DeleteAsync(MateriaPrimaSelecionada.IdMateriaPrima);
                CarregarMateriasPrimas();
            }
        }

        private void GerenciarEstadoControles()
        {
            OnPropertyChanged(nameof(CanEditar));
            OnPropertyChanged(nameof(CanSalvar));
            OnPropertyChanged(nameof(CanExcluir));
            OnPropertyChanged(nameof(CanImportar));
        }

        private int GerarCodigo()
        {
            return MateriasPrimas.Any() ? MateriasPrimas.Max(m => m.Codigo) + 1 : 1;
        }

        private void AtualizarCorBorda()
        {
            if (EmEdicao && (string.IsNullOrEmpty(MateriaPrimaSelecionada.Nome) ||
                             string.IsNullOrEmpty(MateriaPrimaSelecionada.Descricao) ||
                             MateriaPrimaSelecionada.Valor == 0))
            {
                BordaCor = Brushes.Orange; // Cor dos botões (ou a cor que você desejar)
            }
            else
            {
                BordaCor = Brushes.Transparent; // Volta ao normal
            }
        }

        private async void ImportarExcel(object obj)
        {
            // Define a licença como não comercial
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            try
            {
                // Abre uma caixa de diálogo para selecionar o arquivo Excel
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Arquivos Excel (*.xlsx)|*.xlsx",
                    Title = "Selecione o arquivo Excel"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;

                    // Lê o arquivo Excel
                    using (var package = new ExcelPackage(new FileInfo(filePath)))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assume que os dados estão na primeira planilha
                        int rowCount = worksheet.Dimension.Rows;

                        // Obtém os códigos das matérias-primas já existentes no banco de dados
                        var codigosExistentes = (await _materiaPrimaRepository.GetAllAsync()).Select(mp => mp.Codigo).ToList();

                        // Lista temporária para armazenar os dados importados
                        var dadosImportados = new List<MateriaPrima>();

                        // Itera sobre as linhas do Excel (ignorando o cabeçalho)
                        for (int row = 2; row <= rowCount; row++)
                        {
                            int codigo;
                            decimal valor;

                            // Tenta converter o código (coluna 1)
                            if (!int.TryParse(worksheet.Cells[row, 1].Text, out codigo))
                            {
                                MessageBox.Show($"Valor inválido para Código na linha {row}. Será atribuído o valor padrão 0.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                                codigo = 0; // Valor padrão
                            }

                            // Tenta converter o valor (coluna 4)
                            if (!decimal.TryParse(worksheet.Cells[row, 4].Text, out valor))
                            {
                                MessageBox.Show($"Valor inválido para Valor na linha {row}. Será atribuído o valor padrão 0.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                                valor = 0; // Valor padrão
                            }

                            // Cria a matéria-prima com os valores convertidos ou padrão
                            var materiaPrima = new MateriaPrima
                            {
                                IdMateriaPrima = Guid.NewGuid().ToString(),
                                Codigo = codigo,
                                Nome = worksheet.Cells[row, 2].Text,
                                Descricao = worksheet.Cells[row, 3].Text,
                                //UnidadeMedida = Enum.Parse<UnidadeDeMedida>(worksheet.Cells[row, 4].Text),
                                Valor = valor
                            };

                            // Adiciona à lista de dados importados apenas se o código não existir no banco
                            if (!codigosExistentes.Contains(codigo))
                            {
                                dadosImportados.Add(materiaPrima);
                            }
                        }

                        // Salva os dados importados no banco de dados
                        if (dadosImportados.Any())
                        {
                            foreach (var materiaPrima in dadosImportados)
                            {
                                await _materiaPrimaRepository.AddAsync(materiaPrima);
                            }

                            MessageBox.Show($"{dadosImportados.Count} matérias-primas importadas com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                            CarregarMateriasPrimas(); // Atualiza a lista após a importação
                        }
                        else
                        {
                            MessageBox.Show("Todos os dados importados já existem no banco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao importar dados do Excel: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        // Verificar campos preenchidos
        private void VerificarCamposPreenchidos()
        {
            AtualizarCorBorda();
        }

        // Notificar mudanças nos campos
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(MateriaPrimaSelecionada.Nome) ||
                propertyName == nameof(MateriaPrimaSelecionada.Descricao) ||
                propertyName == nameof(MateriaPrimaSelecionada.Valor))
            {
                VerificarCamposPreenchidos();
            }
        }


    }
}