using System.Collections.Generic;

namespace TemplateCleanArchMvc.Domain.Entities
{
    public sealed class Categoria
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public Categoria(string descricao)
        {
            Descricao = descricao;
        }

        public Categoria(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public ICollection<Produto> Produtos { get; set; }
    }
}
