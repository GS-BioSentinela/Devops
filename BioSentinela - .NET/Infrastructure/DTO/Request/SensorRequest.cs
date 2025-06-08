using System.ComponentModel.DataAnnotations;

namespace NET___BioSentinela.Infrastructure.DTO.Request
{
    public class SensorRequest
    {
        [Required(ErrorMessage = "Tipo é obrigatório")]
        [MaxLength (100)]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "A loacalização é obrigatória")]
        [MaxLength (150)]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "O id da região é obrigatório")]
        public Guid RegiaoId { get; set; }
    }
}
