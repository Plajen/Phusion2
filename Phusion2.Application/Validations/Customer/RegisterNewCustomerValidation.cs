using Phusion2.Application.ViewModels;

namespace Phusion2.Application.Validations.Customer
{
    class RegisterNewCustomerValidation : CustomerValidation<CustomerViewModel>
    {
        public RegisterNewCustomerValidation()
        {
            ValidateFirstName();
            ValidateLastName();
            ValidateCPF();
            ValidateDateOfBirth();
            ValidateProfessionId();
        }
    }
}
