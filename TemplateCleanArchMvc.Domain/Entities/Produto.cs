namespace TemplateCleanArchMvc.Domain.Entities
{
    public sealed class Produto
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public string Nome { get; private set; }
        public string Preco { get; private set; }
        public int Estoque { get; private set; }
        public string Imagem { get; private set; }

        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
    }
}
