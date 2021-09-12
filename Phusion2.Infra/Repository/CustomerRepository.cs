using Phusion2.Domain.Interfaces;
using Phusion2.Domain.Models;
using Phusion2.Infra.Context;

namespace Phusion2.Infra.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Phusion2Context context) : base(context)
        {

        }
    }
}
