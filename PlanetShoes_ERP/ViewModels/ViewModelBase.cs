using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlanetShoes.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Evento que notifica a View quando uma propriedade é alterada
        public event PropertyChangedEventHandler PropertyChanged;

        // Método para notificar a View sobre mudanças nas propriedades
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Método para atualizar o valor de uma propriedade e notificar a View
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}