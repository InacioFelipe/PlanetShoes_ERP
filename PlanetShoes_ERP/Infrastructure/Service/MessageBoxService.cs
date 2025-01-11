using PlanetShoes.Core.Interfaces;
using System.Windows;

namespace PlanetShoes.Infrastructure.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowError(string message)
        {
            // Exibe uma mensagem de erro para o usuário
            MessageBox.Show(message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
