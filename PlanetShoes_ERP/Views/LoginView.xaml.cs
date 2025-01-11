using Microsoft.Extensions.DependencyInjection;
using PlanetShoes.Core.Interfaces;
using System.Windows;
using System.Windows.Controls;
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

        public async void btnLogin_Click(object sender, RoutedEventArgs e)
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

    //public partial class LoginView: Window
    //{
    //    public TextBox txUser { get; set; }
    //    public PasswordBox txPass { get; set; } // PasswordBox para campos de senha

    //    private readonly IUsuarioRepository _usuarioRepository;
    //    private readonly IServiceProvider _serviceProvider;
    //    private readonly IMessageBoxService _messageBoxService;

    //    public LoginView(IUsuarioRepository usuarioRepository, IServiceProvider serviceProvider, IMessageBoxService messageBoxService)
    //    {
    //        _usuarioRepository = usuarioRepository;
    //        _serviceProvider = serviceProvider;
    //        _messageBoxService = messageBoxService;

    //        // Inicializa os controles
    //        txUser = new TextBox();
    //        txPass = new PasswordBox();

    //        // Configura a interface do usuário
    //        InitializeComponent();
    //    }

    //    public void PerformLogin()
    //    {
    //        btnLogin_Click(null, null);
    //    }

    //    private void btnLogin_Click(object sender, EventArgs e)
    //    {
    //        var usuario = _usuarioRepository.GetUsuarioByUsernameAsync(txUser.Text).Result;

    //        if (usuario == null || usuario.Password != txPass.Password)
    //        {
    //            _messageBoxService.ShowError("Credenciais inválidas.");
    //            return;
    //        }

    //       // Login bem-sucedido
    //        var mainView = _serviceProvider.GetRequiredService<MainView>();
    //        mainView.Show();
    //        this.Close();
    //    }

    //    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    //    {
    //        if (e.LeftButton == MouseButtonState.Pressed)
    //            DragMove();
    //    }

    //    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    //    {
    //        WindowState = WindowState.Minimized;
    //    }

    //    private void btnClose_Click(object sender, RoutedEventArgs e)
    //    {
    //        Application.Current.Shutdown();
    //    }
    //}
}