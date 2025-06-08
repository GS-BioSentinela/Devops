using NET___BioSentinela.Infrastructure.DTO.Request;
using Oracle.EntityFrameworkCore.Query.Internal;
using System.Xml.Linq;

namespace NET___BioSentinela.Domain.Entities
{
    public class Usuario : UserAudit
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Usuario() { }

        public Usuario(UsuarioRequest userRequest)
        {
            Id = Guid.NewGuid();
            Username = userRequest.Username;
            Password = userRequest.Password;

            Created = "Sistema"; // Ou algum usuário real
            DataCreated = DateTime.UtcNow;
            Updated = "Sistema";
            DataUpdated = DateTime.UtcNow;
        }

        public void Update(UsuarioRequest request)
        {
            Username = request.Username;
            Password = request.Password;

            Updated = "sistema"; // ou obtenha do usuário autenticado
            DataUpdated = DateTime.UtcNow;
        }
    }
}
