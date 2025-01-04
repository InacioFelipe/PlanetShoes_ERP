using Moq;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using PlanetShoes.Views;
using System.Threading.Tasks;
using Xunit;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace PlanetShoes.Tests
{
    public class LoginTests
    {
        [Fact]
        public async Task Login_WithValidCredentials_ShouldOpenMainView()
        {
            // Arrange
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            var mockServiceProvider = new Mock<IServiceProvider>();

            // Configura o mock para retornar um usuário válido
            var usuarioValido = new Usuario
            {
                Username = "Inacio",
                Password = "inacio"
            };

            mockUsuarioRepository.Setup(repo => repo.GetUsuarioByUsernameAsync("Inacio"))
                                .ReturnsAsync(usuarioValido);

            var loginView = new LoginView(mockUsuarioRepository.Object, mockServiceProvider.Object);

            // Simula a entrada do usuário
            loginView.txtUser.Text = "Inacio";
            loginView.txtPass.Password = "inacio";

            // Act
            //loginView.btnLogin_Click(null, null); //acesso direto ao método privado

            // Usa reflexão para acessar o método privado
            var methodInfo = typeof(LoginView).GetMethod("btnLogin_Click", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            methodInfo.Invoke(loginView, new object[] { null, null });

            // Assert
            mockServiceProvider.Verify(provider => provider.GetRequiredService<MainView>(), Times.Once);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ShouldShowErrorMessage()
        {
            // Arrange
            var mockUsuarioRepository = new Mock<IUsuarioRepository>();
            var mockServiceProvider = new Mock<IServiceProvider>();

            // Configura o mock para retornar null (usuário não encontrado)
            mockUsuarioRepository.Setup(repo => repo.GetUsuarioByUsernameAsync("Inacio"))
                                .ReturnsAsync((Usuario)null);

            var loginView = new LoginView(mockUsuarioRepository.Object, mockServiceProvider.Object);

            // Simula a entrada do usuário
            loginView.txtUser.Text = "Inacio";
            loginView.txtPass.Password = "senhaerrada";

            // Act
            //loginView.btnLogin_Click(null, null); //acesso direto ao método privado

            // Usa reflexão para acessar o método privado
            var methodInfo = typeof(LoginView).GetMethod("btnLogin_Click", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            methodInfo.Invoke(loginView, new object[] { null, null });

            // Assert
            // Verifica se a mensagem de erro foi exibida
            // Aqui você pode verificar se uma MessageBox foi exibida, mas isso requer um pouco mais de configuração.
            // Para simplificar, podemos apenas verificar se o método GetRequiredService não foi chamado.
            mockServiceProvider.Verify(provider => provider.GetRequiredService<MainView>(), Times.Never);
        }
    }
}