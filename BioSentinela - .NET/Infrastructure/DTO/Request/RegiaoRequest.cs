using System.ComponentModel.DataAnnotations;

namespace NET___BioSentinela.Infrastructure.DTO.Request
{
    public class RegiaoRequest
    {
        [Required(ErrorMessage ="Nome é obrigatório")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [MaxLength(200)]
        public string Bioma { get; set; }
    }
}
