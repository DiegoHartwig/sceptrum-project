using FluentAssertions;
using System;
using SceptrumProject.Domain.Entities;
using SceptrumProject.Domain.Validation;
using Xunit;

namespace SceptrumProject.Domain.Tests
{
    public class CategoriaTesteUnidade
    {
        [Fact(DisplayName = "Criando Categoria com estado v�lido")]
        public void CriandoCategoria_ComParametrosValidos_ResultadoObjetoEstadoValido()
        {
            Action action = () => new Categoria(1, "Nome da Categoria");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criando Categoria com id negativo, inv�lido")]
        public void CriandoCategoria_ComIdNegativo_DomainExceptionIdInvalido()
        {
            Action action = () => new Categoria(-1, "Nome da Categoria");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Id inv�lido.");
        }

        [Fact(DisplayName = "Criando Categoria com nome incorreto")]
        public void CriandoCategoria_ComNomeIncorreto_DomainExceptionNomeInvalido()
        {
            Action action = () => new Categoria(1, "ca");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Descri��o deve ter no m�nimo 3 caracteres");
        }

        [Fact(DisplayName = "Criando Categoria sem preencher o nome")]
        public void CriandoCategoria_SemNome_DomainExceptionNomeRequerido()
        {
            Action action = () => new Categoria(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Descri��o inv�lida. Descri��o � obrigat�ria");
        }

        [Fact(DisplayName = "Criando Categoria com valor nulo")]
        public void CriandoCategoria_ComValorNulo_DomainExceptionNomeInvalido()
        {
            Action action = () => new Categoria(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>();               
        }
    }
}
