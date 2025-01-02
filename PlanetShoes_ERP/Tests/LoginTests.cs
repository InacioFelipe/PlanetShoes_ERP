// Testes Unitários
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using PlanetShoes.Views;

namespace PlanetShoes.Tests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public async Task Login_Successful()
        {
            var mockRepo = new Mock<IUsuarioRepository>();
            mockRepo.Setup(repo => repo.GetUsuarioByUsernameAsync("testuser"))
                .ReturnsAsync(new Usuario { Username = "testuser", Password = "hashedpassword" });

            var loginView = new LoginView(mockRepo.Object);

            //// Simula a entrada do usuário
            //loginView.txtUser.Text = "testuser";
            //loginView.txtPass.Password = "hashedpassword";

            //await loginView.btnLogin_Click(null, null);

            //// Verifica se a janela principal foi aberta
            //Assert.IsTrue(Application.Current.Windows.Count > 1);
        }
    }
}