namespace BellaFasion.Auth
{
    public class Login
    {
        private readonly Token _token;
        private readonly Usuario _user;

        public Login(Token token, Usuario user)
        {
            _token = token;
            _user = user;
        }
        public bool ValidateUser(string username, string password)
        {
            return true;
        }

        public string UsuarioAuth(string? Nome, string? Senha)
        {
           // var tokenService = new TokenService();
            var chaveSecreta = "MinhasenhaSuperD#!V!D@202329/10/2023"; // Use sua chave real


            if (Nome == "usuario" && Senha == "senha")
            {
                return _token.GenerateToken(Nome);
            }

            return "";
        }


    }
}
