using Phusion2.Application.ViewModels;

namespace Phusion2.Application.Validations.Customer
{
    public class UpdateCustomerValidation : CustomerValidation<CustomerViewModel>
    {
        public UpdateCustomerValidation()
        {
            ValidateId();
            ValidateFirstName();
            ValidateLastName();
            ValidateCPF();
            ValidateDateOfBirth();
            ValidateProfessionId();
        }
    }
}
