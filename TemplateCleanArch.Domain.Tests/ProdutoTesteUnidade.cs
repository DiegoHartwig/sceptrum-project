using System;
using TemplateCleanArch.Domain.Entities;
using Xunit;
using FluentAssertions;
using TemplateCleanArch.Domain.Validation;

namespace TemplateCleanArch.Domain.Tests
{
    public class ProdutoTesteUnidade
    {
        [Theory]
        [InlineData(-8)]
        public void CriandoProduto_ValorEstoqueInvalido_ExceptionDomainValorNegativo(int value)
        {
            Action action = () => new Produto(1, "Descrição do produto", "Nome do produto", 8.99m, value, "imagem");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Valor inválido para o estoque.");
        }

        [Fact(DisplayName = "Criando Produto com estado válido")]
        public void CriandoProduto_ComParametrosValidos_ResultadoObjetoEstadoValido()
        {
            Action action = () => new Produto(1, "Descrição do produto", "Nome do produto", 8.99m, 89, "imagem"); 
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando Produto com id negativo, inválido")]
        public void CriandoProduto_ComIdNegativo_DomainExceptionIdInvalido()
        {
            Action action = () => new Produto(-1, "Descrição do produto", "Nome do produto", 8.99m, 89, "imagem");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Id inválido.");
        }

        [Fact(DisplayName = "Criando Produto com nome incorreto")]
        public void CriandoProduto_ComNomeIncorreto_DomainExceptionNomeInvalido()
        {
            Action action = () => new Produto(1, "Descricao do Produto", "No", 8.99m, 89, "imagem");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Nome inválido. O Nome deve conter no mínimo 3 caracteres.");
        }

        [Fact(DisplayName = "Criando Produto com imagem maior que o valor permitido")]
        public void CriandoProduto_ComImagemMaiorQuePermitido_DomainExceptionNomeInvalido()
        {
            Action action = () => new Produto(1, "Descricao do Produto", "Nome do Produto", 8.99m, 89, "imagemmaiorqueovalorpermitidoimagemmaiorqueovalorpermitidoimagemmaiorqueovalorpermitidoimagemmaiorqueovalorpermitidoimagemmaiorqueovalorpermitidoimagemmaiorqueovalorpermitidoimagemmaiorqueovalorpermitidoimagemmaiorqueovalorpermitidoimagemmaiorqueovalorpermitidoimagemmaiorqueovalorpermitido");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Nome da imagem é inválido, não pode ultrapassar 250 caracteres.");
        }

        [Fact(DisplayName = "Criando Produto sem preencher o nome")]
        public void CriandoProduto_SemNome_DomainExceptionNomeRequerido()
        {
            Action action = () => new Produto(1, "Descricao do Produto", "", 8.99m, 89, "imagem");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Nome inválido. O Nome é obrigatório.");
        }

        [Fact(DisplayName = "Criando Produto com valor nulo")]
        public void CriandoProduto_ComValorNulo_DomainExceptionNomeInvalido()
        {
            Action action = () => new Produto(1, "Descricao do Produto", null, 8.99m, 89, "imagem");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
