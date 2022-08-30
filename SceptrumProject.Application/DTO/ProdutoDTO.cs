using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SceptrumProject.Domain.Entities;

namespace SceptrumProject.Application.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int Estoque { get; set; }

        [MaxLength(250)]
        [DisplayName("Imagem do Produto")]
        public string Imagem { get; set; }

        public Categoria Categoria { get; set; }

        [DisplayName("Categorias")]
        public int CategoriaId { get; set; }
    }
}
