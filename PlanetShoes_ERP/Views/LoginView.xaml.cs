// Views/LoginView.xaml.cs
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlanetShoes.Views
{
    public partial class LoginView : Window
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginView(IUsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            _usuarioRepository = usuarioRepository;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Password;

            var usuario = await _usuarioRepository.GetUsuarioByUsernameAsync(username);

            if (usuario != null && usuario.Password == password)
            {

                // Login bem-sucedido
                var mainView = new MainView();
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