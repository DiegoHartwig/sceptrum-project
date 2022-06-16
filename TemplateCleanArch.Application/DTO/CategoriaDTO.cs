using System.ComponentModel.DataAnnotations;

namespace TemplateCleanArch.Application.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
