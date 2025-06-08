using System.ComponentModel.DataAnnotations;

namespace NET___BioSentinela.Infrastructure.DTO.Request
{
    public class AlertaRequest
    {
        [Required(ErrorMessage = "O tipo é obrigatório")]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "A menssagem é obrigatória")]
        [MaxLength(200)]
        public string Mesagem   { get; set; }

        [Required(ErrorMessage = "O id do Sensor é obrigatório")]
        public Guid SensorId { get; set; }

    }
}
