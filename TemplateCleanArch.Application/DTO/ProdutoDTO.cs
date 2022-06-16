using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TemplateCleanArch.Domain.Entities;

namespace TemplateCleanArch.Application.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Descricao")]
        public string Descricao { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Preco { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int Estoque { get; private set; }

        [MaxLength(250)]
        [DisplayName("Imagem do Produto")]
        public string Imagem { get; private set; }

        public Categoria  Categoria { get; set; }

        [DisplayName("Categorias")]
        public int CategoriaId { get; set; }
    }
}
