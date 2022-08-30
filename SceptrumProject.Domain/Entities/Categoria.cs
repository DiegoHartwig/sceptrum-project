using System.Collections.Generic;
using SceptrumProject.Domain.Validation;

namespace SceptrumProject.Domain.Entities
{
    public sealed class Categoria : EntidadeBase
    {    
        public string Descricao { get; private set; }

        public Categoria(string descricao)
        {
            ValidateDomain(descricao);
        }

        public Categoria(int id, string descricao)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(descricao);
        }

        public void Update(string descricao)
        {
            ValidateDomain(descricao);
        }

        public ICollection<Produto> Produtos { get; set; }

        private void ValidateDomain(string descricao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição inválida. Descrição é obrigatória");

            DomainExceptionValidation.When(descricao.Length < 3, "Descrição deve ter no mínimo 3 caracteres");

            Descricao = descricao;
        }
    }
}
