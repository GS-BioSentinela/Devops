using NET___BioSentinela.Infrastructure.DTO.Request;
using System.Security.Cryptography.Pkcs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NET___BioSentinela.Domain.Entities
{
    public class Sensor : UserAudit
    {
        public Guid Id { get; private set; }
        public string Tipo { get; private set; }
        public string Localizacao { get; private set; }

        public Guid RegiaoId { get; private set; }
        public Regiao Regiao { get; private set; }
        
        public List<Alerta> Alertas { get; private set; }      

        public Sensor() { }

        public Sensor(SensorRequest sensorRequest) {
            Id = Guid.NewGuid();
            Tipo = sensorRequest.Tipo;
            Localizacao = sensorRequest.Localizacao;
            RegiaoId = sensorRequest.RegiaoId;               
        }


        public void Update(SensorRequest request)
        {
            Tipo = request.Tipo;
            Localizacao = request.Localizacao;
            RegiaoId = request.RegiaoId;

            
            Updated = "Sistema";
            DataUpdated = DateTime.UtcNow;
        }
    }
}
