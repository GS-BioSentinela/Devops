using NET___BioSentinela.Infrastructure.DTO.Request;

namespace NET___BioSentinela.Domain.Entities
{
    public class Regiao : UserAudit
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Bioma { get; private set; }

        public List<Sensor> Sensors { get; private set; }

        public Regiao() { }

        public Regiao(RegiaoRequest regiaoRequest)
        {
            Id = Guid.NewGuid();
            Nome = regiaoRequest.Nome;
            Bioma = regiaoRequest.Bioma;

            Created = "Sistema"; // Ou algum usuário real
            DataCreated = DateTime.UtcNow;
            Updated = "Sistema";
            DataUpdated = DateTime.UtcNow;
        }

        public void Update(RegiaoRequest request)
        {
            Nome = request.Nome;
            Bioma = request.Bioma;

            Updated = "sistema"; // ou obtenha do usuário autenticado
            DataUpdated = DateTime.UtcNow;
        }
    }
}
