using Phusion2.Application.Parameters;
using Phusion2.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phusion2.Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task<IEnumerable<CustomerViewModel>> GetAsync(CustomerParams cParams);
        Task<int> GetCountAsync(CustomerParams cParams);
        Task<CustomerViewModel> GetByIdAsync(int id);
        Task<CustomerViewModel> RegisterAsync(CustomerViewModel request);
        Task<CustomerViewModel> UpdateAsync(CustomerViewModel request);
        Task<int> RemoveAsync(int id);
    }
}
