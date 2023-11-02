using BellaFasion.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestBellaFashion
{
    internal class LoginTests
    {
        [Test]
        public void UsuarioAuth_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var token = new Token(); // Substitua por uma instância real do Token
            var usuario = new Usuario(); // Substitua por uma instância real do Usuario
            var login = new Login(token, usuario);

            string nome = "usuario";
            string senha = "senha";

            // Act
            var result = login.UsuarioAuth(nome, senha);

            // Assert
            Assert.IsNotEmpty(result); // Verifica se o resultado não está vazio, ou seja, se foi gerado um token.
        }

        [Test]
        public void UsuarioAuth_InvalidCredentials_ReturnsEmptyString()
        {
            // Arrange
            var token = new Token(); // Substitua por uma instância real do Token
            var usuario = new Usuario(); // Substitua por uma instância real do Usuario
            var login = new Login(token, usuario);

            string nome = "usuario";
            string senha = "senhaIncorreta";

            // Act
            var result = login.UsuarioAuth(nome, senha);

            // Assert
            Assert.IsEmpty(result); // Verifica se o resultado é uma string vazia, já que as credenciais são inválidas.
        }
    }
}
