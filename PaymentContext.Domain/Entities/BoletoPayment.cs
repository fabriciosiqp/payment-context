using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string bardCode,
            string boletoNumber,
            Email email,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Document document,
            Address address) : base(paidDate, expireDate, total, totalPaid, payer, document, address)
        {
            BardCode = bardCode;
            BoletoNumber = boletoNumber;
            Email = email;
        }

        public string BardCode { get; private set; }
        public string BoletoNumber { get; private set; }
        public Email Email { get; private set; }
    }
}
