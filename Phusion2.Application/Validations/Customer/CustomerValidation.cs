using FluentValidation;
using Phusion2.Application.ViewModels;
using System;

namespace Phusion2.Application.Validations.Customer
{
    public class CustomerValidation<T> : AbstractValidator<T> where T : CustomerViewModel
    {
        public CustomerValidation()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;
        }

        public void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0);
        }

        public void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor garanta que haja um Nome");
        }

        public void ValidateLastName()
        {
            RuleFor(c => c.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor garanta que haja um Sobrenome");
        }

        public void ValidateCPF()
        {
            var cpfRegex = @"[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2}";

            RuleFor(c => c.CPF)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor garanta que haja um CPF")
                .Matches(cpfRegex)
                .WithMessage("CPF inválido");
        }

        protected void ValidateDateOfBirth()
        {
            RuleFor(c => c.DateOfBirth)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor garanta que haja uma Data de Nascimento")
                .Must(BeAValidDate)
                .Must(BeAValidBirthDate)
                .WithMessage("Data de Nascimento inválida");

        }

        public void ValidateProfessionId()
        {
            RuleFor(c => c.ProfessionId)
                .GreaterThan(0)
                .When(c => c.ProfessionId != null)
                .WithMessage("Profissão inválida");
        }

        private bool BeAValidDate(DateTime date) => !date.Equals(default);

        private bool BeAValidBirthDate(DateTime date)
        {
            int totalYears = DateTime.Now.Year - date.Year;
            return totalYears < 120;
        }
    }
}
