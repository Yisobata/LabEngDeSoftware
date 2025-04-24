using System.Diagnostics;
namespace QuadrasApi
{
    public class Usuario
    {
        // TODO: Documentar usando Doxygen
        private readonly int _id; // ! ID de Autenticação
        private readonly string _email; // ! E-mail do Usuário 
        private readonly string _senha; // ! Senha do Usuário 
        private readonly string _nome; // ! Nome do Usuário
        private readonly string _localizacao; // <! Localização do Usuário

        public Usuario(int id, string email, string senha, string nome,
                       string localizacao) 
            //! Construtor padrão da classe Usuário
            /*!
              \param id id de autenticação
              \param email e-mail do usuário
              \param senha senha do usuário
              \param nome nome do usuário
              \param localizacao localizacao do usuário
              \return retorna o objeto Usuario
            */
        {
            _id = id;
            _email = email;
            _senha = senha;
            _nome  = nome;
            _localizacao = localizacao;
        }
        // FIXME: Criar classe Autenticacao?
        public bool Autenticar()
            //! Autentica um Usuário
            //! \return Verdadeiro se o usuário foi autenticado ou falso caso contrário
        {
            return true;
        }
        
        public bool AutenticarPerfil()
            //! Autentica o perfil do usuário
            //! \return Verdadeiro se o perfil foi autenticado ou falso caso contrário
        {
            return true;
        }

    };
}
