using Phusion2.Domain.Core.Models;
using System;

namespace Phusion2.Domain.Models
{
    public class Customer : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CPF { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Age => DateTime.Today.Year - DateOfBirth.Year;
        public int? ProfessionId { get; private set; }

        public virtual Profession Profession { get; set; }

        protected Customer() { } // Empty constructor for EF

        public Customer(int id, string firstName, string lastName, string cpf, DateTime dateOfBirth, 
            int? professionId = null, Profession profession = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CPF = cpf;
            DateOfBirth = dateOfBirth;
            ProfessionId = professionId;
            Profession = profession;
        }
    }
}
