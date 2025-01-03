using Microsoft.Extensions.DependencyInjection;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace PlanetShoes.Views
{
    public partial class LoginView : Window
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IServiceProvider _serviceProvider;

        public LoginView(IUsuarioRepository usuarioRepository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _usuarioRepository = usuarioRepository;
            _serviceProvider = serviceProvider;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Password;

            var usuario = await _usuarioRepository.GetUsuarioByUsernameAsync(username);

            if (usuario != null && usuario.Password == password)
            {
                // Login bem-sucedido
                var mainView = _serviceProvider.GetRequiredService<MainView>();
                mainView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.");
            }
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}