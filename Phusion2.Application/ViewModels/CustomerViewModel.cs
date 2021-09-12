using Phusion2.Domain.Models;
using System;
using Phusion2.Application.Utilities;
using Phusion2.Application.Validations.Customer;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Phusion2.Application.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O {0} é necessário")]
        [MaxLength(30, ErrorMessage = "The maximum {0} size is {1}")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O {0} é necessário")]
        [MaxLength(100, ErrorMessage = "The maximum {0} size is {1}")]
        public string LastName { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O {0} é necessário")]
        [MaxLength(14, ErrorMessage = "The maximum {0} size is {1}")]
        public string CPF { get; set; }

        [MinimumAge(0)]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        [Required(ErrorMessage = "A {0} é necessária")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Idade")]
        public int Age => DateTime.Today.Year - DateOfBirth.Year;

        [Display(Name = "Profissão")]
        public int? ProfessionId { get; set; }

        public virtual ProfessionViewModel Profession { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public CustomerViewModel(
            string firstName, 
            string lastName, 
            string cpf, 
            DateTime dateOfBirth, 
            int? professionId = null,
            ProfessionViewModel profession = null)
        {
            FirstName = firstName;
            LastName = lastName;
            CPF = cpf;
            DateOfBirth = dateOfBirth;

            if (professionId != null)
                ProfessionId = professionId;

            if (profession != null)
                Profession = profession;
        }

        public bool RegistryIsValid()
        {
            ValidationResult = new RegisterNewCustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool UpdateIsValid()
        {
            ValidationResult = new UpdateCustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool RemovalIsValid()
        {
            ValidationResult = new RemoveCustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
