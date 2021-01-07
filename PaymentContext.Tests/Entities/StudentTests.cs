using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using Xunit;

namespace PaymentContext.Tests.Entities
{
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;

        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Fabrício", "Pereira");
            _document = new Document("41881825043", EDocumentType.CPF);
            _email = new Email("fabriciosiqp@gmail.com");
            _address = new Address("Devs", "13", "Centro", "Aracaju", "SE", "BR", "49000000");

            _student = new Student(_name, _document, _email);

            _subscription = new Subscription(null);


        }
        [Fact]
        public void ShouldReturnErrorWhenActiveSubscription()
        {

            var payment = new PayPalPayment("54984887", _email, DateTime.Now, DateTime.Now.AddDays(3), 600, 600, "DEV CORP", _document, _address);

            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.True(_student.Invalid);

        }

        [Fact]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {

            var payment = new PayPalPayment("54984887", _email, DateTime.Now, DateTime.Now.AddDays(3), 600, 600, "DEV CORP", _document, _address);

            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);

            Assert.True(_student.Valid);
        }

        [Fact]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);

            Assert.True(_student.Invalid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenSubscriptionAddSubscription()
        {
            var payment = new PayPalPayment("54984887", _email, DateTime.Now, DateTime.Now.AddDays(3), 600, 600, "DEV CORP", _document, _address);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.True(_student.Valid);
        }
    }
}
