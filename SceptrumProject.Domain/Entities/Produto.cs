using SceptrumProject.Domain.Validation;

namespace SceptrumProject.Domain.Entities
{
    public sealed class Produto : EntidadeBase
    {  
        public string Descricao { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public string Imagem { get; private set; }

        public Produto(string descricao, string nome, decimal preco, int estoque, string imagem)
        {
            ValidateDomain(descricao, nome, preco, estoque, imagem);
        }

        public Produto(int id, string descricao, string nome, decimal preco, int estoque, string imagem)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(descricao, nome, preco, estoque, imagem);
        }

        private void ValidateDomain(string descricao, string nome, decimal preco, int estoque, string imagem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição inválida. A Descrição é obrigatória.");

            DomainExceptionValidation.When(descricao.Length < 3, "Descrição inválida. A Descrição deve conter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O Nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido. O Nome deve conter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(preco < 0,  "Valor inválido para o preço.");

            DomainExceptionValidation.When(estoque < 0, "Valor inválido para o estoque.");

            DomainExceptionValidation.When(imagem?.Length > 250, "Nome da imagem é inválido, não pode ultrapassar 250 caracteres.");

            Descricao = descricao;
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
            Imagem = imagem;
        }

        public void Update(string descricao, string nome, decimal preco, int estoque, string imagem, int categoriaId)
        {
            ValidateDomain(descricao, nome, preco, estoque, imagem);
            CategoriaId = categoriaId;
        }

        public int CategoriaId { get;  set; }
        public Categoria Categoria { get;  set; }
    }
}
