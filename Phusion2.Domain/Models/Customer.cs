using Phusion2.Domain.Core.Models;
using System;
using Phusion2.Domain.Extensions;

namespace Phusion2.Domain.Models
{
    public class Customer : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CPF { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Age { get; private set; }
        public int? ProfessionId { get; private set; }

        public virtual Profession Profession { get; private set; }

        protected Customer() { } // Empty constructor for EF

        public Customer(int id, string firstName, string lastName, string cpf, DateTime dateOfBirth, 
            int? professionId = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CPF = cpf.ToCleanCPF();
            DateOfBirth = dateOfBirth;
            ProfessionId = professionId;
            Age = DateTime.Today.Year - DateOfBirth.Year;
        }
    }
}
