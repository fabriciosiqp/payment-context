using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using Xunit;

namespace PaymentContext.Tests.Handlers
{
    public class SubscriptionHandlerTests
    {
        [Fact]
        public void ShouldReturnErrorWhenDocumentExist()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Fabrício";
            command.LastName = "Siqueira";
            command.Document = "41881825043";
            command.Email = "fabriciosiqp@gmail.com";
            command.BardCode = "12345679812345";
            command.BoletoNumber = "1234589";
            command.PaymentNumber = "545595959";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddDays(3);
            command.Total = 600;
            command.TotalPaid = 600;
            command.Payer = "Dev Corp";
            command.PayerDocument = "41881825043";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "devcorp@dev.com.br";
            command.Street = "Dev";
            command.Number = "13";
            command.Neighborhood = "Centro";
            command.City = "Aracaju";
            command.State = "SE";
            command.Country = "BR";
            command.ZipCode = "49000000";

            handler.Handle(command);

            Assert.False(handler.Valid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenDocumentNotExist()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Fabrício";
            command.LastName = "Siqueira";
            command.Document = "78675177070";
            command.Email = "fabriciosiqp@gmail.com";
            command.BardCode = "12345679812345";
            command.BoletoNumber = "1234589";
            command.PaymentNumber = "545595959";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddDays(3);
            command.Total = 600;
            command.TotalPaid = 600;
            command.Payer = "Dev Corp";
            command.PayerDocument = "78675177070";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "devcorp@dev.com.br";
            command.Street = "Dev";
            command.Number = "13";
            command.Neighborhood = "Centro";
            command.City = "Aracaju";
            command.State = "SE";
            command.Country = "BR";
            command.ZipCode = "49000000";

            handler.Handle(command);

            Assert.False(handler.Valid);
        }
    }
}
