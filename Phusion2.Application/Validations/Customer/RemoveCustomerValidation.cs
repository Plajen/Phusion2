using Phusion2.Application.ViewModels;

namespace Phusion2.Application.Validations.Customer
{
    public class RemoveCustomerValidation : CustomerValidation<CustomerViewModel>
    {
        public RemoveCustomerValidation()
        {
            ValidateId();
        }
    }
}
