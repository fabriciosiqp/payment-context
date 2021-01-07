using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentTests
    {

        [Theory]
        [InlineData("123")]
        [InlineData("00000000000000")]
        public void ShouldReturnErrorWhenCNPJIsInvalid(string cnpj)
        {
            var doc = new Document(cnpj, EDocumentType.CNPJ);

            Assert.True(doc.Invalid);
        }

        [Theory]
        [InlineData("18134676000133")]
        [InlineData("98940518000100")]
        [InlineData("93212416000154")]
        public void ShouldReturnSuccessWhenCNPJisValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CNPJ);

            Assert.True(doc.Valid);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("12345678900")]
        [InlineData("00000000000")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("33333333333")]
        [InlineData("44444444444")]
        [InlineData("55555555555")]
        [InlineData("66666666666")]
        [InlineData("77777777777")]
        [InlineData("88888888888")]
        [InlineData("99999999999")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);

            Assert.True(doc.Invalid);
        }

        [Theory]
        [InlineData("41881825043")]
        [InlineData("78675177070")]
        [InlineData("08914735052")]
        public void ShouldReturnSuccessWhenCPFisValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);

            Assert.True(doc.Valid);
        }
    }
}
