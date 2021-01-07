using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PaymentContext.Tests.Queries
{
    public class StudentQueriesTests
    {
        private readonly IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("41881825043", EDocumentType.CPF),
                    new Email("aluno@dev.com")
                    ));
            }
        }

        [Fact]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var expression = StudentQueries.GetStudent("12345678912");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.Null(student);
        }

        [Fact]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var expression = StudentQueries.GetStudent("41881825043");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.NotNull(student);
        }
    }
}
