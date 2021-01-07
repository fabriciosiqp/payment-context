using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public bool CreateSubscription(Student student)
        {
            throw new System.NotImplementedException();
        }

        public bool DocumentExist(string document)
        {
            if (document == "12345678912")
                return true;

            return false;
        }

        public bool EmailExist(string email)
        {
            if (email == "fabriciosiqp@gmail.com")
                return true;

            return false;
        }
    }
}
