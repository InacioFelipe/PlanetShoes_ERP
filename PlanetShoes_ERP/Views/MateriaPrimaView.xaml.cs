using PlanetShoes.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace PlanetShoes.Views
{
    /// <summary>
    /// Interação lógica para MateriaPrimaView.xam
    /// </summary>
    public partial class MateriaPrimaView : UserControl
    {
        public MateriaPrimaView()
        {
            InitializeComponent();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is MateriaPrimaViewModel viewModel)
            {
                viewModel.CampoEmFoco = false; // Indica que o campo perdeu o foco
            }
        }
    }
}
